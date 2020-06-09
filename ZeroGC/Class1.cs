using System;
using System.Runtime.InteropServices;

namespace ZeroGC
{
    public class Class1
    {
        [UnmanagedCallersOnly(EntryPoint = "GC_Initialize")]
        public static int GC_Initialize(
            IntPtr clrToGC,
            IntPtr gcHeap,
            IntPtr gcHandleManager,
            IntPtr gcDacVars)
        {
            return 0;
        }

        [UnmanagedCallersOnly(EntryPoint = "GC_VersionInfo")]
        public static void GC_VersionInfo(
            out VersionInfo result)
        {
            result.MajorVersion = 3;
            result.MinorVersion = 1;
            result.BuildVersion = 0;
            result.Name = Marshal.StringToHGlobalAnsi("CoreRT Zero");
        }
    }
}
