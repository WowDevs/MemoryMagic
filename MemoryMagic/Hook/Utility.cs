using System;
using System.Diagnostics;

// ReSharper disable once CheckNamespace
namespace MemoryMagic
{
    public static class Utility
    {
        public static readonly Random Rand = new Random();

        public static bool Is64BitProcess(Process proc)
        {
            bool retVal;
            return Environment.Is64BitOperatingSystem && !(NativeMethods.IsWow64Process(proc.Handle, out retVal) && retVal);
        }

        // returns base offset for main module
        public static uint BaseOffset(this Process proc)
        {
            return (uint) proc.MainModule.BaseAddress.ToInt32();
        }
    }
}