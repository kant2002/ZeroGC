using System;

namespace ZeroGC
{
    using uintptr_t = nuint;
    using PTR_UNCHECKED_OBJECTREF = nuint;
    using OBJECTHANDLE = IntPtr;

    // using HANDLESCANPROC = delegate* unmanaged<PTR_UNCHECKED_OBJECTREF, uintptr_t*, uintptr_t, uintptr_t, void>;

    unsafe interface IGCHandleManager
    {
        bool Initialize();
        void Shutdown();
        IGCHandleStore GetGlobalHandleStore();
        IGCHandleStore CreateHandleStore();
        void DestroyHandleStore(IGCHandleStore store);
        OBJECTHANDLE CreateGlobalHandleOfType(Object @object, HandleType type);
        OBJECTHANDLE CreateDuplicateHandle(OBJECTHANDLE handle);
        void DestroyHandleOfType(OBJECTHANDLE handle, HandleType type);
        void DestroyHandleOfUnknownType(OBJECTHANDLE handle);
        void SetExtraInfoForHandle(OBJECTHANDLE handle, HandleType type, void* pExtraInfo);
        void* GetExtraInfoFromHandle(OBJECTHANDLE handle);
        void StoreObjectInHandle(OBJECTHANDLE handle, Object @object);
        bool StoreObjectInHandleIfNull(OBJECTHANDLE handle, Object @object);
        void SetDependentHandleSecondary(OBJECTHANDLE handle, Object @object);
        Object GetDependentHandleSecondary(OBJECTHANDLE handle);
        Object InterlockedCompareExchangeObjectInHandle(OBJECTHANDLE handle, Object @object, Object comparandObject);
        HandleType HandleFetchType(OBJECTHANDLE handle);
        void TraceRefCountedHandles(delegate* unmanaged<PTR_UNCHECKED_OBJECTREF, uintptr_t*, uintptr_t, uintptr_t, void> callback, uintptr_t param1, uintptr_t param2);
    }
}
