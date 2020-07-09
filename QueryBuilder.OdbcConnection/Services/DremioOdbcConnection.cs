using System;
using System.Data.Odbc;
namespace QueryBuilder.OdbcConnection.Services
{
    public class DremioOdbcConnection
    {
        private OdbcCommand OdbcCommand;
        public DremioOdbcConnection(string uid, string pwd,string sql ,string host = "127.0.0.1", int port = 31010)
        {
            var driver = "{Dremio Connector}";
            var cnn = new System.Data.Odbc.OdbcConnection($"Driver={driver};ConnectionType=Direct;HOST={host};PORT={port};AuthenticationType=Plain;UID={uid};PWD={pwd}");
            cnn.Open();
            var command = cnn.CreateCommand();
            OdbcCommand= command;

        }

        public void Execute(string sql) {
            OdbcCommand.CommandText = sql;
            var dbreader = OdbcCommand.ExecuteReader();

            Console.Write(":");
            for (int i = 0; i < dbreader.FieldCount; i++)
            {
                var name = dbreader.GetName(i);

                Console.Write(name + ":");
            }
            Console.WriteLine();
            while (dbreader.Read())
            {
                Console.Write(":");
                for (int i = 0; i < dbreader.FieldCount; i++)
                {
                    var dbvalue = dbreader.GetString(i);
                    Console.Write(dbvalue + ":");
                    var value = dbreader.GetValue(i);
                }
                Console.WriteLine();
            }
        }

    }
}
