using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Extension methods for <see cref="IDataRecord"/>.
    /// </summary>
    public static class IDataRecordExtensions
    {

        #region GetValue by name

        private static int GetOrdinal(IDataRecord record, string fieldName)
        {
            return record.GetOrdinal(fieldName);
        }

        /// <summary>
        /// Gets the value of the specified column as a Boolean.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static bool GetBoolean(this IDataRecord record, string fieldName)
        {
            return record.GetBoolean(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Gets the 8-bit unsigned integer value of the specified column.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static byte GetByte(this IDataRecord record, string fieldName)
        {
            return record.GetByte(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Reads a stream of bytes from the specified column offset into the buffer as an array, starting at the given buffer offset.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldOffset"></param>
        /// <param name="buffer"></param>
        /// <param name="bufferoffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static long GetBytes(this IDataRecord record, string fieldName, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return record.GetBytes(GetOrdinal(record, fieldName), fieldOffset, buffer, bufferoffset, length);
        }

        /// <summary>
        /// Gets the character value of the specified column.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static char GetChar(this IDataRecord record, string fieldName)
        {
            return record.GetChar(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Reads a stream of characters from the specified column offset into the buffer as an array, starting at the given buffer offset.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <param name="fieldoffset"></param>
        /// <param name="buffer"></param>
        /// <param name="bufferoffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static long GetChars(this IDataRecord record, string fieldName, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return record.GetChars(GetOrdinal(record, fieldName), fieldoffset, buffer, bufferoffset, length);
        }

        /// <summary>
        /// Returns an System.Data.IDataReader for the specified column ordinal.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static IDataReader GetData(this IDataRecord record, string fieldName)
        {
            return record.GetData(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Gets the date and time data value of the specified field.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(this IDataRecord record, string fieldName)
        {
            return record.GetDateTime(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Gets the fixed-position numeric value of the specified field.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static decimal GetDecimal(this IDataRecord record, string fieldName)
        {
            return record.GetDecimal(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Gets the double-precision floating point number of the specified field.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static double GetDouble(this IDataRecord record, string fieldName)
        {
            return record.GetDouble(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Gets the single-precision floating point number of the specified field.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static float GetFloat(this IDataRecord record, string fieldName)
        {
            return record.GetFloat(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Returns the GUID value of the specified field.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static Guid GetGuid(this IDataRecord record, string fieldName)
        {
            return record.GetGuid(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Gets the 16-bit signed integer value of the specified field.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static short GetInt16(this IDataRecord record, string fieldName)
        {
            return record.GetInt16(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Gets the 32-bit signed integer value of the specified field.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static int GetInt32(this IDataRecord record, string fieldName)
        {
            return record.GetInt32(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Gets the 64-bit signed integer value of the specified field.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static long GetInt64(this IDataRecord record, string fieldName)
        {
            return record.GetInt64(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Gets the string value of the specified field.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string GetString(this IDataRecord record, string fieldName)
        {
            return record.GetString(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Return the value of the specified field.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static object? GetValue(this IDataRecord record, string fieldName)
        {
            return record.GetValue(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Gets the generated raw value of the specified field.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static T? GetRawValue<T>(this IDataGenerationRecord record, string fieldName)
            where T : struct
        {
            return record.GetRawValue<T>(GetOrdinal(record, fieldName));
        }

        /// <summary>
        /// Return whether the specified field is set to null.
        /// </summary>
        /// <param name="record"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static bool IsDBNull(this IDataRecord record, string fieldName)
        {
            return record.IsDBNull(GetOrdinal(record, fieldName));
        }

        #endregion

        #region GetTuple<T1, T2>

        /// <summary>
        /// Gets the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndex1">The index of the first field.</param>
        /// <param name="fieldIndex2">The index of the second field.</param>
        /// <returns></returns>
        public static (T1, T2) GetTuple<T1, T2>(this IDataRecord record, int fieldIndex1, int fieldIndex2)
        {
            return ((T1)record.GetValue(fieldIndex1)!, (T2)record.GetValue(fieldIndex2)!);
        }

        /// <summary>
        /// Gets the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndexes">The indexes of the fields.</param>
        /// <returns></returns>
        public static (T1, T2) GetTuple<T1, T2>(this IDataRecord record, int[] fieldIndexes)
        {
            AssertFieldCount(fieldIndexes, 2);
            return GetTuple<T1, T2>(record, fieldIndexes[0], fieldIndexes[1]);
        }

        /// <summary>
        /// Gets the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The index of the second field.</param>
        /// <returns></returns>
        public static (T1, T2) GetTuple<T1, T2>(this IDataRecord record, string fieldName1, string fieldName2)
        {
            return ((T1)record.GetValue(fieldName1)!, (T2)record.GetValue(fieldName2)!);
        }

        /// <summary>
        /// Gets the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldNames">The names of the fields.</param>
        /// <returns></returns>
        public static (T1, T2) GetTuple<T1, T2>(this IDataRecord record, string[] fieldNames)
        {
            AssertFieldCount(fieldNames, 2);
            return GetTuple<T1, T2>(record, fieldNames[0], fieldNames[1]);
        }

        #endregion

        #region GetTuple<T1, T2, T3>

        /// <summary>
        /// Gets the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndex1">The index of the first field.</param>
        /// <param name="fieldIndex2">The index of the second field.</param>
        /// <param name="fieldIndex3">The index of the third field.</param>
        /// <returns></returns>
        public static (T1, T2, T3) GetTuple<T1, T2, T3>(this IDataRecord record, int fieldIndex1, int fieldIndex2, int fieldIndex3)
        {
            return ((T1)record.GetValue(fieldIndex1)!, (T2)record.GetValue(fieldIndex2)!, (T3)record.GetValue(fieldIndex3)!);
        }

        /// <summary>
        /// Gets the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndexes">The indexes of the fields.</param>
        /// <returns></returns>
        public static (T1, T2, T3) GetTuple<T1, T2, T3>(this IDataRecord record, int[] fieldIndexes)
        {
            AssertFieldCount(fieldIndexes, 3);
            return GetTuple<T1, T2, T3>(record, fieldIndexes[0], fieldIndexes[1], fieldIndexes[2]);
        }

        /// <summary>
        /// Gets the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <returns></returns>
        public static (T1, T2, T3) GetTuple<T1, T2, T3>(this IDataRecord record, string fieldName1, string fieldName2, string fieldName3)
        {
            return ((T1)record.GetValue(fieldName1)!, (T2)record.GetValue(fieldName2)!, (T3)record.GetValue(fieldName3)!);
        }

        /// <summary>
        /// Gets the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldNames">The names of the fields.</param>
        /// <returns></returns>
        public static (T1, T2, T3) GetTuple<T1, T2, T3>(this IDataRecord record, string[] fieldNames)
        {
            AssertFieldCount(fieldNames, 3);
            return GetTuple<T1, T2, T3>(record, fieldNames[0], fieldNames[1], fieldNames[2]);
        }

        #endregion

        #region GetRawTuple<T1, T2>

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndex1">The index of the first field.</param>
        /// <param name="fieldIndex2">The index of the second field.</param>
        /// <returns></returns>
        public static (T1?, T2?) GetRawTuple<T1, T2>(this IDataGenerationRecord record, int fieldIndex1, int fieldIndex2)
            where T1 : struct
            where T2 : struct
        {
            return (record.GetRawValue<T1>(fieldIndex1)!, record.GetRawValue<T2>(fieldIndex2)!);
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndexes">The indexes of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?) GetRawTuple<T1, T2>(this IDataGenerationRecord record, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
        {
            AssertFieldCount(fieldIndexes, 2);
            return GetRawTuple<T1, T2>(record, fieldIndexes[0], fieldIndexes[1]);
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The index of the second field.</param>
        /// <returns></returns>
        public static (T1?, T2?) GetRawTuple<T1, T2>(this IDataGenerationRecord record, string fieldName1, string fieldName2)
            where T1 : struct
            where T2 : struct
        {
            return (record.GetRawValue<T1>(fieldName1)!, record.GetRawValue<T2>(fieldName2)!);
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldNames">The names of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?) GetRawTuple<T1, T2>(this IDataGenerationRecord record, string[] fieldNames)
            where T1 : struct
            where T2 : struct
        {
            AssertFieldCount(fieldNames, 2);
            return GetRawTuple<T1, T2>(record, fieldNames[0], fieldNames[1]);
        }

        #endregion

        #region GetRawTuple<T1, T2, T3>

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndex1">The index of the first field.</param>
        /// <param name="fieldIndex2">The index of the second field.</param>
        /// <param name="fieldIndex3">The index of the third field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?) GetRawTuple<T1, T2, T3>(this IDataGenerationRecord record, int fieldIndex1, int fieldIndex2, int fieldIndex3)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return (record.GetRawValue<T1>(fieldIndex1)!, record.GetRawValue<T2>(fieldIndex2)!, record.GetRawValue<T3>(fieldIndex3)!);
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndexes">The indexes of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?) GetRawTuple<T1, T2, T3>(this IDataGenerationRecord record, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            AssertFieldCount(fieldIndexes, 3);
            return GetRawTuple<T1, T2, T3>(record, fieldIndexes[0], fieldIndexes[1], fieldIndexes[2]);
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?) GetRawTuple<T1, T2, T3>(this IDataGenerationRecord record, string fieldName1, string fieldName2, string fieldName3)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            return (record.GetRawValue<T1>(fieldName1)!, record.GetRawValue<T2>(fieldName2)!, record.GetRawValue<T3>(fieldName3)!);
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldNames">The names of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?) GetRawTuple<T1, T2, T3>(this IDataGenerationRecord record, string[] fieldNames)
            where T1 : struct
            where T2 : struct
            where T3 : struct
        {
            AssertFieldCount(fieldNames, 3);
            return GetRawTuple<T1, T2, T3>(record, fieldNames[0], fieldNames[1], fieldNames[2]);
        }

        #endregion

        #region GetRawTuple<T1, T2, T3, T4>

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndex1">The index of the first field.</param>
        /// <param name="fieldIndex2">The index of the second field.</param>
        /// <param name="fieldIndex3">The index of the third field.</param>
        /// <param name="fieldIndex4">The index of the fourth field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?) GetRawTuple<T1, T2, T3, T4>(
            this IDataGenerationRecord record,
            int fieldIndex1,
            int fieldIndex2,
            int fieldIndex3,
            int fieldIndex4
            )
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            return (
                record.GetRawValue<T1>(fieldIndex1)!,
                record.GetRawValue<T2>(fieldIndex2)!,
                record.GetRawValue<T3>(fieldIndex3)!,
                record.GetRawValue<T4>(fieldIndex4)!
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndexes">The indexes of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?) GetRawTuple<T1, T2, T3, T4>(this IDataGenerationRecord record, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            AssertFieldCount(fieldIndexes, 4);
            return GetRawTuple<T1, T2, T3, T4>(
                record,
                fieldIndexes[0],
                fieldIndexes[1],
                fieldIndexes[2],    
                fieldIndexes[3]
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?) GetRawTuple<T1, T2, T3, T4>(
            this IDataGenerationRecord record,
            string fieldName1,
            string fieldName2,
            string fieldName3,
            string fieldName4
            )
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            return (
                record.GetRawValue<T1>(fieldName1)!,
                record.GetRawValue<T2>(fieldName2)!,
                record.GetRawValue<T3>(fieldName3)!,
                record.GetRawValue<T4>(fieldName4)!
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldNames">The names of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?) GetRawTuple<T1, T2, T3, T4>(this IDataGenerationRecord record, string[] fieldNames)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
        {
            AssertFieldCount(fieldNames, 4);
            return GetRawTuple<T1, T2, T3, T4>(
                record,
                fieldNames[0],
                fieldNames[1],
                fieldNames[2],
                fieldNames[3]
                );
        }

        #endregion

        #region GetRawTuple<T1, T2, T3, T4, T5>

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndex1">The index of the first field.</param>
        /// <param name="fieldIndex2">The index of the second field.</param>
        /// <param name="fieldIndex3">The index of the third field.</param>
        /// <param name="fieldIndex4">The index of the fourth field.</param>
        /// <param name="fieldIndex5">The index of the fifth field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?) GetRawTuple<T1, T2, T3, T4, T5>(
            this IDataGenerationRecord record,
            int fieldIndex1,
            int fieldIndex2,
            int fieldIndex3,
            int fieldIndex4,
            int fieldIndex5
            )
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            return (
                record.GetRawValue<T1>(fieldIndex1)!,
                record.GetRawValue<T2>(fieldIndex2)!,
                record.GetRawValue<T3>(fieldIndex3)!,
                record.GetRawValue<T4>(fieldIndex4)!,
                record.GetRawValue<T5>(fieldIndex5)!
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndexes">The indexes of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?) GetRawTuple<T1, T2, T3, T4, T5>(this IDataGenerationRecord record, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            AssertFieldCount(fieldIndexes, 5);
            return GetRawTuple<T1, T2, T3, T4, T5>(
                record,
                fieldIndexes[0],
                fieldIndexes[1],
                fieldIndexes[2],
                fieldIndexes[3],
                fieldIndexes[4]
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?) GetRawTuple<T1, T2, T3, T4, T5>(
            this IDataGenerationRecord record,
            string fieldName1,
            string fieldName2,
            string fieldName3,
            string fieldName4,
            string fieldName5
            )
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            return (
                record.GetRawValue<T1>(fieldName1)!,
                record.GetRawValue<T2>(fieldName2)!,
                record.GetRawValue<T3>(fieldName3)!,
                record.GetRawValue<T4>(fieldName4)!,
                record.GetRawValue<T5>(fieldName5)!
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldNames">The names of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?) GetRawTuple<T1, T2, T3, T4, T5>(this IDataGenerationRecord record, string[] fieldNames)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
        {
            AssertFieldCount(fieldNames, 5);
            return GetRawTuple<T1, T2, T3, T4, T5>(
                record,
                fieldNames[0],
                fieldNames[1],
                fieldNames[2],
                fieldNames[3],
                fieldNames[4]
                );
        }

        #endregion

        #region GetRawTuple<T1, T2, T3, T4, T5, T6>

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndex1">The index of the first field.</param>
        /// <param name="fieldIndex2">The index of the second field.</param>
        /// <param name="fieldIndex3">The index of the third field.</param>
        /// <param name="fieldIndex4">The index of the fourth field.</param>
        /// <param name="fieldIndex5">The index of the fifth field.</param>
        /// <param name="fieldIndex6">The index of the sixth field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?) GetRawTuple<T1, T2, T3, T4, T5, T6>(
            this IDataGenerationRecord record,
            int fieldIndex1,
            int fieldIndex2,
            int fieldIndex3,
            int fieldIndex4,
            int fieldIndex5,
            int fieldIndex6
            )
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            return (
                record.GetRawValue<T1>(fieldIndex1)!,
                record.GetRawValue<T2>(fieldIndex2)!,
                record.GetRawValue<T3>(fieldIndex3)!,
                record.GetRawValue<T4>(fieldIndex4)!,
                record.GetRawValue<T5>(fieldIndex5)!,
                record.GetRawValue<T6>(fieldIndex6)!
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndexes">The indexes of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?) GetRawTuple<T1, T2, T3, T4, T5, T6>(this IDataGenerationRecord record, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            AssertFieldCount(fieldIndexes, 6);
            return GetRawTuple<T1, T2, T3, T4, T5, T6>(
                record,
                fieldIndexes[0],
                fieldIndexes[1],
                fieldIndexes[2],
                fieldIndexes[3],
                fieldIndexes[4],
                fieldIndexes[5]
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?) GetRawTuple<T1, T2, T3, T4, T5, T6>(
            this IDataGenerationRecord record,
            string fieldName1,
            string fieldName2,
            string fieldName3,
            string fieldName4,
            string fieldName5,
            string fieldName6
            )
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            return (
                record.GetRawValue<T1>(fieldName1)!,
                record.GetRawValue<T2>(fieldName2)!,
                record.GetRawValue<T3>(fieldName3)!,
                record.GetRawValue<T4>(fieldName4)!,
                record.GetRawValue<T5>(fieldName5)!,
                record.GetRawValue<T6>(fieldName6)!
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldNames">The names of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?) GetRawTuple<T1, T2, T3, T4, T5, T6>(this IDataGenerationRecord record, string[] fieldNames)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
        {
            AssertFieldCount(fieldNames, 6);
            return GetRawTuple<T1, T2, T3, T4, T5, T6>(
                record,
                fieldNames[0],
                fieldNames[1],
                fieldNames[2],
                fieldNames[3],
                fieldNames[4],
                fieldNames[5]
                );
        }

        #endregion

        #region GetRawTuple<T1, T2, T3, T4, T5, T6, T7>

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndex1">The index of the first field.</param>
        /// <param name="fieldIndex2">The index of the second field.</param>
        /// <param name="fieldIndex3">The index of the third field.</param>
        /// <param name="fieldIndex4">The index of the fourth field.</param>
        /// <param name="fieldIndex5">The index of the fifth field.</param>
        /// <param name="fieldIndex6">The index of the sixth field.</param>
        /// <param name="fieldIndex7">The index of the seventh field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7>(
            this IDataGenerationRecord record,
            int fieldIndex1,
            int fieldIndex2,
            int fieldIndex3,
            int fieldIndex4,
            int fieldIndex5,
            int fieldIndex6,
            int fieldIndex7
            )
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            return (
                record.GetRawValue<T1>(fieldIndex1)!,
                record.GetRawValue<T2>(fieldIndex2)!,
                record.GetRawValue<T3>(fieldIndex3)!,
                record.GetRawValue<T4>(fieldIndex4)!,
                record.GetRawValue<T5>(fieldIndex5)!,
                record.GetRawValue<T6>(fieldIndex6)!,
                record.GetRawValue<T7>(fieldIndex7)!
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndexes">The indexes of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7>(this IDataGenerationRecord record, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            AssertFieldCount(fieldIndexes, 7);
            return GetRawTuple<T1, T2, T3, T4, T5, T6, T7>(
                record,
                fieldIndexes[0],
                fieldIndexes[1],
                fieldIndexes[2],
                fieldIndexes[3],
                fieldIndexes[4],
                fieldIndexes[5],
                fieldIndexes[6]
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <param name="fieldName7">The name of the seventh field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7>(
            this IDataGenerationRecord record,
            string fieldName1,
            string fieldName2,
            string fieldName3,
            string fieldName4,
            string fieldName5,
            string fieldName6,
            string fieldName7
            )
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            return (
                record.GetRawValue<T1>(fieldName1)!,
                record.GetRawValue<T2>(fieldName2)!,
                record.GetRawValue<T3>(fieldName3)!,
                record.GetRawValue<T4>(fieldName4)!,
                record.GetRawValue<T5>(fieldName5)!,
                record.GetRawValue<T6>(fieldName6)!,
                record.GetRawValue<T7>(fieldName7)!
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldNames">The names of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7>(this IDataGenerationRecord record, string[] fieldNames)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
        {
            AssertFieldCount(fieldNames, 7);
            return GetRawTuple<T1, T2, T3, T4, T5, T6, T7>(
                record,
                fieldNames[0],
                fieldNames[1],
                fieldNames[2],
                fieldNames[3],
                fieldNames[4],
                fieldNames[5],
                fieldNames[6]
                );
        }

        #endregion

        #region GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8>

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <typeparam name="T8">The value type of the eighth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndex1">The index of the first field.</param>
        /// <param name="fieldIndex2">The index of the second field.</param>
        /// <param name="fieldIndex3">The index of the third field.</param>
        /// <param name="fieldIndex4">The index of the fourth field.</param>
        /// <param name="fieldIndex5">The index of the fifth field.</param>
        /// <param name="fieldIndex6">The index of the sixth field.</param>
        /// <param name="fieldIndex7">The index of the seventh field.</param>
        /// <param name="fieldIndex8">The index of the eighth field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8>(
            this IDataGenerationRecord record,
            int fieldIndex1,
            int fieldIndex2,
            int fieldIndex3,
            int fieldIndex4,
            int fieldIndex5,
            int fieldIndex6,
            int fieldIndex7,
            int fieldIndex8
            )
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            return (
                record.GetRawValue<T1>(fieldIndex1)!,
                record.GetRawValue<T2>(fieldIndex2)!,
                record.GetRawValue<T3>(fieldIndex3)!,
                record.GetRawValue<T4>(fieldIndex4)!,
                record.GetRawValue<T5>(fieldIndex5)!,
                record.GetRawValue<T6>(fieldIndex6)!,
                record.GetRawValue<T7>(fieldIndex7)!,
                record.GetRawValue<T8>(fieldIndex8)!
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <typeparam name="T8">The value type of the eighth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndexes">The indexes of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8>(this IDataGenerationRecord record, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            AssertFieldCount(fieldIndexes, 8);
            return GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8>(
                record,
                fieldIndexes[0],
                fieldIndexes[1],
                fieldIndexes[2],
                fieldIndexes[3],
                fieldIndexes[4],
                fieldIndexes[5],
                fieldIndexes[6],
                fieldIndexes[7]
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <typeparam name="T8">The value type of the eighth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <param name="fieldName7">The name of the seventh field.</param>
        /// <param name="fieldName8">The name of the eighth field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8>(
            this IDataGenerationRecord record,
            string fieldName1,
            string fieldName2,
            string fieldName3,
            string fieldName4,
            string fieldName5,
            string fieldName6,
            string fieldName7,
            string fieldName8
            )
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            return (
                record.GetRawValue<T1>(fieldName1)!,
                record.GetRawValue<T2>(fieldName2)!,
                record.GetRawValue<T3>(fieldName3)!,
                record.GetRawValue<T4>(fieldName4)!,
                record.GetRawValue<T5>(fieldName5)!,
                record.GetRawValue<T6>(fieldName6)!,
                record.GetRawValue<T7>(fieldName7)!,
                record.GetRawValue<T8>(fieldName8)!
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <typeparam name="T8">The value type of the eighth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldNames">The names of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8>(this IDataGenerationRecord record, string[] fieldNames)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
        {
            AssertFieldCount(fieldNames, 8);
            return GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8>( 
                record,
                fieldNames[0],
                fieldNames[1],
                fieldNames[2],
                fieldNames[3],
                fieldNames[4],
                fieldNames[5],
                fieldNames[6],
                fieldNames[7]
                );
        }

        #endregion

        #region GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <typeparam name="T8">The value type of the eighth field.</typeparam>
        /// <typeparam name="T9">The value type of the ninth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndex1">The index of the first field.</param>
        /// <param name="fieldIndex2">The index of the second field.</param>
        /// <param name="fieldIndex3">The index of the third field.</param>
        /// <param name="fieldIndex4">The index of the fourth field.</param>
        /// <param name="fieldIndex5">The index of the fifth field.</param>
        /// <param name="fieldIndex6">The index of the sixth field.</param>
        /// <param name="fieldIndex7">The index of the seventh field.</param>
        /// <param name="fieldIndex8">The index of the eighth field.</param>
        /// <param name="fieldIndex9">The index of the ninth field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            this IDataGenerationRecord record,
            int fieldIndex1,
            int fieldIndex2,
            int fieldIndex3,
            int fieldIndex4,
            int fieldIndex5,
            int fieldIndex6,
            int fieldIndex7,
            int fieldIndex8,
            int fieldIndex9
            )
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
            where T9 : struct
        {
            return (
                record.GetRawValue<T1>(fieldIndex1)!,
                record.GetRawValue<T2>(fieldIndex2)!,
                record.GetRawValue<T3>(fieldIndex3)!,
                record.GetRawValue<T4>(fieldIndex4)!,
                record.GetRawValue<T5>(fieldIndex5)!,
                record.GetRawValue<T6>(fieldIndex6)!,
                record.GetRawValue<T7>(fieldIndex7)!,
                record.GetRawValue<T8>(fieldIndex8)!,
                record.GetRawValue<T9>(fieldIndex9)!
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <typeparam name="T8">The value type of the eighth field.</typeparam>
        /// <typeparam name="T9">The value type of the ninth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldIndexes">The indexes of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IDataGenerationRecord record, int[] fieldIndexes)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
            where T9 : struct
        {
            AssertFieldCount(fieldIndexes, 9);
            return GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
                record,
                fieldIndexes[0],
                fieldIndexes[1],
                fieldIndexes[2],
                fieldIndexes[3],
                fieldIndexes[4],
                fieldIndexes[5],
                fieldIndexes[6],
                fieldIndexes[7],
                fieldIndexes[8]
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <typeparam name="T8">The value type of the eighth field.</typeparam>
        /// <typeparam name="T9">The value type of the ninth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldName1">The name of the first field.</param>
        /// <param name="fieldName2">The name of the second field.</param>
        /// <param name="fieldName3">The name of the third field.</param>
        /// <param name="fieldName4">The name of the fourth field.</param>
        /// <param name="fieldName5">The name of the fifth field.</param>
        /// <param name="fieldName6">The name of the sixth field.</param>
        /// <param name="fieldName7">The name of the seventh field.</param>
        /// <param name="fieldName8">The name of the eighth field.</param>
        /// <param name="fieldName9">The name of the ninth field.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            this IDataGenerationRecord record,
            string fieldName1,
            string fieldName2,
            string fieldName3,
            string fieldName4,
            string fieldName5,
            string fieldName6,
            string fieldName7,
            string fieldName8,
            string fieldName9
            )
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
            where T9 : struct
        {
            return (
                record.GetRawValue<T1>(fieldName1)!,
                record.GetRawValue<T2>(fieldName2)!,
                record.GetRawValue<T3>(fieldName3)!,
                record.GetRawValue<T4>(fieldName4)!,
                record.GetRawValue<T5>(fieldName5)!,
                record.GetRawValue<T6>(fieldName6)!,
                record.GetRawValue<T7>(fieldName7)!,
                record.GetRawValue<T8>(fieldName8)!,
                record.GetRawValue<T9>(fieldName9)!
                );
        }

        /// <summary>
        /// GetRaws the values of multiple specified fields.
        /// </summary>
        /// <typeparam name="T1">The value type of the first field.</typeparam>
        /// <typeparam name="T2">The value type of the second field.</typeparam>
        /// <typeparam name="T3">The value type of the third field.</typeparam>
        /// <typeparam name="T4">The value type of the fourth field.</typeparam>
        /// <typeparam name="T5">The value type of the fifth field.</typeparam>
        /// <typeparam name="T6">The value type of the sixth field.</typeparam>
        /// <typeparam name="T7">The value type of the seventh field.</typeparam>
        /// <typeparam name="T8">The value type of the eighth field.</typeparam>
        /// <typeparam name="T9">The value type of the ninth field.</typeparam>
        /// <param name="record"></param>
        /// <param name="fieldNames">The names of the fields.</param>
        /// <returns></returns>
        public static (T1?, T2?, T3?, T4?, T5?, T6?, T7?, T8?, T9?) GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IDataGenerationRecord record, string[] fieldNames)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            where T4 : struct
            where T5 : struct
            where T6 : struct
            where T7 : struct
            where T8 : struct
            where T9 : struct
        {
            AssertFieldCount(fieldNames, 9);
            return GetRawTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
                record,
                fieldNames[0],
                fieldNames[1],
                fieldNames[2],
                fieldNames[3],
                fieldNames[4],
                fieldNames[5],
                fieldNames[6],
                fieldNames[7],
                fieldNames[8]
                );
        }

        #endregion



        private static void AssertFieldCount(int[] fieldIndexes, int expectedCount)
        {
            if (fieldIndexes.Length != expectedCount)
            {
                throw new ArgumentException("The number of fields specified does not match.", nameof(fieldIndexes));
            }
        }

        private static void AssertFieldCount(string[] fieldNames, int expectedCount)
        {
            if (fieldNames.Length != expectedCount)
            {
                throw new ArgumentException("The number of fields specified does not match.", nameof(fieldNames));
            }
        }

    }

}
