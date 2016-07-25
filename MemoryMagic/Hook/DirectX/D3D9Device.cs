using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming

namespace WoW.DirectX
{
    internal sealed class D3D9Device : D3DDevice
    {
        private const int D3D9SdkVersion = 0x20;
        private const int D3DCREATE_SOFTWARE_VERTEXPROCESSING = 0x20;

        private  VTableFuncDelegate _d3DDeviceRelease;
        private  VTableFuncDelegate _d3DRelease;

        public D3D9Device(Process targetProc) : base(targetProc, "d3d9.dll")
        {
        }

        private IntPtr _pD3D;

        protected override void InitD3D(out IntPtr d3DDevicePtr)
        {
            _pD3D = Direct3DCreate9(D3D9SdkVersion);
            if (_pD3D == IntPtr.Zero)
                throw new Exception("Failed to create D3D.");

            var parameters = new D3DPresentParameters
            {
                Windowed = true,
                SwapEffect = 1,
                BackBufferFormat = 0
            };

            var createDevicePtr = GetVTableFuncAddress(_pD3D, VTableIndexes.Direct3D9CreateDevice);
            var createDevice = GetDelegate<CreateDeviceDelegate>(createDevicePtr);

            if (createDevice(_pD3D, 0, 1, Form.Handle, D3DCREATE_SOFTWARE_VERTEXPROCESSING, ref parameters, out d3DDevicePtr) < 0)
            {
                throw new Exception("Failed to create device.");
            }
            _d3DDeviceRelease = GetDelegate<VTableFuncDelegate>(GetVTableFuncAddress(D3DDevicePtr, VTableIndexes.Direct3DDevice9Release));
            _d3DRelease = GetDelegate<VTableFuncDelegate>(GetVTableFuncAddress(_pD3D, VTableIndexes.Direct3D9Release));
        }

        protected override void CleanD3D()
        {
            if (D3DDevicePtr != IntPtr.Zero)
                _d3DDeviceRelease(D3DDevicePtr);

            if (_pD3D != IntPtr.Zero)
                _d3DRelease(_pD3D);
        }

        public override int EndSceneVtableIndex => VTableIndexes.Direct3DDevice9EndScene;

        public override int PresentVtableIndex => VTableIndexes.Direct3DDevice9Present;


        [DllImport("d3d9.dll")]
        private static extern IntPtr Direct3DCreate9(uint sdkVersion);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate int CreateDeviceDelegate(
            IntPtr instance,
            uint adapter,
            uint deviceType,
            IntPtr focusWindow,
            uint behaviorFlags,
            [In] ref D3DPresentParameters presentationParameters,
            out IntPtr returnedDeviceInterface);

        [StructLayout(LayoutKind.Sequential)]
        private struct D3DPresentParameters
        {
            private readonly uint BackBufferWidth;
            private readonly uint BackBufferHeight;
            public uint BackBufferFormat;
            private readonly uint BackBufferCount;
            private readonly uint MultiSampleType;
            private readonly uint MultiSampleQuality;
            public uint SwapEffect;
            private readonly IntPtr hDeviceWindow;
            [MarshalAs(UnmanagedType.Bool)] public bool Windowed;
            [MarshalAs(UnmanagedType.Bool)] private readonly bool EnableAutoDepthStencil;
            private readonly uint AutoDepthStencilFormat;
            private readonly uint Flags;
            private readonly uint FullScreen_RefreshRateInHz;
            private readonly uint PresentationInterval;
        }


        private struct VTableIndexes
        {
            public const int Direct3D9Release = 2;
            public const int Direct3D9CreateDevice = 0x10;
            public const int Direct3DDevice9Release = 2;
            public const int Direct3DDevice9Present = 0x11;
            public const int Direct3DDevice9BeginScene = 0x29;
            public const int Direct3DDevice9EndScene = 0x2A;
        }
    }
}
