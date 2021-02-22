using System;

namespace ZeroGC
{
    public enum HandleType
    {
        /*
         * WEAK HANDLES
         *
         * Weak handles are handles that track an object as long as it is alive,
         * but do not keep the object alive if there are no strong references to it.
         *
         */

        /*
         * SHORT-LIVED WEAK HANDLES
         *
         * Short-lived weak handles are weak handles that track an object until the
         * first time it is detected to be unreachable.  At this point, the handle is
         * severed, even if the object will be visible from a pending finalization
         * graph.  This further implies that short weak handles do not track
         * across object resurrections.
         *
         */
        HNDTYPE_WEAK_SHORT = 0,

        /*
         * LONG-LIVED WEAK HANDLES
         *
         * Long-lived weak handles are weak handles that track an object until the
         * object is actually reclaimed.  Unlike short weak handles, long weak handles
         * continue to track their referents through finalization and across any
         * resurrections that may occur.
         *
         */
        HNDTYPE_WEAK_LONG = 1,
        HNDTYPE_WEAK_DEFAULT = 1,

        /*
         * STRONG HANDLES
         *
         * Strong handles are handles which function like a normal object reference.
         * The existence of a strong handle for an object will cause the object to
         * be promoted (remain alive) through a garbage collection cycle.
         *
         */
        HNDTYPE_STRONG = 2,
        HNDTYPE_DEFAULT = 2,

        /*
         * PINNED HANDLES
         *
         * Pinned handles are strong handles which have the added property that they
         * prevent an object from moving during a garbage collection cycle.  This is
         * useful when passing a pointer to object innards out of the runtime while GC
         * may be enabled.
         *
         * NOTE:  PINNING AN OBJECT IS EXPENSIVE AS IT PREVENTS THE GC FROM ACHIEVING
         *        OPTIMAL PACKING OF OBJECTS DURING EPHEMERAL COLLECTIONS.  THIS TYPE
         *        OF HANDLE SHOULD BE USED SPARINGLY!
         */
        HNDTYPE_PINNED = 3,

        /*
         * VARIABLE HANDLES
         *
         * Variable handles are handles whose type can be changed dynamically.  They
         * are larger than other types of handles, and are scanned a little more often,
         * but are useful when the handle owner needs an efficient way to change the
         * strength of a handle on the fly.
         *
         */
        HNDTYPE_VARIABLE = 4,

        /*
         * REFCOUNTED HANDLES
         *
         * Refcounted handles are handles that behave as strong handles while the
         * refcount on them is greater than 0 and behave as weak handles otherwise.
         *
         * N.B. These are currently NOT general purpose.
         *      The implementation is tied to COM Interop.
         *
         */
        HNDTYPE_REFCOUNTED = 5,

        /*
         * DEPENDENT HANDLES
         *
         * Dependent handles are two handles that need to have the same lifetime.  One handle refers to a secondary object
         * that needs to have the same lifetime as the primary object. The secondary object should not cause the primary
         * object to be referenced, but as long as the primary object is alive, so must be the secondary
         *
         * They are currently used for EnC for adding new field members to existing instantiations under EnC modes where
         * the primary object is the original instantiation and the secondary represents the added field.
         *
         * They are also used to implement the managed ConditionalWeakTable class. If you want to use
         * these from managed code, they are exposed to BCL through the managed DependentHandle class.
         *
         *
         */
        HNDTYPE_DEPENDENT = 6,

        /*
         * PINNED HANDLES for asynchronous operation
         *
         * Pinned handles are strong handles which have the added property that they
         * prevent an object from moving during a garbage collection cycle.  This is
         * useful when passing a pointer to object innards out of the runtime while GC
         * may be enabled.
         *
         * NOTE:  PINNING AN OBJECT IS EXPENSIVE AS IT PREVENTS THE GC FROM ACHIEVING
         *        OPTIMAL PACKING OF OBJECTS DURING EPHEMERAL COLLECTIONS.  THIS TYPE
         *        OF HANDLE SHOULD BE USED SPARINGLY!
         */
        HNDTYPE_ASYNCPINNED = 7,

        /*
         * SIZEDREF HANDLES
         *
         * SizedRef handles are strong handles. Each handle has a piece of user data associated
         * with it that stores the size of the object this handle refers to. These handles
         * are scanned as strong roots during each GC but only during full GCs would the size
         * be calculated.
         *
         */
        HNDTYPE_SIZEDREF = 8,

        /*
         * NATIVE WEAK HANDLES
         *
         * Native weak reference handles hold two different types of weak handles to any
         * RCW with an underlying COM object that implements IWeakReferenceSource.  The
         * object reference itself is a short weak handle to the RCW.  In addition an
         * IWeakReference* to the underlying COM object is stored, allowing the handle
         * to create a new RCW if the existing RCW is collected.  This ensures that any
         * code holding onto a native weak reference can always access an RCW to the
         * underlying COM object as long as it has not been released by all of its strong
         * references.
         */
        HNDTYPE_WEAK_NATIVE_COM = 9
    }
}
