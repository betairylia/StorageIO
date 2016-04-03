using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO
{
    public enum keyType
    {
        KEY_STRING,
        KEY_NUMBER,
        KEY_DATETIME
    }

    public abstract class KeyValueProp
    {
        public keyType type;
        public string key { get; set; }
        public abstract override string ToString();
        public abstract object getValue();
        public abstract void setValue(object obj);
    }

    public class StringKeyValueProp : KeyValueProp
    {
        public string value;

        public StringKeyValueProp(string _key, string _value)
        {
            key = _key;
            value = _value;
            type = keyType.KEY_STRING;
        }

        public override object getValue()
        {
            return value;
        }

        public override void setValue(object obj)
        {
            value = (string)obj;
        }

        public override string ToString()
        {
            return value;
        }

        public static bool operator ==(StringKeyValueProp lhs, StringKeyValueProp rhs)
        {
            return lhs.value.Contains(rhs.value);
        }

        public static bool operator !=(StringKeyValueProp lhs, StringKeyValueProp rhs)
        {
            return !lhs.value.Contains(rhs.value);
        }
    }

    public class NumberKeyValueProp : KeyValueProp
    {
        public double value;

        public NumberKeyValueProp(string _key, double _value)
        {
            key = _key;
            value = _value;
            type = keyType.KEY_NUMBER;
        }

        public override void setValue(object obj)
        {
            value = (double)obj;
        }

        public override object getValue()
        {
            return value;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public static bool operator >(NumberKeyValueProp lhs, NumberKeyValueProp rhs)
        {
            return (lhs.value > rhs.value);
        }

        public static bool operator <(NumberKeyValueProp lhs, NumberKeyValueProp rhs)
        {
            return (lhs.value < rhs.value);
        }

        public static bool operator ==(NumberKeyValueProp lhs, NumberKeyValueProp rhs)
        {
            return (lhs.value == rhs.value);
        }

        public static bool operator !=(NumberKeyValueProp lhs, NumberKeyValueProp rhs)
        {
            return (lhs.value != rhs.value);
        }
    }

    public class DateTimeKeyValueProp : KeyValueProp
    {
        public DateTime value;

        public DateTimeKeyValueProp(string _key, DateTime _value)
        {
            key = _key;
            value = _value;
            type = keyType.KEY_DATETIME;
        }

        public override void setValue(object obj)
        {
            value = (DateTime)obj;
        }

        public override object getValue()
        {
            return value;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public static bool operator >(DateTimeKeyValueProp lhs, DateTimeKeyValueProp rhs)
        {
            return (lhs.value > rhs.value);
        }

        public static bool operator <(DateTimeKeyValueProp lhs, DateTimeKeyValueProp rhs)
        {
            return (lhs.value < rhs.value);
        }

        public static bool operator ==(DateTimeKeyValueProp lhs, DateTimeKeyValueProp rhs)
        {
            return (lhs.value == rhs.value);
        }

        public static bool operator !=(DateTimeKeyValueProp lhs, DateTimeKeyValueProp rhs)
        {
            return (lhs.value != rhs.value);
        }
    }
}
