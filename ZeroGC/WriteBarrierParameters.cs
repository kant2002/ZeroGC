using System;

namespace ZeroGC
{
    using uint8_t = Byte;
    using uint32_t = UInt32;

    unsafe struct WriteBarrierParameters
    {
        // The operation that StompWriteBarrier will perform.
        WriteBarrierOp operation;

        // Whether or not the runtime is currently suspended. If it is not,
        // the EE will need to suspend it before bashing the write barrier.
        // Used for all operations.
        bool is_runtime_suspended;

        // Whether or not the GC has moved the ephemeral generation to no longer
        // be at the top of the heap. When the ephemeral generation is at the top
        // of the heap, and the write barrier observes that a pointer is greater than
        // g_ephemeral_low, it does not need to check that the pointer is less than
        // g_ephemeral_high because there is nothing in the GC heap above the ephemeral
        // generation. When this is not the case, however, the GC must inform the EE
        // so that the EE can switch to a write barrier that checks that a pointer
        // is both greater than g_ephemeral_low and less than g_ephemeral_high.
        // Used for WriteBarrierOp::StompResize.
        bool requires_upper_bounds_check;

        // The new card table location. May or may not be the same as the previous
        // card table. Used for WriteBarrierOp::Initialize and WriteBarrierOp::StompResize.
        uint32_t* card_table;

        // The new card bundle table location. May or may not be the same as the previous
        // card bundle table. Used for WriteBarrierOp::Initialize and WriteBarrierOp::StompResize.
        uint32_t* card_bundle_table;

        // The heap's new low boundary. May or may not be the same as the previous
        // value. Used for WriteBarrierOp::Initialize and WriteBarrierOp::StompResize.
        uint8_t* lowest_address;

        // The heap's new high boundary. May or may not be the same as the previous
        // value. Used for WriteBarrierOp::Initialize and WriteBarrierOp::StompResize.
        uint8_t* highest_address;

        // The new start of the ephemeral generation.
        // Used for WriteBarrierOp::StompEphemeral.
        uint8_t* ephemeral_low;

        // The new end of the ephemeral generation.
        // Used for WriteBarrierOp::StompEphemeral.
        uint8_t* ephemeral_high;

        // The new write watch table, if we are using our own write watch
        // implementation. Used for WriteBarrierOp::SwitchToWriteWatch only.
        uint8_t* write_watch_table;
    }
}
