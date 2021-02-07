using System;

namespace ZeroGC
{
    enum WriteBarrierOp
    {
        StompResize,
        StompEphemeral,
        Initialize,
        SwitchToWriteWatch,
        SwitchToNonWriteWatch
    }
}
