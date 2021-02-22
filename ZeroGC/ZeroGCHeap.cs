using System;
using System.Runtime.InteropServices;

namespace ZeroGC
{
    using uint8_t = Byte;
    using size_t = nuint;
    using HRESULT = UInt32;
    using unsigned = UInt32;
    using uint64_t = UInt64;
    using uint32_t = UInt32;
    using ptrdiff_t = nuint;

    public unsafe struct ZeroGCHeap
    {
        public IGCHeap parent;

        public IGCToCLR* gcToCLR;

        static IGCHeap.IGCHeapVptr Vptr;

        public ZeroGCHeap(IGCToCLR* gcToCLR)
        {
            this.gcToCLR = gcToCLR;
            this.parent = new IGCHeap();
            fixed (IGCHeap.IGCHeapVptr* vptr = &Vptr)
                this.parent.Vptr = vptr;

            this.parent.Vptr->IsValidSegmentSize = &IsValidSegmentSize;
            this.parent.Vptr->IsValidGen0MaxSize = &IsValidGen0MaxSize;
            this.parent.Vptr->GetValidSegmentSize = &GetValidSegmentSize;
            this.parent.Vptr->SetReservedVMLimit = &SetReservedVMLimit;
            this.parent.Vptr->WaitUntilConcurrentGCComplete = &WaitUntilConcurrentGCComplete;
            this.parent.Vptr->IsConcurrentGCInProgress = &IsConcurrentGCInProgress;
            this.parent.Vptr->TemporaryEnableConcurrentGC = &TemporaryEnableConcurrentGC;
            this.parent.Vptr->TemporaryDisableConcurrentGC = &TemporaryDisableConcurrentGC;
            this.parent.Vptr->IsConcurrentGCEnabled = &IsConcurrentGCEnabled;
            this.parent.Vptr->WaitUntilConcurrentGCCompleteAsync = &WaitUntilConcurrentGCCompleteAsync;
            this.parent.Vptr->GetNumberOfFinalizable = &GetNumberOfFinalizable;
            this.parent.Vptr->GetNextFinalizable = &GetNextFinalizable;
            this.parent.Vptr->GetMemoryInfo = &GetMemoryInfo;
            this.parent.Vptr->GetGcLatencyMode = &GetGcLatencyMode;
            this.parent.Vptr->SetGcLatencyMode = &SetGcLatencyMode;
            this.parent.Vptr->GetLOHCompactionMode = &GetLOHCompactionMode;
            this.parent.Vptr->SetLOHCompactionMode = &SetLOHCompactionMode;
            this.parent.Vptr->RegisterForFullGCNotification = &RegisterForFullGCNotification;
            this.parent.Vptr->CancelFullGCNotification = &CancelFullGCNotification;
            this.parent.Vptr->WaitForFullGCApproach = &WaitForFullGCApproach;
            this.parent.Vptr->WaitForFullGCComplete = &WaitForFullGCComplete;
            this.parent.Vptr->WhichGeneration = &WhichGeneration;
            this.parent.Vptr->CollectionCount = &CollectionCount;
            this.parent.Vptr->StartNoGCRegion = &StartNoGCRegion;
            this.parent.Vptr->EndNoGCRegion = &EndNoGCRegion;
            this.parent.Vptr->GetTotalBytesInUse = &GetTotalBytesInUse;
            this.parent.Vptr->GetTotalAllocatedBytes = &GetTotalAllocatedBytes;
            this.parent.Vptr->GarbageCollect = &GarbageCollect;
            this.parent.Vptr->GetMaxGeneration = &GetMaxGeneration;
            this.parent.Vptr->SetFinalizationRun = &SetFinalizationRun;
            this.parent.Vptr->RegisterForFinalization = &RegisterForFinalization;
            this.parent.Vptr->GetLastGCPercentTimeInGC = &GetLastGCPercentTimeInGC;
            this.parent.Vptr->GetLastGCGenerationSize = &GetLastGCGenerationSize;
            this.parent.Vptr->Initialize = &Initialize;
            this.parent.Vptr->IsPromoted = &IsPromoted;
            this.parent.Vptr->IsHeapPointer = &IsHeapPointer;
            this.parent.Vptr->GetCondemnedGeneration = &GetCondemnedGeneration;
            this.parent.Vptr->IsGCInProgressHelper = &IsGCInProgressHelper;
            this.parent.Vptr->GetGcCount = &GetGcCount;
            this.parent.Vptr->IsThreadUsingAllocationContextHeap = &IsThreadUsingAllocationContextHeap;
            this.parent.Vptr->IsEphemeral = &IsEphemeral;
            this.parent.Vptr->WaitUntilGCComplete = &WaitUntilGCComplete;
            this.parent.Vptr->FixAllocContext = &FixAllocContext;
            this.parent.Vptr->GetCurrentObjSize = &GetCurrentObjSize;
            this.parent.Vptr->SetGCInProgress = &SetGCInProgress;
            this.parent.Vptr->RuntimeStructuresValid = &RuntimeStructuresValid;
            this.parent.Vptr->SetSuspensionPending = &SetSuspensionPending;
            this.parent.Vptr->SetYieldProcessorScalingFactor = &SetYieldProcessorScalingFactor;
            this.parent.Vptr->Shutdown = &Shutdown;
            this.parent.Vptr->GetLastGCStartTime = &GetLastGCStartTime;
            this.parent.Vptr->GetLastGCDuration = &GetLastGCDuration;
            this.parent.Vptr->GetNow = &GetNow;
            this.parent.Vptr->Alloc = &Alloc;
            this.parent.Vptr->PublishObject = &PublishObject;
            this.parent.Vptr->SetWaitForGCEvent = &SetWaitForGCEvent;
            this.parent.Vptr->ResetWaitForGCEvent = &ResetWaitForGCEvent;
            this.parent.Vptr->IsLargeObject = &IsLargeObject;
            this.parent.Vptr->ValidateObjectMember = &ValidateObjectMember;
            this.parent.Vptr->NextObj = &NextObj;
            this.parent.Vptr->GetContainingObject = &GetContainingObject;
            this.parent.Vptr->DiagWalkObject = &DiagWalkObject;
            this.parent.Vptr->DiagWalkObject2 = &DiagWalkObject2;
            this.parent.Vptr->DiagWalkHeap = &DiagWalkHeap;
            this.parent.Vptr->DiagWalkSurvivorsWithType = &DiagWalkSurvivorsWithType;
            this.parent.Vptr->DiagWalkFinalizeQueue = &DiagWalkFinalizeQueue;
            this.parent.Vptr->DiagScanFinalizeQueue = &DiagScanFinalizeQueue;
            this.parent.Vptr->DiagScanHandles = &DiagScanHandles;
            this.parent.Vptr->DiagScanDependentHandles = &DiagScanDependentHandles;
            this.parent.Vptr->DiagDescrGenerations = &DiagDescrGenerations;
            this.parent.Vptr->DiagTraceGCSegments = &DiagTraceGCSegments;
            this.parent.Vptr->StressHeap = &StressHeap;
            this.parent.Vptr->RegisterFrozenSegment = &RegisterFrozenSegment;
            this.parent.Vptr->UnregisterFrozenSegment = &UnregisterFrozenSegment;
            this.parent.Vptr->IsInFrozenSegment = &IsInFrozenSegment;
            this.parent.Vptr->ControlEvents = &ControlEvents;
            this.parent.Vptr->ControlPrivateEvents = &ControlPrivateEvents;
            this.parent.Vptr->SetSuspensionPending = &SetSuspensionPending;
            this.parent.Vptr->DestructIGCHeap = &DestructIGCHeap;
        }

        [UnmanagedCallersOnly]
        static bool IsValidSegmentSize(IGCHeap* pThis, size_t size)
        {
            return false;
        }
        [UnmanagedCallersOnly]
        static bool IsValidGen0MaxSize(IGCHeap* pThis, size_t size)
        {
            return false;
        }
        [UnmanagedCallersOnly]
        static size_t GetValidSegmentSize(IGCHeap* pThis, bool large_seg)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static void SetReservedVMLimit(IGCHeap* pThis, size_t vmlimit)
        {
        }
        [UnmanagedCallersOnly]
        static void WaitUntilConcurrentGCComplete(IGCHeap* pThis)
        {
        }
        [UnmanagedCallersOnly]
        static bool IsConcurrentGCInProgress(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static void TemporaryEnableConcurrentGC(IGCHeap* pThis)
        {
        }
        [UnmanagedCallersOnly]
        static void TemporaryDisableConcurrentGC(IGCHeap* pThis)
        {
        }
        [UnmanagedCallersOnly]
        static bool IsConcurrentGCEnabled(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static HRESULT WaitUntilConcurrentGCCompleteAsync(IGCHeap* pThis, int millisecondsTimeout)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static size_t GetNumberOfFinalizable(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static IntPtr GetNextFinalizable(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static void GetMemoryInfo(IGCHeap* pThis, 
            uint64_t* highMemLoadThresholdBytes,
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
            int kind)
        {
        }

        [UnmanagedCallersOnly]
        static uint32_t GetMemoryLoad(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static int GetGcLatencyMode(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static int SetGcLatencyMode(IGCHeap* pThis, int newLatencyMode)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static int GetLOHCompactionMode(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static void SetLOHCompactionMode(IGCHeap* pThis, int newLOHCompactionMode)
        {
        }
        [UnmanagedCallersOnly]
        static bool RegisterForFullGCNotification(IGCHeap* pThis, uint32_t gen2Percentage, uint32_t lohPercentage)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static bool CancelFullGCNotification(IGCHeap* pThis)
        {
            return false;
        }
        [UnmanagedCallersOnly]
        static int WaitForFullGCApproach(IGCHeap* pThis, int millisecondsTimeout)
        {
            return 0;
        }
        [UnmanagedCallersOnly]
        static int WaitForFullGCComplete(IGCHeap* pThis, int millisecondsTimeout)
        {
            return 0;
        }
        [UnmanagedCallersOnly]
        static unsigned WhichGeneration(IGCHeap* pThis, IntPtr obj)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static int CollectionCount(IGCHeap* pThis, int generation, int get_bgc_fgc_coutn = 0)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static int StartNoGCRegion(IGCHeap* pThis, uint64_t totalSize, bool lohSizeKnown, uint64_t lohSize, bool disallowFullBlockingGC)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static int EndNoGCRegion(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static size_t GetTotalBytesInUse(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static uint64_t GetTotalAllocatedBytes(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static HRESULT GarbageCollect(IGCHeap* pThis, int generation, bool low_memory_p, int mode)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static unsigned GetMaxGeneration(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static void SetFinalizationRun(IGCHeap* pThis, IntPtr obj)
        {
        }
        [UnmanagedCallersOnly]
        static bool RegisterForFinalization(IGCHeap* pThis, int gen, IntPtr obj)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static int GetLastGCPercentTimeInGC(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static size_t GetLastGCGenerationSize(IGCHeap* pThis, int gen)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static HRESULT Initialize(IGCHeap* pThis)
        {
            // Not used currently
            //MethodTable* freeObjectMethodTable = gcToCLR->GetFreeObjectMethodTable();

            //WriteBarrierParameters args = { };
            //args.operation = WriteBarrierOp::Initialize;
            //args.is_runtime_suspended = true;
            //args.requires_upper_bounds_check = false;
            //args.card_table = new uint32_t[1];
            //args.lowest_address = reinterpret_cast<uint8_t*>(~0); ;
            //args.highest_address = reinterpret_cast<uint8_t*>(1);
            //args.ephemeral_low = reinterpret_cast<uint8_t*>(~0);
            //args.ephemeral_high = reinterpret_cast<uint8_t*>(1);
            //gcToCLR->StompWriteBarrier(&args);

            //return NOERROR;

            return default;
        }
        [UnmanagedCallersOnly]
        static bool IsPromoted(IGCHeap* pThis, IntPtr @object)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static bool IsHeapPointer(IGCHeap* pThis, void* @object, bool small_heap_only)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static unsigned GetCondemnedGeneration(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static bool IsGCInProgressHelper(IGCHeap* pThis, bool bConsiderGCStart)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static unsigned GetGcCount(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static bool IsThreadUsingAllocationContextHeap(IGCHeap* pThis, gc_alloc_context* acontext, int thread_number)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static bool IsEphemeral(IGCHeap* pThis, IntPtr @object)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static uint32_t WaitUntilGCComplete(IGCHeap* pThis, bool bConsiderGCStart)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static void FixAllocContext(IGCHeap* pThis, gc_alloc_context* acontext, void* arg, void* heap)
        {
        }
        [UnmanagedCallersOnly]
        static size_t GetCurrentObjSize(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static void SetGCInProgress(IGCHeap* pThis, bool fInProgress)
        {
        }
        [UnmanagedCallersOnly]
        static bool RuntimeStructuresValid(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static void SetSuspensionPending(IGCHeap* pThis, bool fSuspensionPending)
        {
        }
        [UnmanagedCallersOnly]
        static void SetYieldProcessorScalingFactor(IGCHeap* pThis, float yieldProcessorScalingFactor)
        {
        }
        [UnmanagedCallersOnly]
        static void Shutdown(IGCHeap* pThis)
        {
        }
        [UnmanagedCallersOnly]
        static size_t GetLastGCStartTime(IGCHeap* pThis, int generation)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static size_t GetLastGCDuration(IGCHeap* pThis, int generation)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static size_t GetNow(IGCHeap* pThis)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static IntPtr Alloc(IGCHeap* pThis, gc_alloc_context* acontext, size_t size, uint32_t flags)
        {
            //int sizeWithHeader = size + sizeof(ObjHeader);
            //ObjHeader* address = (ObjHeader*)calloc(sizeWithHeader, sizeof(char));
            //return (Object*)(address + 1);

            return default;
        }
        [UnmanagedCallersOnly]
        static void PublishObject(IGCHeap* pThis, uint8_t* obj)
        {
        }
        [UnmanagedCallersOnly]
        static void SetWaitForGCEvent(IGCHeap* pThis)
        {
        }
        [UnmanagedCallersOnly]
        static void ResetWaitForGCEvent(IGCHeap* pThis)
        {
        }
        [UnmanagedCallersOnly]
        static bool IsLargeObject(IGCHeap* pThis, IntPtr pObj)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static void ValidateObjectMember(IGCHeap* pThis, IntPtr obj)
        {
        }
        [UnmanagedCallersOnly]
        static IntPtr NextObj(IGCHeap* pThis, IntPtr @object)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static IntPtr GetContainingObject(IGCHeap* pThis, void* pInteriorPtr, bool fCollectedGenOnly)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static void DiagWalkObject(IGCHeap* pThis, IntPtr obj, delegate* unmanaged<IntPtr, void*, bool> fn, void* context)
        {
        }
        [UnmanagedCallersOnly]
        static void DiagWalkObject2(IGCHeap* pThis, IntPtr obj, delegate* unmanaged<IntPtr, byte**, void*, bool> fn, void* context)
        {
        }
        [UnmanagedCallersOnly]
        static void DiagWalkHeap(IGCHeap* pThis, delegate* unmanaged<IntPtr, void*, bool> fn, void* context, int gen_number, bool walk_large_object_heap_p)
        {
        }
        [UnmanagedCallersOnly]
        static void DiagWalkSurvivorsWithType(IGCHeap* pThis, void* gc_context, delegate* unmanaged<uint8_t*, uint8_t*, ptrdiff_t, void*, bool, bool, void> fn, void* diag_context, walk_surv_type type, int gen_number)
        {
        }
        [UnmanagedCallersOnly]
        static void DiagWalkFinalizeQueue(IGCHeap* pThis, void* gc_context, delegate* unmanaged<bool, void*, void> fn)
        {
        }
        [UnmanagedCallersOnly]
        static void DiagScanFinalizeQueue(IGCHeap* pThis, delegate* unmanaged<IntPtr*, ScanContext*, uint32_t, void> fn, ScanContext* context)
        {
        }
        [UnmanagedCallersOnly]
        static void DiagScanHandles(IGCHeap* pThis, delegate* unmanaged<IntPtr*, IntPtr, uint32_t, ScanContext*, bool, void> fn, int gen_number, ScanContext* context)
        {
        }
        [UnmanagedCallersOnly]
        static void DiagScanDependentHandles(IGCHeap* pThis, delegate* unmanaged<IntPtr*, IntPtr, uint32_t, ScanContext*, bool, void> fn, int gen_number, ScanContext* context)
        {
        }
        [UnmanagedCallersOnly]
        static void DiagDescrGenerations(IGCHeap* pThis, delegate* unmanaged<void*, int, uint8_t*, uint8_t*, uint8_t*, void> fn, void* context)
        {
        }
        [UnmanagedCallersOnly]
        static void DiagTraceGCSegments(IGCHeap* pThis)
        {
        }
        [UnmanagedCallersOnly]
        static bool StressHeap(IGCHeap* pThis, gc_alloc_context* acontext)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static gc_heap_segment_stub* RegisterFrozenSegment(IGCHeap* pThis, segment_info* pseginfo)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static void UnregisterFrozenSegment(IGCHeap* pThis, gc_heap_segment_stub* seg)
        {
        }
        [UnmanagedCallersOnly]
        static bool IsInFrozenSegment(IGCHeap* pThis, IntPtr @object)
        {
            return default;
        }
        [UnmanagedCallersOnly]
        static void ControlEvents(IGCHeap* pThis, GCEventKeyword keyword, GCEventLevel level)
        {
        }
        [UnmanagedCallersOnly]
        static void ControlPrivateEvents(IGCHeap* pThis, GCEventKeyword keyword, GCEventLevel level)
        {
        }
        [UnmanagedCallersOnly]
        static void DestructIGCHeap(IGCHeap* pThis)
        {
        }

    }
}
