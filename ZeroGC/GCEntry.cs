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
            // E_NOTIMPL
            return unchecked ((int)0x80004001);
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
        [System.Runtime.RuntimeExport("CoreRT_StaticInitialization")]
        IntPtr CoreRT_StaticInitialization()
        {
            return IntPtr.Zero;
        }
#endif
    }
}
