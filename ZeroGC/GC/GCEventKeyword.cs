using System;

namespace ZeroGC
{

    // Event keywords corresponding to events that can be fired by the GC. These
    // numbers come from the ETW manifest itself - please make changes to this enum
    // if you add, remove, or change keyword sets that are used by the GC!
    enum GCEventKeyword
    {
        GCEventKeyword_None = 0x0,
        GCEventKeyword_GC = 0x1,
        // Duplicate on purpose, GCPrivate is the same keyword as GC,
        // with a different provider
        GCEventKeyword_GCPrivate = 0x1,
        GCEventKeyword_GCHandle = 0x2,
        GCEventKeyword_GCHandlePrivate = 0x4000,
        GCEventKeyword_GCHeapDump = 0x100000,
        GCEventKeyword_GCSampledObjectAllocationHigh = 0x200000,
        GCEventKeyword_GCHeapSurvivalAndMovement = 0x400000,
        GCEventKeyword_GCHeapCollect = 0x800000,
        GCEventKeyword_GCHeapAndTypeNames = 0x1000000,
        GCEventKeyword_GCSampledObjectAllocationLow = 0x2000000,
        GCEventKeyword_All = GCEventKeyword_GC
          | GCEventKeyword_GCPrivate
          | GCEventKeyword_GCHandle
          | GCEventKeyword_GCHandlePrivate
          | GCEventKeyword_GCHeapDump
          | GCEventKeyword_GCSampledObjectAllocationHigh
          | GCEventKeyword_GCHeapSurvivalAndMovement
          | GCEventKeyword_GCHeapCollect
          | GCEventKeyword_GCHeapAndTypeNames
          | GCEventKeyword_GCSampledObjectAllocationLow
    }
}
