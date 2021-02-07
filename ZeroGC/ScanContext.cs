using System;

namespace ZeroGC
{
    using uintptr_t = nuint;

    unsafe struct ScanContext
    {
        public void* thread_under_crawl;
        public int thread_number;
        public uintptr_t stack_limit; // Lowest point on the thread stack that the scanning logic is permitted to read
        public bool promotion; //TRUE: Promotion, FALSE: Relocation.
        public bool concurrent; //TRUE: concurrent scanning
        public void* _unused1;
        public void* pMD;
        public EtwGCRootKind dwEtwRootKind;
    }
}
