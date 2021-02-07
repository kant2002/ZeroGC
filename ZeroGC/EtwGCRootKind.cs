using System;

namespace ZeroGC
{
    enum EtwGCRootKind
    {
        kEtwGCRootKindStack = 0,
        kEtwGCRootKindFinalizer = 1,
        kEtwGCRootKindHandle = 2,
        kEtwGCRootKindOther = 3,
    }
}
