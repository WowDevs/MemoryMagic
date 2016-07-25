using System;
using System.Diagnostics;
using System.Linq;

// ReSharper disable once CheckNamespace

namespace WoW.DirectX
{
    internal class Dirext3D
    {
        public Dirext3D(Process targetProc)
        {
            TargetProcess = targetProc;

            UsingDirectX11 = TargetProcess.Modules.Cast<ProcessModule>().Any(m => m.ModuleName == "d3d11.dll");

            using (var d3D = UsingDirectX11
                                       ? (D3DDevice)new D3D11Device(targetProc)
                                       : new D3D9Device(targetProc))
            {
                HookPtr = UsingDirectX11 ? ((D3D11Device)d3D).GetSwapVTableFuncAbsoluteAddress(d3D.PresentVtableIndex) : d3D.GetDeviceVTableFuncAbsoluteAddress(d3D.EndSceneVtableIndex);
            }
        }

        private Process TargetProcess { get; set; }
        public bool UsingDirectX11 { get; private set; }
        public IntPtr HookPtr { get; private set; }
    }
}