using System.Data;
using Npgsql;
namespace Hugo_DeliveryApp
{
    public static class ConnectioDB
    {
        private static string host = "127.0.0.1",
            database = "hugo",
            UserId = "postgres",
            password = "cassandra70948054";
        
        private static string CadenaConexion = 
            $"Server={host};Port=5432;User Id={UserId};Password={password};Database={database}";
        
        public static DataTable ExecuteQuery(string sql)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CadenaConexion);
            DataSet ds = new DataSet();
            
            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            
            return ds.Tables[0];

        }
        
        
        public static void ExecuteNonQuery(string sql)
        {
            NpgsqlConnection conn = new NpgsqlConnection(CadenaConexion);
            
            conn.Open();
            
            NpgsqlCommand nc = new NpgsqlCommand(sql, conn);
            nc.ExecuteNonQuery();
            
            conn.Close();
        }
    }
}