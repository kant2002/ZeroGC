using System;
using System.Runtime.InteropServices;

namespace ZeroGC
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GcDacVars
    {
        public byte major_version_number;
        public byte minor_version_number;
        public nuint generation_size;
        public nuint total_generation_count;
    }
}
