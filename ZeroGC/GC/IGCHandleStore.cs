using System;

namespace ZeroGC
{
    using OBJECTHANDLE = IntPtr;

    public unsafe struct IGCHandleStore
    {
        public IGCHandleStoreVptr* Vptr;

        public struct IGCHandleStoreVptr
        {
            public delegate* unmanaged<IGCHandleStore*, void> Uproot;
            public delegate* unmanaged<IGCHandleStore*, OBJECTHANDLE, bool> ContainsHandle;
            public delegate* unmanaged<IGCHandleStore*, Object, HandleType, OBJECTHANDLE> CreateHandleOfType;
            public delegate* unmanaged<IGCHandleStore*, Object, HandleType, int, OBJECTHANDLE> CreateHandleOfTypeEx;
            public delegate* unmanaged<IGCHandleStore*, Object, HandleType, void*, OBJECTHANDLE> CreateHandleWithExtraInfo;
            public delegate* unmanaged<IGCHandleStore*, Object, Object, OBJECTHANDLE> CreateDependentHandle;
            public delegate* unmanaged<IGCHandleStore*, void> DestructIGCHandleStore;
        }
    }
}
