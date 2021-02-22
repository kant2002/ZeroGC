using System;

namespace ZeroGC
{
    using uint8_t = Byte;
    using size_t = nuint;
    using HRESULT = UInt32;
    using unsigned = UInt32;
    using uint64_t = UInt64;
    using uint32_t = UInt32;
    using ptrdiff_t = nuint;

    // using walk_fn = delegate* unmanaged<Object, void*, bool>;
    // using walk_fn2 = delegate* unmanaged<Object, byte**, void*, bool>;
    // using gen_walk_fn = delegate* unmanaged<void*, int, uint8_t*, uint8_t*, uint8_t*, void>;
    // using record_surv_fn = delegate* unmanaged<uint8_t*, uint8_t*, ptrdiff_t, void*, bool, bool, void>;
    // using fq_walk_fn = delegate* unmanaged<bool, void*, void>;
    // using fq_scan_fn = delegate* unmanaged<ref Object, ScanContext*, uint32_t, void>;
    // using handle_scan_fn = delegate* unmanaged<ref Object, Object, uint32_t, ScanContext*, bool, void>;

    public unsafe struct IGCHeap
    {
        public IGCHeapVptr* Vptr;

        public struct IGCHeapVptr
        {
            public delegate* unmanaged<IGCHeap*, size_t, bool> IsValidSegmentSize;
            public delegate* unmanaged<IGCHeap*, size_t, bool> IsValidGen0MaxSize;
            public delegate* unmanaged<IGCHeap*, bool, size_t> GetValidSegmentSize;
            public delegate* unmanaged<IGCHeap*, size_t, void> SetReservedVMLimit;
            public delegate* unmanaged<IGCHeap*, void> WaitUntilConcurrentGCComplete;
            public delegate* unmanaged<IGCHeap*, bool> IsConcurrentGCInProgress;
            public delegate* unmanaged<IGCHeap*, void> TemporaryEnableConcurrentGC;
            public delegate* unmanaged<IGCHeap*, void> TemporaryDisableConcurrentGC;
            public delegate* unmanaged<IGCHeap*, bool> IsConcurrentGCEnabled;
            public delegate* unmanaged<IGCHeap*, int, HRESULT> WaitUntilConcurrentGCCompleteAsync;
            public delegate* unmanaged<IGCHeap*, size_t> GetNumberOfFinalizable;
            public delegate* unmanaged<IGCHeap*, Object> GetNextFinalizable;
            public delegate* unmanaged<IGCHeap*, uint64_t*, uint64_t*, uint64_t*, uint64_t*, uint64_t*, uint64_t*, uint64_t*, uint64_t*, uint64_t*, uint64_t*,
                uint32_t*, uint32_t*, bool*, bool*, uint64_t*, uint64_t*, int, void> GetMemoryInfo;
            public delegate* unmanaged<IGCHeap*, uint32_t> GetMemoryLoad;
            public delegate* unmanaged<IGCHeap*, int> GetGcLatencyMode;
            public delegate* unmanaged<IGCHeap*, int, int> SetGcLatencyMode;
            public delegate* unmanaged<IGCHeap*, int> GetLOHCompactionMode;
            public delegate* unmanaged<IGCHeap*, int, void> SetLOHCompactionMode;
            public delegate* unmanaged<IGCHeap*, uint32_t, uint32_t, bool> RegisterForFullGCNotification;
            public delegate* unmanaged<IGCHeap*, bool> CancelFullGCNotification;
            public delegate* unmanaged<IGCHeap*, int, int> WaitForFullGCApproach;
            public delegate* unmanaged<IGCHeap*, int, int> WaitForFullGCComplete;
            public delegate* unmanaged<IGCHeap*, Object, unsigned> WhichGeneration;
            public delegate* unmanaged<IGCHeap*, int, int, int> CollectionCount;
            public delegate* unmanaged<IGCHeap*, uint64_t, bool, uint64_t, bool, int> StartNoGCRegion;
            public delegate* unmanaged<IGCHeap*, int> EndNoGCRegion;
            public delegate* unmanaged<IGCHeap*, size_t> GetTotalBytesInUse;
            public delegate* unmanaged<IGCHeap*, uint64_t> GetTotalAllocatedBytes;
            public delegate* unmanaged<IGCHeap*, int, bool, int, HRESULT> GarbageCollect;
            public delegate* unmanaged<IGCHeap*, unsigned> GetMaxGeneration;
            public delegate* unmanaged<IGCHeap*, Object, void> SetFinalizationRun;
            public delegate* unmanaged<IGCHeap*, int, Object, bool> RegisterForFinalization;
            public delegate* unmanaged<IGCHeap*, int> GetLastGCPercentTimeInGC;
            public delegate* unmanaged<IGCHeap*, int, size_t> GetLastGCGenerationSize;
            public delegate* unmanaged<IGCHeap*, HRESULT> Initialize;
            public delegate* unmanaged<IGCHeap*, Object, bool> IsPromoted;
            public delegate* unmanaged<IGCHeap*, void*, bool, bool> IsHeapPointer;
            public delegate* unmanaged<IGCHeap*, unsigned> GetCondemnedGeneration;
            public delegate* unmanaged<IGCHeap*, bool, bool> IsGCInProgressHelper;
            public delegate* unmanaged<IGCHeap*, unsigned> GetGcCount;
            public delegate* unmanaged<IGCHeap*, gc_alloc_context*, int, bool> IsThreadUsingAllocationContextHeap;
            public delegate* unmanaged<IGCHeap*, Object, bool> IsEphemeral;
            public delegate* unmanaged<IGCHeap*, bool, uint32_t> WaitUntilGCComplete;
            public delegate* unmanaged<IGCHeap*, gc_alloc_context*, void*, void*, void> FixAllocContext;
            public delegate* unmanaged<IGCHeap*, uint32_t> GetCurrentObjSize;
            public delegate* unmanaged<IGCHeap*, bool, void> SetGCInProgress;
            public delegate* unmanaged<IGCHeap*, bool> RuntimeStructuresValid;
            public delegate* unmanaged<IGCHeap*, bool, void> SetSuspensionPending;
            public delegate* unmanaged<IGCHeap*, float, void> SetYieldProcessorScalingFactor;
            public delegate* unmanaged<IGCHeap*, void> Shutdown;
            public delegate* unmanaged<IGCHeap*, int, size_t> GetLastGCStartTime;
            public delegate* unmanaged<IGCHeap*, int, size_t> GetLastGCDuration;
            public delegate* unmanaged<IGCHeap*, size_t> GetNow;
            public delegate* unmanaged<IGCHeap*, gc_alloc_context*, size_t, uint32_t, Object> Alloc;
            public delegate* unmanaged<IGCHeap*, uint8_t*, void> PublishObject;
            public delegate* unmanaged<IGCHeap*, void> SetWaitForGCEvent;
            public delegate* unmanaged<IGCHeap*, void> ResetWaitForGCEvent;
            public delegate* unmanaged<IGCHeap*, Object, bool> IsLargeObject;
            public delegate* unmanaged<IGCHeap*, Object, void> ValidateObjectMember;
            public delegate* unmanaged<IGCHeap*, Object, Object> NextObj;
            public delegate* unmanaged<IGCHeap*, void*, bool, Object> GetContainingObject;
            public delegate* unmanaged<IGCHeap*, Object, delegate* unmanaged<Object, void*, bool>, void*, void> DiagWalkObject;
            public delegate* unmanaged<IGCHeap*, Object, delegate* unmanaged<Object, byte**, void*, bool>, void*, void> DiagWalkObject;
            public delegate* unmanaged<IGCHeap*, delegate* unmanaged<Object, void*, bool>, void*, int, bool, void> DiagWalkHeap;
            public delegate* unmanaged<IGCHeap*, void*, delegate* unmanaged<uint8_t*, uint8_t*, ptrdiff_t, void*, bool, bool, void>, void*, walk_surv_type, int, void> DiagWalkSurvivorsWithType;
            public delegate* unmanaged<IGCHeap*, void*, delegate* unmanaged<bool, void*, void>, void> DiagWalkFinalizeQueue;
            public delegate* unmanaged<IGCHeap*, delegate* unmanaged<ref Object, ScanContext*, uint32_t, void>, ScanContext*, void> DiagScanFinalizeQueue;
            public delegate* unmanaged<IGCHeap*, delegate* unmanaged<ref Object, Object, uint32_t, ScanContext*, bool, void>, int, ScanContext*, void> DiagScanHandles;
            public delegate* unmanaged<IGCHeap*, delegate* unmanaged<ref Object, Object, uint32_t, ScanContext*, bool, void>, int, ScanContext*, void> DiagScanDependentHandles;
            public delegate* unmanaged<IGCHeap*, delegate* unmanaged<void*, int, uint8_t*, uint8_t*, uint8_t*, void>, void*, void> DiagDescrGenerations;
            public delegate* unmanaged<IGCHeap*, void> DiagTraceGCSegments;
            public delegate* unmanaged<IGCHeap*, gc_alloc_context*, bool> StressHeap;
            public delegate* unmanaged<IGCHeap*, segment_info*, gc_heap_segment_stub*> RegisterFrozenSegment;
            public delegate* unmanaged<IGCHeap*, gc_heap_segment_stub*, void*> UnregisterFrozenSegment;
            public delegate* unmanaged<IGCHeap*, Object, bool> IsInFrozenSegment;
            public delegate* unmanaged<IGCHeap*, GCEventKeyword, GCEventLevel, void> ControlEvents;
            public delegate* unmanaged<IGCHeap*, GCEventKeyword, GCEventLevel, void> ControlPrivateEvents;
            public delegate* unmanaged<IGCHeap*, void> DestructIGCHeap;
        }
    }
}
