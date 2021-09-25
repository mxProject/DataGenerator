using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides the functionality needed for a DataRecord to read the generated values.
    /// </summary>
    public interface IDataGenerationRecord : IDataRecord
    {
        /// <summary>
        /// Gets the generated raw value of the specified field.
        /// </summary>
        /// <typeparam name="T">The type of the field.</typeparam>
        /// <param name="index">The field index.</param>
        /// <returns></returns>
        T? GetRawValue<T>(int index) where T : struct;


        /// <summary>
        /// Gets the value of the specified column as a Boolean.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        bool GetBoolean(string fieldName);

        /// <summary>
        /// Gets the 8-bit unsigned integer value of the specified column.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        byte GetByte(string fieldName);

        /// <summary>
        /// Gets the character value of the specified column.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        char GetChar(string fieldName);

        /// <summary>
        /// Gets the date and time data value of the specified field.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        DateTime GetDateTime(string fieldName);

        /// <summary>
        /// Gets the fixed-position numeric value of the specified field.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        decimal GetDecimal(string fieldName);

        /// <summary>
        /// Gets the double-precision floating point number of the specified field.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        double GetDouble(string fieldName);

        /// <summary>
        /// Gets the single-precision floating point number of the specified field.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        float GetFloat(string fieldName);

        /// <summary>
        /// Returns the GUID value of the specified field.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        Guid GetGuid(string fieldName);

        /// <summary>
        /// Gets the 16-bit signed integer value of the specified field.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        short GetInt16(string fieldName);

        /// <summary>
        /// Gets the 32-bit signed integer value of the specified field.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        int GetInt32(string fieldName);

        /// <summary>
        /// Gets the 64-bit signed integer value of the specified field.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        long GetInt64(string fieldName);

        /// <summary>
        /// Gets the string value of the specified field.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        string GetString(string fieldName);

        /// <summary>
        /// Return the value of the specified field.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        object? GetValue(string fieldName);

        /// <summary>
        /// Gets the generated raw value of the specified field.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        T? GetRawValue<T>(string fieldName) where T : struct;

        /// <summary>
        /// Return whether the specified field is set to null.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        bool IsDBNull(string fieldName);

    }

    /// <summary>
    /// Provides the functionality needed for a DataReader to read the generated values.
    /// </summary>
    public interface IDataGenerationReader : IDataReader, IDataGenerationRecord
    {
    }

}
