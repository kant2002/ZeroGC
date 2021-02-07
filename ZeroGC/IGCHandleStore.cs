using System;

namespace ZeroGC
{
    using OBJECTHANDLE = IntPtr;
    unsafe interface IGCHandleStore
    {
        void Uproot();
        bool ContainsHandle(OBJECTHANDLE handle);
        OBJECTHANDLE CreateHandleOfType(Object @object, HandleType type);
        OBJECTHANDLE CreateHandleOfType(Object @object, HandleType type, int heapToAffinitizeTo);
        OBJECTHANDLE CreateHandleWithExtraInfo(Object @object, HandleType type, void* pExtraInfo);
        OBJECTHANDLE CreateDependentHandle(Object primary, Object secondary);

        void DestructIGCHandleStore();
    }
}
