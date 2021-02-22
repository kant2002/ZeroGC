using System;

namespace ZeroGC
{
    using uintptr_t = nuint;
    using PTR_UNCHECKED_OBJECTREF = nuint;
    using OBJECTHANDLE = IntPtr;

    // using HANDLESCANPROC = delegate* unmanaged<PTR_UNCHECKED_OBJECTREF, uintptr_t*, uintptr_t, uintptr_t, void>;

    public unsafe struct IGCHandleManager
    {
        public IGCHandleManagerVptr* Vptr;

        public struct IGCHandleManagerVptr
        {
            public delegate* unmanaged<IGCHandleManager*, bool> Initialize;
            public delegate* unmanaged<IGCHandleManager*, void> Shutdown;
            public delegate* unmanaged<IGCHandleManager*, IGCHandleStore*> GetGlobalHandleStore;
            public delegate* unmanaged<IGCHandleManager*, IGCHandleStore*> CreateHandleStore;
            public delegate* unmanaged<IGCHandleManager*, IGCHandleStore*, void> DestroyHandleStore;
            public delegate* unmanaged<IGCHandleManager*, Object, HandleType, OBJECTHANDLE> CreateGlobalHandleOfType;
            public delegate* unmanaged<IGCHandleManager*, OBJECTHANDLE, OBJECTHANDLE> CreateDuplicateHandle;
            public delegate* unmanaged<IGCHandleManager*, OBJECTHANDLE, HandleType, void> DestroyHandleOfType;
            public delegate* unmanaged<IGCHandleManager*, OBJECTHANDLE, void> DestroyHandleOfUnknownType;
            public delegate* unmanaged<IGCHandleManager*, OBJECTHANDLE, HandleType, void*, void> SetExtraInfoForHandle;
            public delegate* unmanaged<IGCHandleManager*, OBJECTHANDLE, void*> GetExtraInfoFromHandle;
            public delegate* unmanaged<IGCHandleManager*, OBJECTHANDLE, Object, void> StoreObjectInHandle;
            public delegate* unmanaged<IGCHandleManager*, OBJECTHANDLE, Object, bool> StoreObjectInHandleIfNull;
            public delegate* unmanaged<IGCHandleManager*, OBJECTHANDLE, Object, void> SetDependentHandleSecondary;
            public delegate* unmanaged<IGCHandleManager*, OBJECTHANDLE, Object> GetDependentHandleSecondary;
            public delegate* unmanaged<IGCHandleManager*, OBJECTHANDLE, Object, Object, Object> InterlockedCompareExchangeObjectInHandle;
            public delegate* unmanaged<IGCHandleManager*, OBJECTHANDLE, HandleType> HandleFetchType;
            public delegate* unmanaged<IGCHandleManager*, delegate* unmanaged<PTR_UNCHECKED_OBJECTREF, uintptr_t*, uintptr_t, uintptr_t, void> /*HANDLESCANPROC*/, uintptr_t, uintptr_t, void> TraceRefCountedHandles;
        }
    }
}
