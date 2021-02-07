using System;
using System.Runtime;
using System.Runtime.InteropServices;
namespace System.Reflection
{
    class dummmy { }
}
#region A couple very basic things
namespace System
{
    public class Object { IntPtr m_pEEType; }
    public struct Void { }
    public struct Boolean { }
    public struct Char { }
    public struct SByte { }
    public struct Byte { }
    public struct Int16 { }
    public struct UInt16 { }
    public struct Int32 { }
    public struct UInt32 { }
    public struct Int64 { }
    public struct UInt64 { }
    public struct IntPtr {
        private readonly unsafe void* _value; // Do not rename (binary serialization)

        //[Intrinsic]
        public static readonly IntPtr Zero;

    }
    public struct UIntPtr { }
    public struct Single { }
    public struct Double { }
    public abstract class ValueType { }
    public abstract class Enum : ValueType { }
    public struct Nullable<T> where T : struct { }
    
    public sealed class String { public readonly int Length; }
    public abstract class Array { }
    public abstract class Delegate { }
    public abstract class MulticastDelegate : Delegate { }

    public struct RuntimeTypeHandle { }
    public struct RuntimeMethodHandle { }
    public struct RuntimeFieldHandle { }

    public class Attribute { }
    public enum AttributeTargets
    {
        Assembly = 0x0001,
        Module = 0x0002,
        Class = 0x0004,
        Struct = 0x0008,
        Enum = 0x0010,
        Constructor = 0x0020,
        Method = 0x0040,
        Property = 0x0080,
        Field = 0x0100,
        Event = 0x0200,
        Interface = 0x0400,
        Parameter = 0x0800,
        Delegate = 0x1000,
        ReturnValue = 0x2000,
        GenericParameter = 0x4000,

        All = Assembly | Module | Class | Struct | Enum | Constructor |
                        Method | Property | Field | Event | Interface | Parameter |
                        Delegate | ReturnValue | GenericParameter
    }
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public sealed class AttributeUsageAttribute : Attribute
    {
        private readonly AttributeTargets _attributeTarget;
        private bool _allowMultiple;
        private bool _inherited;

        internal static readonly AttributeUsageAttribute Default = new AttributeUsageAttribute(AttributeTargets.All);

        public AttributeUsageAttribute(AttributeTargets validOn)
        {
            _attributeTarget = validOn;
            _inherited = true;
        }

        internal AttributeUsageAttribute(AttributeTargets validOn, bool allowMultiple, bool inherited)
        {
            _attributeTarget = validOn;
            _allowMultiple = allowMultiple;
            _inherited = inherited;
        }

        public AttributeTargets ValidOn => _attributeTarget;

        public bool AllowMultiple
        {
            get => _allowMultiple;
            set => _allowMultiple = value;
        }

        public bool Inherited
        {
            get => _inherited;
            set => _inherited = value;
        }
    }

    public abstract partial class MemberInfo //: ICustomAttributeProvider
    {
        protected MemberInfo() { }

        //public abstract MemberTypes MemberType { get; }
        public abstract string Name { get; }
        public abstract Type? DeclaringType { get; }
        public abstract Type? ReflectedType { get; }
    }

    public abstract partial class Type : MemberInfo//, IReflect
    {
        protected Type() { }
    }

    namespace Runtime.CompilerServices
    {
        public class RuntimeHelpers
        {
            public static unsafe int OffsetToStringData => sizeof(IntPtr) + sizeof(int);
        }

        public class RuntimeFeature
        {
            public const string UnmanagedSignatureCallingConvention = nameof(UnmanagedSignatureCallingConvention);
        }

        public class CallConvCdecl
        {
            public CallConvCdecl() { }
        }
        public class CallConvFastcall
        {
            public CallConvFastcall() { }
        }
        public class CallConvStdcall
        {
            public CallConvStdcall() { }
        }

        /// <summary>
        /// Indicates that a method should suppress the GC transition as part of the calling convention.
        /// </summary>
        /// <remarks>
        /// The <see cref="System.Runtime.InteropServices.SuppressGCTransitionAttribute" /> describes the effects
        /// of suppressing the GC transition on a native call.
        /// </remarks>
        public class CallConvSuppressGCTransition
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CallConvSuppressGCTransition" /> class.
            /// </summary>
            public CallConvSuppressGCTransition() { }
        }
        public class CallConvThiscall
        {
            public CallConvThiscall() { }
        }
    }
}
namespace System.Runtime.InteropServices
{
    public sealed class DllImportAttribute : Attribute
    {
        public DllImportAttribute(string dllName) { }
    }

    public sealed class UnmanagedCallersOnlyAttribute : Attribute
    {
        public UnmanagedCallersOnlyAttribute()
        {
        }

        /// <summary>
        /// Optional. If omitted, the runtime will use the default platform calling convention.
        /// </summary>
        /// <remarks>
        /// Supplied types must be from the official "System.Runtime.CompilerServices" namespace and
        /// be of the form "CallConvXXX".
        /// </remarks>
        public Type[]? CallConvs;

        /// <summary>
        /// Optional. If omitted, no named export is emitted during compilation.
        /// </summary>
        public string? EntryPoint;
    }

    public sealed class StructLayoutAttribute : Attribute
    {
        public StructLayoutAttribute(LayoutKind layoutKind)
        {
            Value = layoutKind;
        }

        public LayoutKind Value;
        /*public int Pack;
        public int Size;
        public CharSet CharSet;*/
    }

    public enum LayoutKind
    {
        Sequential = 0, // 0x00000008,
        Explicit = 2, // 0x00000010,
        Auto = 3, // 0x00000000,
    }
}
#endregion

#region Things needed by ILC
namespace System
{
    namespace Runtime
    {
        public sealed class RuntimeExportAttribute : Attribute
        {
            public RuntimeExportAttribute(string entry) { }
        }
    }

    class Array<T> : Array { }
}

namespace Internal.Runtime.CompilerHelpers
{
    class StartupCodeHelpers
    {
        [RuntimeExport("RhpReversePInvoke2")]
        static void RhpReversePInvoke2() { }
        [RuntimeExport("RhpReversePInvokeReturn2")]
        static void RhpReversePInvokeReturn2() { }
        [System.Runtime.RuntimeExport("__fail_fast")]
        static void FailFast() { while (true) ; }
        [System.Runtime.RuntimeExport("RhpPInvoke")]
        static void RphPinvoke() { }
        [System.Runtime.RuntimeExport("RhpPInvokeReturn")]
        static void RphPinvokeReturn() { }
    }
}
#endregion
