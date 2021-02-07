using System;

namespace ZeroGC
{
    // Event levels corresponding to events that can be fired by the GC.
    enum GCEventLevel
    {
        GCEventLevel_None = 0,
        GCEventLevel_Fatal = 1,
        GCEventLevel_Error = 2,
        GCEventLevel_Warning = 3,
        GCEventLevel_Information = 4,
        GCEventLevel_Verbose = 5,
        GCEventLevel_Max = 6,
        GCEventLevel_LogAlways = 255
    }
}
