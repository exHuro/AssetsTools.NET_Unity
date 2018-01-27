using System;

namespace AssetsTools.NET.Unity
{
    public class AssetTypeValue
    {
        public EnumValueTypes type;

        public struct ValueTypes
        {
            public AssetTypeArray asArray;
            public AssetTypeByteArray asByteArray;

            public bool asBool;

            public sbyte asInt8;
            public byte asUInt8;

            public short asInt16;
            public ushort asUInt16;

            public int asInt32;
            public uint asUInt32;

            public long asInt64;
            public ulong asUInt64;

            public float asFloat;
            public double asDouble;

            public string asString;
        }
        public ValueTypes value = new ValueTypes();
        
        public AssetTypeValue(EnumValueTypes type, object valueContainer)
        {
            this.type = type;
        }
        public EnumValueTypes GetValueType()
        {
            return type;
        }

        //The c++ version can just use unions, so we have to
        //do a little more work to set all the values here
        public void Set(object valueContainer)
        {
            unchecked
            {
                switch (type)
                {
                    case EnumValueTypes.ValueType_Bool:
                        value.asBool = Convert.ToBoolean(valueContainer);
                        break;
                    case EnumValueTypes.ValueType_Int8:
                    case EnumValueTypes.ValueType_UInt8:
                        value.asInt8 = Convert.ToSByte(valueContainer);
                        value.asUInt8 = Convert.ToByte(valueContainer);
                        break;
                    case EnumValueTypes.ValueType_Int16:
                    case EnumValueTypes.ValueType_UInt16:
                        value.asInt16 = Convert.ToInt16(valueContainer);
                        value.asUInt16 = Convert.ToUInt16(valueContainer);
                        break;
                    case EnumValueTypes.ValueType_Int32:
                    case EnumValueTypes.ValueType_UInt32:
                        value.asInt32 = Convert.ToInt32(valueContainer);
                        value.asUInt32 = Convert.ToUInt32(valueContainer);
                        break;
                    case EnumValueTypes.ValueType_Int64:
                    case EnumValueTypes.ValueType_UInt64:
                        value.asInt64 = Convert.ToInt64(valueContainer);
                        value.asUInt64 = Convert.ToUInt64(valueContainer);
                        break;
                    case EnumValueTypes.ValueType_Float:
                        value.asFloat = Convert.ToSingle(valueContainer);
                        break;
                    case EnumValueTypes.ValueType_Double:
                        value.asDouble = Convert.ToDouble(valueContainer);
                        break;
                    case EnumValueTypes.ValueType_String:
                        value.asString = Convert.ToString(valueContainer);
                        break;
                    case EnumValueTypes.ValueType_Array:
                        value.asArray = (AssetTypeArray)valueContainer;
                        break;
                    case EnumValueTypes.ValueType_ByteArray:
                        value.asByteArray = (AssetTypeByteArray)valueContainer;
                        break;
                    default:
                        break;
                }
            }
        }
        public AssetTypeArray AsArray()
        {
            return (type == EnumValueTypes.ValueType_Array) ? value.asArray : new AssetTypeArray() { size = 0xFFFF };
        }
        public AssetTypeByteArray AsByteArray()
        {
            return (type == EnumValueTypes.ValueType_ByteArray) ? value.asByteArray : new AssetTypeByteArray() { size = 0xFFFF };
        }
        public string AsString()
        {
            switch (type)
            {
                case EnumValueTypes.ValueType_Bool:
                    return value.asBool ? "true" : "false";
                case EnumValueTypes.ValueType_Int8:
                    return value.asInt8.ToString();
                case EnumValueTypes.ValueType_UInt8:
                    return value.asUInt8.ToString();
                case EnumValueTypes.ValueType_Int16:
                    return value.asInt16.ToString();
                case EnumValueTypes.ValueType_UInt16:
                    return value.asUInt16.ToString();
                case EnumValueTypes.ValueType_Int32:
                    return value.asInt32.ToString();
                case EnumValueTypes.ValueType_UInt32:
                    return value.asUInt32.ToString();
                case EnumValueTypes.ValueType_Int64:
                    return value.asInt64.ToString();
                case EnumValueTypes.ValueType_UInt64:
                    return value.asUInt64.ToString();
                case EnumValueTypes.ValueType_Float:
                    return value.asFloat.ToString();
                case EnumValueTypes.ValueType_Double:
                    return value.asDouble.ToString();
                case EnumValueTypes.ValueType_String:
                    return value.asString;
                case EnumValueTypes.ValueType_None:
                case EnumValueTypes.ValueType_Array:
                case EnumValueTypes.ValueType_ByteArray:
                default:
                    return "";
            }
        }
        public bool AsBool()
        {
            switch (type)
            {
                case EnumValueTypes.ValueType_Float:
                case EnumValueTypes.ValueType_Double:
                case EnumValueTypes.ValueType_String:
                case EnumValueTypes.ValueType_ByteArray:
                case EnumValueTypes.ValueType_Array:
                    return false;
                default:
                    return value.asBool;
            }
        }
        public int AsInt()
        {
            switch (type)
            {
                case EnumValueTypes.ValueType_Float:
                    return (int)value.asFloat;
                case EnumValueTypes.ValueType_Double:
                    return (int)value.asDouble;
                case EnumValueTypes.ValueType_String:
                case EnumValueTypes.ValueType_ByteArray:
                case EnumValueTypes.ValueType_Array:
                    return 0;
                case EnumValueTypes.ValueType_Int8:
                    return value.asInt8;
                case EnumValueTypes.ValueType_Int16:
                    return value.asInt16;
                case EnumValueTypes.ValueType_Int64:
                    return (int)value.asInt64;
                default:
                    return value.asInt32;
            }
        }
        public uint AsUInt()
        {
            switch (type)
            {
                case EnumValueTypes.ValueType_Float:
                    return (uint)value.asFloat;
                case EnumValueTypes.ValueType_Double:
                    return (uint)value.asDouble;
                case EnumValueTypes.ValueType_String:
                case EnumValueTypes.ValueType_ByteArray:
                case EnumValueTypes.ValueType_Array:
                    return 0;
                default:
                    return value.asUInt32;
            }
        }
        public long AsInt64()
        {
            switch (type)
            {
                case EnumValueTypes.ValueType_Float:
                    return (long)value.asFloat;
                case EnumValueTypes.ValueType_Double:
                    return (long)value.asDouble;
                case EnumValueTypes.ValueType_String:
                case EnumValueTypes.ValueType_ByteArray:
                case EnumValueTypes.ValueType_Array:
                    return 0;
                case EnumValueTypes.ValueType_Int8:
                    return value.asInt8;
                case EnumValueTypes.ValueType_Int16:
                    return value.asInt16;
                case EnumValueTypes.ValueType_Int32:
                    return value.asInt32;
                default:
                    return value.asInt64;
            }
        }
        public ulong AsUInt64()
        {
            switch (type)
            {
                case EnumValueTypes.ValueType_Float:
                    return (uint)value.asFloat;
                case EnumValueTypes.ValueType_Double:
                    return (ulong)value.asDouble;
                case EnumValueTypes.ValueType_String:
                case EnumValueTypes.ValueType_ByteArray:
                case EnumValueTypes.ValueType_Array:
                    return 0;
                default:
                    return value.asUInt64;
            }
        }
        public float AsFloat()
        {
            switch (type)
            {
                case EnumValueTypes.ValueType_Float:
                    return value.asFloat;
                case EnumValueTypes.ValueType_Double:
                    return (float)value.asDouble;
                case EnumValueTypes.ValueType_String:
                case EnumValueTypes.ValueType_ByteArray:
                case EnumValueTypes.ValueType_Array:
                    return 0;
                case EnumValueTypes.ValueType_Int8:
                    return value.asInt8;
                case EnumValueTypes.ValueType_Int16:
                    return value.asInt16;
                case EnumValueTypes.ValueType_Int32:
                    return value.asInt32;
                default:
                    return value.asUInt64;
            }
        }
        public double AsDouble()
        {
            switch (type)
            {
                case EnumValueTypes.ValueType_Float:
                    return value.asFloat;
                case EnumValueTypes.ValueType_Double:
                    return value.asDouble;
                case EnumValueTypes.ValueType_String:
                case EnumValueTypes.ValueType_ByteArray:
                case EnumValueTypes.ValueType_Array:
                    return 0;
                case EnumValueTypes.ValueType_Int8:
                    return value.asInt8;
                case EnumValueTypes.ValueType_Int16:
                    return value.asInt16;
                case EnumValueTypes.ValueType_Int32:
                    return value.asInt32;
                default:
                    return value.asUInt64;
            }
        }
    }
}
