using System;

namespace ZeroGC
{
    using size_t = nuint;
    using uint64_t = UInt64;
    using uint32_t = UInt32;
    using uintptr_t = nuint;
    using uint8_t = Byte;
    using unsigned = UInt32;
    using int64_t = Int64;
    using PTR_UNCHECKED_OBJECTREF = nuint;
    using PTR_PTR_Object = nint;

    // using HANDLESCANPROC = delegate* unmanaged<PTR_UNCHECKED_OBJECTREF, uintptr_t*, uintptr_t, uintptr_t, void>;
    // using promote_func = delegate* unmanaged<PTR_PTR_Object, ScanContext*, uint32_t, void>;
    // using enum_alloc_context_func = delegate* unmanaged<gc_alloc_context*, void*, void>;

    public unsafe struct IGCToCLR
    {
        internal IGCToCLRVPtr* Vptr;

        internal unsafe struct IGCToCLRVPtr
        {
            public delegate* unmanaged<IGCToCLR*, SUSPEND_REASON, void> SuspendEE;
            public delegate* unmanaged<IGCToCLR*, bool, void> RestartEE;
            public delegate* unmanaged<IGCToCLR*, delegate* unmanaged<PTR_PTR_Object, ScanContext*, uint32_t, void> /*promote_func*/, int, int, ScanContext*, void> GcScanRoots;
            public delegate* unmanaged<IGCToCLR*, int, int, void> GcStartWork;
            public delegate* unmanaged<IGCToCLR*, int, int, ScanContext*, void> AfterGcScanRoots;
            public delegate* unmanaged<IGCToCLR*, void> GcBeforeBGCSweepWork;
            public delegate* unmanaged<IGCToCLR*, int, void> GcDone;
            public delegate* unmanaged<IGCToCLR*, Object, bool> RefCountedHandleCallbacks;
            public delegate* unmanaged<IGCToCLR*, delegate* unmanaged<PTR_UNCHECKED_OBJECTREF, uintptr_t*, uintptr_t, uintptr_t, void> /*HANDLESCANPROC*/, uintptr_t, uintptr_t, void> SyncBlockCacheWeakPtrScan;
            public delegate* unmanaged<IGCToCLR*, int, void> SyncBlockCacheDemote;
            public delegate* unmanaged<IGCToCLR*, int, void> SyncBlockCachePromotionsGranted;
            public delegate* unmanaged<IGCToCLR*, uint32_t> GetActiveSyncBlockCount;
            public delegate* unmanaged<IGCToCLR*, bool> IsPreemptiveGCDisabled;
            public delegate* unmanaged<IGCToCLR*, bool> EnablePreemptiveGC;
            public delegate* unmanaged<IGCToCLR*, void> DisablePreemptiveGC;
            public delegate* unmanaged<IGCToCLR*, IntPtr /*Thread* */> GetThread;
            public delegate* unmanaged<IGCToCLR*, gc_alloc_context*> GetAllocContext;
            public delegate* unmanaged<IGCToCLR*, delegate* unmanaged<gc_alloc_context*, void*, void> /*enum_alloc_context_func*/, void*, void> GcEnumAllocContexts;
            public delegate* unmanaged<IGCToCLR*, Object, uint8_t*> GetLoaderAllocatorObjectForGC;
            public delegate* unmanaged<IGCToCLR*, delegate* unmanaged<void*, void>, void*, bool, byte*, bool> CreateThread;
            public delegate* unmanaged<IGCToCLR*, int, bool, void> DiagGCStart;
            public delegate* unmanaged<IGCToCLR*, void> DiagUpdateGenerationBounds;
            public delegate* unmanaged<IGCToCLR*, size_t, int, int, bool, void> DiagGCEnd;
            public delegate* unmanaged<IGCToCLR*, void*, void> DiagWalkFReachableObjects;
            public delegate* unmanaged<IGCToCLR*, void*, bool, void> DiagWalkSurvivors;
            public delegate* unmanaged<IGCToCLR*, void*, int, void> DiagWalkUOHSurvivors;
            public delegate* unmanaged<IGCToCLR*, void*, void> DiagWalkBGCSurvivors;
            public delegate* unmanaged<IGCToCLR*, WriteBarrierParameters*, void> StompWriteBarrier;
            public delegate* unmanaged<IGCToCLR*, bool, void> EnableFinalization;
            public delegate* unmanaged<IGCToCLR*, unsigned, void> HandleFatalError;
            public delegate* unmanaged<IGCToCLR*, Object, bool> EagerFinalized;
            public delegate* unmanaged<IGCToCLR*, IntPtr /* MethodTable* */> GetFreeObjectMethodTable;
            public delegate* unmanaged<IGCToCLR*, /*const char*/ byte*, /*const char*/byte*, bool*, bool> GetBooleanConfigValue;
            public delegate* unmanaged<IGCToCLR*, /*const char*/ byte*, /*const char*/byte*, int64_t*, bool> GetIntConfigValue;
            public delegate* unmanaged<IGCToCLR*, /*const char*/ byte*, /*const char*/byte*, /*const char**/byte**, bool> GetStringConfigValue;
            public delegate* unmanaged<IGCToCLR*, /*const char*/byte*, void> FreeStringConfigValue;
            public delegate* unmanaged<IGCToCLR*, bool> IsGCThread;
            public delegate* unmanaged<IGCToCLR*, bool> WasCurrentThreadCreatedByGC;
            public delegate* unmanaged<IGCToCLR*, Object, ScanContext*, delegate* unmanaged<PTR_PTR_Object, ScanContext*, uint32_t, void> /*promote_func*/, void> WalkAsyncPinnedForPromotion;
            public delegate* unmanaged<IGCToCLR*, Object, void*, delegate* unmanaged<Object, Object, void*, void>, void> WalkAsyncPinned;
            public delegate* unmanaged<IGCToCLR*, IntPtr /* IGCToCLREventSink* */> EventSink;
            public delegate* unmanaged<IGCToCLR*, uint32_t> GetTotalNumSizedRefHandles;
            public delegate* unmanaged<IGCToCLR*, int, bool> AnalyzeSurvivorsRequested;
            public delegate* unmanaged<IGCToCLR*, size_t, int, uint64_t, delegate* unmanaged<void>, void> AnalyzeSurvivorsFinished;
            public delegate* unmanaged<IGCToCLR*, void> VerifySyncTableEntry;
            public delegate* unmanaged<IGCToCLR*, int, int, int, int, void> UpdateGCEventStatus;
        }
    }
}
