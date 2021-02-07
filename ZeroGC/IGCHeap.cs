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

    unsafe interface IGCHeap
    {
        bool IsValidSegmentSize(size_t size);
        bool IsValidGen0MaxSize(size_t size);
        size_t GetValidSegmentSize(bool large_seg);
        void SetReservedVMLimit(size_t vmlimit);
        void WaitUntilConcurrentGCComplete();
        bool IsConcurrentGCInProgress();
        void TemporaryEnableConcurrentGC();
        void TemporaryDisableConcurrentGC();
        bool IsConcurrentGCEnabled();
        HRESULT WaitUntilConcurrentGCCompleteAsync(int millisecondsTimeout);
        size_t GetNumberOfFinalizable();
        Object GetNextFinalizable();

        void GetMemoryInfo(uint64_t* highMemLoadThresholdBytes,
            uint64_t* totalAvailableMemoryBytes,
            uint64_t* lastRecordedMemLoadBytes,
            uint64_t* lastRecordedHeapSizeBytes,
            uint64_t* lastRecordedFragmentationBytes,
            uint64_t* totalCommittedBytes,
            uint64_t* promotedBytes,
            uint64_t* pinnedObjectCount,
            uint64_t* finalizationPendingCount,
            uint64_t* index,
            uint32_t* generation,
            uint32_t* pauseTimePct,
            bool* isCompaction,
            bool* isConcurrent,
            uint64_t* genInfoRaw,
            uint64_t* pauseInfoRaw,
            int kind);

        uint32_t GetMemoryLoad();
        int GetGcLatencyMode();
        int SetGcLatencyMode(int newLatencyMode);
        int GetLOHCompactionMode();
        void SetLOHCompactionMode(int newLOHCompactionMode);
        bool RegisterForFullGCNotification(uint32_t gen2Percentage, uint32_t lohPercentage);
        bool CancelFullGCNotification();
        int WaitForFullGCApproach(int millisecondsTimeout);
        int WaitForFullGCComplete(int millisecondsTimeout);
        unsigned WhichGeneration(Object obj);
        int CollectionCount(int generation, int get_bgc_fgc_coutn = 0);
        int StartNoGCRegion(uint64_t totalSize, bool lohSizeKnown, uint64_t lohSize, bool disallowFullBlockingGC);
        int EndNoGCRegion();
        size_t GetTotalBytesInUse();
        uint64_t GetTotalAllocatedBytes();
        HRESULT GarbageCollect(int generation, bool low_memory_p, int mode);
        unsigned GetMaxGeneration();
        void SetFinalizationRun(Object obj);
        bool RegisterForFinalization(int gen, Object obj);
        int GetLastGCPercentTimeInGC();
        size_t GetLastGCGenerationSize(int gen);
        HRESULT Initialize();
        bool IsPromoted(Object @object);
        bool IsHeapPointer(void* @object, bool small_heap_only);
        unsigned GetCondemnedGeneration();
        bool IsGCInProgressHelper(bool bConsiderGCStart);
        unsigned GetGcCount();
        bool IsThreadUsingAllocationContextHeap(gc_alloc_context* acontext, int thread_number);
        bool IsEphemeral(Object @object);
        uint32_t WaitUntilGCComplete(bool bConsiderGCStart);
        void FixAllocContext(gc_alloc_context* acontext, void* arg, void* heap);
        size_t GetCurrentObjSize();
        void SetGCInProgress(bool fInProgress);
        bool RuntimeStructuresValid();
        void SetSuspensionPending(bool fSuspensionPending);
        void SetYieldProcessorScalingFactor(float yieldProcessorScalingFactor);
        void Shutdown();
        size_t GetLastGCStartTime(int generation);
        size_t GetLastGCDuration(int generation);
        size_t GetNow();
        Object Alloc(gc_alloc_context* acontext, size_t size, uint32_t flags);
        void PublishObject(uint8_t* obj);
        void SetWaitForGCEvent();
        void ResetWaitForGCEvent();
        bool IsLargeObject(Object pObj);
        void ValidateObjectMember(Object obj);
        Object NextObj(Object @object);
        Object GetContainingObject(void* pInteriorPtr, bool fCollectedGenOnly);
        void DiagWalkObject(Object obj, delegate* unmanaged<Object, void*, bool> fn, void* context);
        void DiagWalkObject2(Object obj, delegate* unmanaged<Object, byte**, void*, bool> fn, void* context);
        void DiagWalkHeap(delegate* unmanaged<Object, void*, bool> fn, void* context, int gen_number, bool walk_large_object_heap_p);
        void DiagWalkSurvivorsWithType(void* gc_context, delegate* unmanaged<uint8_t*, uint8_t*, ptrdiff_t, void*, bool, bool, void> fn, void* diag_context, walk_surv_type type, int gen_number);
        void DiagWalkFinalizeQueue(void* gc_context, delegate* unmanaged<bool, void*, void> fn);
        void DiagScanFinalizeQueue(delegate* unmanaged<ref Object, ScanContext*, uint32_t, void> fn, ScanContext* context);
        void DiagScanHandles(delegate* unmanaged<ref Object, Object, uint32_t, ScanContext*, bool, void> fn, int gen_number, ScanContext* context);
        void DiagScanDependentHandles(delegate* unmanaged<ref Object, Object, uint32_t, ScanContext*, bool, void> fn, int gen_number, ScanContext* context);
        void DiagDescrGenerations(delegate* unmanaged<void*, int, uint8_t*, uint8_t*, uint8_t*, void> fn, void* context);
        void DiagTraceGCSegments();
        bool StressHeap(gc_alloc_context* acontext);
        gc_heap_segment_stub* RegisterFrozenSegment(segment_info* pseginfo);
        void UnregisterFrozenSegment(gc_heap_segment_stub* seg);
        bool IsInFrozenSegment(Object @object);
        void ControlEvents(GCEventKeyword keyword, GCEventLevel level);
        void ControlPrivateEvents(GCEventKeyword keyword, GCEventLevel level);
        void DestructIGCHeap();
    }
}
