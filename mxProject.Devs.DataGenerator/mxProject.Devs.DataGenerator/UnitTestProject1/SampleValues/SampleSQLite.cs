using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;

using mxProject.Devs.DataGeneration;

namespace UnitTestProject1.SampleValues
{

    internal static class SampleSQLite
    {

        internal static IDbProvider CreateProvider(IDbConnection? knownConnection = null)
        {
            return new SampleSQLiteProvider(knownConnection);
        }

        private class SampleSQLiteProvider : IDbProvider
        {
            internal SampleSQLiteProvider(IDbConnection? knownConnection = null)
            {
                m_KnownConnection = knownConnection;
            }

            private readonly IDbConnection? m_KnownConnection;

            public IDbConnection CreateConnection(string connectionString, string? connectionTypeName = null)
            {
                if (m_KnownConnection != null) { return m_KnownConnection; }

                var builder = new SQLiteConnectionStringBuilder { DataSource = connectionString };

                return new SQLiteConnection(builder.ToString());
            }
        }

        internal static void PrepareSampleTable(IDbConnection connection)
        {

            if ((connection.State & ConnectionState.Open) != ConnectionState.Open) { connection.Open(); }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"

drop table if exists SAMPLE_TABLE

";
                command.ExecuteNonQuery();
            }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"

create table if not exists SAMPLE_TABLE
(
    FIELD1 integer not null,
    FIELD2 integer not null,
    FIELD3 integer,
    FIELD4 real not null,
    FIELD5 real not null,
    FIELD6 real,
    FIELD7 text not null,
    FIELD8 text not null,
    FIELD9 text
)

";
                command.ExecuteNonQuery();
            }

            static void Insert(IDbConnection connection, int field1, int field2, int? field3, double field4, double field5, double? field6, string field7, string field8, string? field9)
            {
                using var command = connection.CreateCommand();

                command.CommandText = @$"

insert into SAMPLE_TABLE values (
{field1}
, {field2}
, {(field3.HasValue ? field3.ToString() : "null")}
, {field4}
, {field5}
, {(field6.HasValue ? field6.ToString() : "null")}
, '{field7}'
, '{field8}'
, {(field9 != null ? $"'{field9}'" : "null")}
)

";
                command.ExecuteNonQuery();
            }

            Insert(connection, 1, 10, 100, 1.1, 1.11, 1.111, "a", "aa", "aaa");
            Insert(connection, 2, 20, null, 2.2, 2.22, null, "b", "bb", null);

        }

        internal static IDataReader GetSampleTable(IDbConnection connection)
        {
            using var command = connection.CreateCommand();

            command.CommandText = "select * from SAMPLE_TABLE";

            return command.ExecuteReader();
        }



        internal static void PrepareShopMaster(IDbConnection connection)
        {

            if ((connection.State & ConnectionState.Open) != ConnectionState.Open) { connection.Open(); }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"

drop table if exists SHOP_MASTER

";
                command.ExecuteNonQuery();
            }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"

create table if not exists SHOP_MASTER
(
    COMPANY_CODE integer not null,
    SHOP_CODE integer not null,
    SHOP_NAME text,
    TELEPHONE_NUMBER text
)

";
                command.ExecuteNonQuery();
            }

            static void Insert(IDbConnection connection, int companyCode, int shopCode, string shopName, string telephoneNumber)
            {
                using var command = connection.CreateCommand();

                command.CommandText = @$"

insert into SHOP_MASTER values ( {companyCode}, {shopCode}, '{shopName}', '{telephoneNumber}' )

";
                command.ExecuteNonQuery();
            }

            Insert(connection, 1, 1, "shop1-1", "000-0001-0001");
            Insert(connection, 1, 2, "shop1-2", "000-0001-0002");
            Insert(connection, 1, 3, "shop1-3", "000-0001-0003");
            Insert(connection, 2, 1, "shop2-1", "000-0002-0001");

        }

        internal static IDataReader GetShopMaster(IDbConnection connection)
        {
            using var command = connection.CreateCommand();

            command.CommandText = "select * from SHOP_MASTER";

            return command.ExecuteReader();
        }
    }

}
