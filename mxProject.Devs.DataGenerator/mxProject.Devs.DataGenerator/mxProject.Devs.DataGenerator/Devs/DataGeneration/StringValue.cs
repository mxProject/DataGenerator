using System;
using System.Collections.Generic;
using System.Text;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// 
    /// </summary>
    public readonly struct StringValue : IEquatable<StringValue>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public StringValue(string value)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return obj is StringValue value &&
                   Value == value.Value;
        }

        /// <inheritdoc/>
        public bool Equals(StringValue obj)
        {
            return Value == obj.Value;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<string?>.Default.GetHashCode(Value);
        }

        /// <inheritdoc/>
        public override string? ToString()
        {
            return Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(StringValue left, StringValue right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(StringValue left, StringValue right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator String(StringValue value)
        {
            // if (!value.HasValue) { return null; }
            return value.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator StringValue(String value)
        {
            return new StringValue(value);
        }

    }

}
