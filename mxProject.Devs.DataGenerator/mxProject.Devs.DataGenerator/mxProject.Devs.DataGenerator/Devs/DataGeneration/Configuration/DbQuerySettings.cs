using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Newtonsoft.Json;

namespace mxProject.Devs.DataGeneration.Configuration
{

    /// <summary>
    /// Database query settings.
    /// </summary>
    public sealed class DbQuerySettings : ICloneable
    {

        #region properties

        /// <summary>
        /// Gets or sets the command text.
        /// </summary>
        [JsonProperty("CommandText", Order = 1)]
        public string? CommandText { get; set; }

        /// <summary>
        /// Gets or sets the connection string to the data source.
        /// </summary>
        [JsonProperty("ConnectionString", Order = 2)]
        public string? ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the type name of the database provider.
        /// </summary>
        [JsonProperty("ConnectionType", Order = 3)]
        public string? ConnectionTypeName { get; set; }

        #endregion

        #region clone

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion

        /// <summary>
        /// If the settings for this instance are invalid, an exception will be thrown.
        /// </summary>
        internal void Assert()
        {
            if (CommandText == null)
            {
                throw new NullReferenceException($"The value of {nameof(CommandText)} property is null.");
            }

            if (ConnectionString == null)
            {
                throw new NullReferenceException($"The value of {nameof(ConnectionString)} property is null.");
            }

            //if (ConnectionTypeName == null)
            //{
            //    throw new NullReferenceException($"The value of {nameof(ConnectionTypeName)} property is null.");
            //}
        }

        /// <summary>
        /// Creates a DataReader instance.
        /// </summary>
        /// <returns></returns>
        internal IDataReader CreateDataReader(DataGeneratorContext context)
        {
            IDbConnection connection = context.DbProvider.CreateConnection(ConnectionString!, ConnectionTypeName!);
            IDbCommand command = connection.CreateCommand();

            command.CommandText = CommandText;

            if ((connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                connection.Open();
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            else
            {
                return command.ExecuteReader();
            }
        }

    }

}
