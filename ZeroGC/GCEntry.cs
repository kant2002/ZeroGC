using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ZeroGC
{
    public static class GCEntry
    {
        public static ZeroGCHeap globalGcHeap;

        [UnmanagedCallersOnly(EntryPoint = "GC_Initialize", CallConvs = new Type[] { typeof(CallConvStdcall) })]
        public unsafe static int GC_Initialize(
            IGCToCLR* clrToGC,
            IGCHeap* gcHeap,
            IGCHandleManager* gcHandleManager,
            GcDacVars* gcDacVars)
        {
            globalGcHeap = new ZeroGCHeap(clrToGC);
            fixed (IGCHeap* gHeap = &globalGcHeap.parent)
                gcHeap = gHeap;

            // E_NOTIMPL
            return 0;
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
        static IntPtr CoreRT_StaticInitialization()
        {
            return IntPtr.Zero;
        }
#endif
    }
}
