using System;

namespace ZeroGC
{
    using size_t = nuint;

    public unsafe struct segment_info
    {
        public void* pvMem; // base of the allocation, not the first object (must add ibFirstObject)
        public size_t ibFirstObject;   // offset to the base of the first object in the segment
        public size_t ibAllocated; // limit of allocated memory in the segment (>= firstobject)
        public size_t ibCommit; // limit of committed memory in the segment (>= allocated)
        public size_t ibReserved; // limit of reserved memory in the segment (>= commit)
    }
}
