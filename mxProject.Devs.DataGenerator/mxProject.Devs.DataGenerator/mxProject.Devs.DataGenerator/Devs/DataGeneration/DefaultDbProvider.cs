using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Default DbProvider. Use System.Data.OleDb.
    /// </summary>
    public class DefaultDbProvider : IDbProvider
    {

        /// <summary>
        /// Singleton instance.
        /// </summary>
        internal static readonly DefaultDbProvider Instance = new DefaultDbProvider();

        /// <inheritdoc/>
        public IDbConnection CreateConnection(string connectionString, string? connectionTypeName = null)
        {
            return new OleDbConnection(connectionString);
        }

    }

}
