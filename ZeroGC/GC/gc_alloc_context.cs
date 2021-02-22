using System;
using System.Runtime.InteropServices;

namespace ZeroGC
{
    using uint8_t = Byte;
    using __int64 = Int64;

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct gc_alloc_context
    {
        public uint8_t* alloc_ptr;
        public uint8_t* alloc_limit;
        public __int64 alloc_bytes; //Number of bytes allocated on SOH by this context
        public __int64 alloc_bytes_loh; //Number of bytes allocated on LOH by this context
        public void* gc_reserved_1;
        public void* gc_reserved_2;
        public int alloc_count;
    }
}
