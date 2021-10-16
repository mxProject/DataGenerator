using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace mxProject.Devs.DataGeneration
{

    /// <summary>
    /// Provides the functionality needed to activate database objects.
    /// </summary>
    public interface IDbProvider
    {

        /// <summary>
        /// Create a database connection.
        /// </summary>
        /// <param name="connectionString">The connection string to the datasource.</param>
        /// <param name="connectionTypeName">The type name of the database connection.</param>
        /// <returns></returns>
        IDbConnection CreateConnection(string connectionString, string? connectionTypeName = null);

    }

}
