using System;
using System.Data.Odbc;
namespace QueryBuilder.OdbcConnection
{
    public class DremioOdbcConnection
    {
        public void odbcConnection(string uid, string pwd, string host = "127.0.0.1", int port = 31010)
        {
            var driver = "{Dremio Connector}";
            var cnn = new System.Data.Odbc.OdbcConnection($"Driver={driver};ConnectionType=Direct;HOST={host};PORT={port};AuthenticationType=Plain;UID={uid};PWD={pwd}");
            var sql = "SELECT cliente.id as cliente_id,cliente.nombre as cliente_nombre,compra.id as compra_id,producto.id as producto_id,producto.nombre as producto_nombre,vendedor.id as vendedor_id,vendedor.nombre as vendedor_nombre FROM MysqlSource.compra.compra as compra INNER JOIN MysqlSource.compra.cliente as cliente ON compra.cliente_id = cliente.id INNER JOIN MysqlSource.compra.grupoproducto_producto as grupoproducto_producto ON compra.id_grupo_producto = grupoproducto_producto.grupo_id INNER JOIN MysqlSource.compra.producto as producto ON producto.id = grupoproducto_producto.producto_id INNER JOIN MysqlSource.compra.vendedor as vendedor ON compra.vendedor_id = vendedor.id  ORDER BY cliente.id,compra.id,producto.id,vendedor.id";
            cnn.Open();
            var command = cnn.CreateCommand();
            command.CommandText = sql;
            var dbreader = command.ExecuteReader();
            
            Console.Write(":");
            for (int i = 0; i < dbreader.FieldCount; i++)
            {
                var name = dbreader.GetName(i);
                
                Console.Write(name+":");
            }
            Console.WriteLine();
            while (dbreader.Read())
            {
                Console.Write(":");
                for (int i = 0; i < dbreader.FieldCount; i++)
                {
                    var dbvalue = dbreader.GetString(i);
                    Console.Write(dbvalue+":");
                    var value = dbreader.GetValue(i);
                }
                Console.WriteLine();
            }
            
        }
    }
}
