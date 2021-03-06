using System;

namespace Couchbase.Core.IO.Converters
{
    /// <summary>
    /// Provides an interface for converting types and arrays before being sent or after being received across the network.
    /// </summary>
    public interface IByteConverter
    {
        #region ToXXX

        /// <summary>
        /// Reads a <see cref="bool"/> from a buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">if set to <c>true</c> [use nbo].</param>
        /// <returns></returns>
        bool ToBoolean(ReadOnlySpan<byte> buffer, bool useNbo);

        /// <summary>
        /// Reads a <see cref="float"/> from a buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">if set to <c>true</c> [use nbo].</param>
        /// <returns></returns>
        float ToSingle(ReadOnlySpan<byte> buffer, bool useNbo);

        /// <summary>
        /// Reads a <see cref="DateTime"/> from a buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">if set to <c>true</c> [use nbo].</param>
        /// <returns></returns>
        DateTime ToDateTime(ReadOnlySpan<byte> buffer, bool useNbo);

        /// <summary>
        /// To the double.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">if set to <c>true</c> [use nbo].</param>
        /// <returns></returns>
        double ToDouble(ReadOnlySpan<byte> buffer, bool useNbo);

        /// <summary>
        /// Reads a <see cref="Int16" /> from a buffer starting.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">If <c>true</c> will make most significant byte first.</param>
        /// <returns></returns>
        short ToInt16(ReadOnlySpan<byte> buffer, bool useNbo);

        /// <summary>
        /// Reads a <see cref="UInt16" /> from a buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">If <c>true</c> will make most significant byte first.</param>
        /// <returns></returns>
        ushort ToUInt16(ReadOnlySpan<byte> buffer, bool useNbo);

        /// <summary>
        /// Reads a <see cref="Int32" /> from a buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">If <c>true</c> will make most significant byte first.</param>
        /// <returns></returns>
        int ToInt32(ReadOnlySpan<byte> buffer, bool useNbo);

        /// <summary>
        /// Reads a <see cref="UInt32" /> from a buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">If <c>true</c> will make most significant byte first.</param>
        /// <returns></returns>
        uint ToUInt32(ReadOnlySpan<byte> buffer, bool useNbo);

        /// <summary>
        /// Reads a <see cref="Int64" /> from a buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">If <c>true</c> will make most significant byte first.</param>
        /// <returns></returns>
        long ToInt64(ReadOnlySpan<byte> buffer, bool useNbo);

        /// <summary>
        /// Reads a <see cref="UInt64" /> from a buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">If <c>true</c> will make most significant byte first.</param>
        /// <returns></returns>
        ulong ToUInt64(ReadOnlySpan<byte> buffer, bool useNbo);

        /// <summary>
        /// Returns a <see cref="System.String" /> from the buffer.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        string ToString(ReadOnlySpan<byte> buffer);

        #endregion

        #region FromXXX

        /// <summary>
        /// Writes a <see cref="Int16" /> to a buffer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">If <c>true</c> will make most significant byte first.</param>
        void FromInt16(short value, Span<byte> buffer, bool useNbo);

        /// <summary>
        /// Writes a <see cref="UInt16" /> to a buffer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">If <c>true</c> will make most significant byte first.</param>
        void FromUInt16(ushort value, Span<byte> buffer, bool useNbo);

        /// <summary>
        /// Writes a <see cref="Int32" /> to a buffer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">If <c>true</c> will make most significant byte first.</param>
        void FromInt32(int value, Span<byte> buffer, bool useNbo);

        /// <summary>
        /// Writes a <see cref="UInt32" /> to a buffer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">If <c>true</c> will make most significant byte first.</param>
        void FromUInt32(uint value, Span<byte> buffer, bool useNbo);

        /// <summary>
        /// Writes a <see cref="Int64" /> to a buffer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">If <c>true</c> will make most significant byte first.</param>
        void FromInt64(long value, Span<byte> buffer, bool useNbo);

        /// <summary>
        /// Writes a <see cref="UInt64" /> to a buffer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="useNbo">If <c>true</c> will make most significant byte first.</param>
        void FromUInt64(ulong value, Span<byte> buffer, bool useNbo);

        /// <summary>
        /// Gets the number of bytes required to convert a string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The number of bytes required to convert the string.</returns>
        int GetStringByteCount(string value);

        /// <summary>
        /// Writes a <see cref="System.String"/> to a buffer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="buffer">The buffer.</param>
        /// <returns>Number of bytes written to the buffer.</returns>
        int FromString(string value, Span<byte> buffer);

        #endregion
    }
}
