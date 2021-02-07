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

    unsafe interface IGCToCLR
    {
        void SuspendEE(SUSPEND_REASON reason);
        void RestartEE(bool bFinishedGC);
        void GcScanRoots(delegate* unmanaged<PTR_PTR_Object, ScanContext*, uint32_t, void> fn, int condemned, int max_gen, ScanContext* sc);
        void GcStartWork(int condemned, int max_gen);
        void AfterGcScanRoots(int condemned, int max_gen, ScanContext* sc);
        void GcBeforeBGCSweepWork();
        void GcDone(int condemned);
        bool RefCountedHandleCallbacks(Object pObject);
        void SyncBlockCacheWeakPtrScan(delegate* unmanaged<PTR_UNCHECKED_OBJECTREF, uintptr_t*, uintptr_t, uintptr_t, void> scanProc, uintptr_t lp1, uintptr_t lp2);
        void SyncBlockCacheDemote(int max_gen);
        void SyncBlockCachePromotionsGranted(int max_gen);
        uint32_t GetActiveSyncBlockCount();
        bool IsPreemptiveGCDisabled();
        bool EnablePreemptiveGC();
        void DisablePreemptiveGC();
        IntPtr /*Thread* */ GetThread();
        gc_alloc_context* GetAllocContext();
        void GcEnumAllocContexts(delegate* unmanaged<gc_alloc_context*, void*, void> fn, void* param);
        uint8_t* GetLoaderAllocatorObjectForGC(Object pObject);
        bool CreateThread(delegate* unmanaged<void*, void> threadStart, void* arg, bool is_suspendable, byte* name);
        void DiagGCStart(int gen, bool isInduced);
        void DiagUpdateGenerationBounds();
        void DiagGCEnd(size_t index, int gen, int reason, bool fConcurrent);
        void DiagWalkFReachableObjects(void* gcContext);
        void DiagWalkSurvivors(void* gcContext, bool fCompacting);
        void DiagWalkUOHSurvivors(void* gcContext, int gen);
        void DiagWalkBGCSurvivors(void* gcContext);
        void StompWriteBarrier(WriteBarrierParameters* args);
        void EnableFinalization(bool foundFinalizers);
        void HandleFatalError(unsigned exitCode);
        bool EagerFinalized(Object obj);
        IntPtr /* MethodTable* */ GetFreeObjectMethodTable();
        bool GetBooleanConfigValue(/*const char*/byte* privateKey, /*const char*/byte* publicKey, bool* value);
        bool GetIntConfigValue(/*const char*/byte* privateKey, /*const char*/byte* publicKey, int64_t* value);
        bool GetStringConfigValue(/*const char*/byte* privateKey, /*const char*/byte* publicKey, /*const char*/byte** value);
        void FreeStringConfigValue(/*const char*/byte* value);
        bool IsGCThread();
        bool WasCurrentThreadCreatedByGC();
        void WalkAsyncPinnedForPromotion(Object @object, ScanContext* sc, delegate* unmanaged<PTR_PTR_Object, ScanContext*, uint32_t, void> callback);
        void WalkAsyncPinned(Object @object, void* context, delegate* unmanaged<Object, Object, void*, void> callback);
        IntPtr /* IGCToCLREventSink* */ EventSink();
        uint32_t GetTotalNumSizedRefHandles();
        bool AnalyzeSurvivorsRequested(int condemnedGeneration);
        void AnalyzeSurvivorsFinished(size_t gcIndex, int condemnedGeneration, uint64_t promoted_bytes, delegate* unmanaged<void> reportGenerationBounds);
        void VerifySyncTableEntry();
        void UpdateGCEventStatus(int publicLevel, int publicKeywords, int privateLEvel, int privateKeywords);
    }
}
