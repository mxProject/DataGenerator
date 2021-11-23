using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public struct CustomStruct : IEquatable<CustomStruct>
    {
        public CustomStruct(int intValue, DateTime dateValue, string? stringValue)
        {
            IntValue = intValue;
            DateTimeValue = dateValue;
            StringValue = stringValue;
        }

        public int IntValue { get; set; }

        public DateTime DateTimeValue { get; set; }

        public string? StringValue { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CustomStruct @struct && Equals(@struct);
        }

        public bool Equals(CustomStruct other)
        {
            return IntValue == other.IntValue &&
                   DateTimeValue == other.DateTimeValue &&
                   StringValue == other.StringValue;
        }

        public override int GetHashCode()
        {
            int hashCode = -1805891295;
            hashCode = hashCode * -1521134295 + IntValue.GetHashCode();
            hashCode = hashCode * -1521134295 + DateTimeValue.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StringValue!);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{IntValue},{DateTimeValue},{StringValue}";
        }

        internal static CustomStruct Parse(string? text)
        {
            if (text == null) { return default; }

            var args = text.Split(',');

            int intValue = default;
            DateTime dateValue = default;
            string? stringValue = default;

            if (args.Length > 0) { intValue = int.Parse(args[0]); }
            if (args.Length > 1) { dateValue = DateTime.Parse(args[1]); }
            if (args.Length > 2) { stringValue = args[2]; }

            return new CustomStruct(intValue, dateValue, stringValue);
        }
    }
}
