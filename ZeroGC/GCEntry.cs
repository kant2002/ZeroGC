using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZeroGC
{
    public class GCEntry
    {
        [UnmanagedCallersOnly(EntryPoint = "GC_Initialize", CallConvs = new Type[] { typeof(CallConvStdcall) })]
        public static int GC_Initialize(
            IntPtr /* IGCToCLR */ clrToGC,
            ref IntPtr gcHeap, /* ref IGCHeap */
            ref IntPtr gcHandleManager, /*ref IGCHandleManager */
            ref GcDacVars gcDacVars)
        {
            return -1;
        }

        [UnmanagedCallersOnly(EntryPoint = "GC_VersionInfo", CallConvs = new Type[] { typeof(CallConvStdcall) })]
        public unsafe static void GC_VersionInfo(
            VersionInfo* result
            )
        {
            result->MajorVersion = 4;
            result->MinorVersion = 1;
            result->BuildVersion = 0;
        }

#if MINI_RUNTIME
        [UnmanagedCallersOnly(EntryPoint = "_DllMainCRTStartup", CallConvs = new Type[] { typeof(CallConvStdcall) })]
        static unsafe int _DllMainCRTStartup(IntPtr handle, uint dwReason, IntPtr lpreserved)
        {
            return 1;
        }

        [System.Runtime.RuntimeExport("CoreRT_StaticInitialization")]
        IntPtr CoreRT_StaticInitialization()
        {
            return IntPtr.Zero;
        }
#endif
    }
}
