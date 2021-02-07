using System;
using System.Runtime.InteropServices;

namespace ZeroGC
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct VersionInfo
    {
        public int MajorVersion;
        public int MinorVersion;
        public int BuildVersion;
        public byte* Name;
    }
}
