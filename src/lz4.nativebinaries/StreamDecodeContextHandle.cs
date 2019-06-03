using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.ConstrainedExecution;
using System.Security.Permissions;

namespace LZ4
{
    [SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
    [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
    public class StreamDecodeContextHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StreamDecodeContextHandle"/> class.
        /// </summary>
        protected StreamDecodeContextHandle() :
                base(true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamDecodeContextHandle"/> class, specifying whether the handle is to be reliably released.
        /// </summary>
        /// <param name="ownsHandle">
        /// <see langword="true"/> to reliably release the handle during the finalization phase; <see langword="false"/> to prevent reliable release (not recommended).
        /// </param>
        protected StreamDecodeContextHandle(bool ownsHandle) :
                base(ownsHandle)
        {
        }

        /// <summary>
        /// Gets a value which represents a pointer or handle that has been initialized to zero.
        /// </summary>
        public static StreamDecodeContextHandle Zero
        {
            get
            {
                return StreamDecodeContextHandle.DangerousCreate(IntPtr.Zero);
            }
        }

        /// <inheritdoc/>
        [ReliabilityContractAttribute(Consistency.WillNotCorruptState, Cer.MayFail)]
        protected override bool ReleaseHandle()
        {
            return LZ4.LZ4_freeStreamDecode(this.handle) == 0;
        }

        /// <summary>
        /// Creates a new <see cref="StreamDecodeContextHandle"/> from a <see cref="IntPtr"/>.
        /// </summary>
        /// <param name="unsafeHandle">
        /// The underlying <see cref="IntPtr"/>
        /// </param>
        /// <param name="ownsHandle">
        /// <see langword="true"/> to reliably release the handle during the finalization phase; <see langword="false"/> to prevent reliable release (not recommended).
        /// </param>
        /// <returns>
        /// </returns>
        public static StreamDecodeContextHandle DangerousCreate(IntPtr unsafeHandle, bool ownsHandle)
        {
            StreamDecodeContextHandle safeHandle = new StreamDecodeContextHandle(ownsHandle);
            safeHandle.SetHandle(unsafeHandle);
            return safeHandle;
        }

        /// <summary>
        /// Creates a new <see cref="StreamDecodeContextHandle"/> from a <see cref="IntPtr"/>.
        /// </summary>
        /// <param name="unsafeHandle">
        /// The underlying <see cref="IntPtr"/>
        /// </param>
        /// <returns>
        /// </returns>
        public static StreamDecodeContextHandle DangerousCreate(IntPtr unsafeHandle)
        {
            return StreamDecodeContextHandle.DangerousCreate(unsafeHandle, true);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0} ({1})", this.handle, "StreamDecodeContextHandle");
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() == typeof(StreamDecodeContextHandle))
            {
                return ((StreamDecodeContextHandle)obj).handle.Equals(this.handle);
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.handle.GetHashCode();
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="StreamDecodeContextHandle"/> are equal.
        /// </summary>
        /// <param name="value1">
        /// The first pointer or handle to compare.
        /// </param>
        /// <param name="value2">
        /// The second pointer or handle to compare.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value1"/> equals <paramref name="value2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator ==(StreamDecodeContextHandle value1, StreamDecodeContextHandle value2)
        {
            if (object.Equals(value1, null) && object.Equals(value2, null))
            {
                return true;
            }

            if (object.Equals(value1, null) || object.Equals(value2, null))
            {
                return false;
            }

            return value1.handle == value2.handle;
        }

        /// <summary>
        /// Determines whether two specified instances of <see cref="StreamDecodeContextHandle"/> are not equal.
        /// </summary>
        /// <param name="value1">
        /// The first pointer or handle to compare.
        /// </param>
        /// <param name="value2">
        /// The second pointer or handle to compare.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value1"/> does not equal <paramref name="value2"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(StreamDecodeContextHandle value1, StreamDecodeContextHandle value2)
        {
            if (object.Equals(value1, null) && object.Equals(value2, null))
            {
                return false;
            }

            if (object.Equals(value1, null) || object.Equals(value2, null))
            {
                return true;
            }

            return value1.handle != value2.handle;
        }
    }
}
