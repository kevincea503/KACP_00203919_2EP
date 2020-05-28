using System;
using System.Collections.Generic;
using System.Data;

namespace Hugo_DeliveryApp
{
    public class DireccionDAO
    {
        public static List<Direccion> getLista()
        {
            DataTable dt = ConnectioDB.ExecuteQuery("SELECT * FROM ADDRESS");
            List<Direccion> lista = new List<Direccion>();

            foreach (DataRow columna in dt.Rows)
            {
                var d = new Direccion();
                d.idaddres = Convert.ToInt32(columna[0].ToString());
                d.iduser = Convert.ToInt32(columna[1].ToString());
                d.addres = columna[2].ToString();
                lista.Add(d);
            }

            return lista;
        }
        
        
        public static void Nuevo(int idUser, string dir)
        {
            string sql = String.Format(
                "INSERT INTO ADDRESS(iduser, address) " +
                "VALUES({0}, '{1}');",
                idUser, dir);

            ConnectioDB.ExecuteNonQuery(sql);
        }
        
        public static void actualizar(string dir, int idUser)
        {
            string sql = String.Format(
                "UPDATE ADDRESS SET address='{0}' WHERE iduser = {1};",
                dir, idUser);
            
            ConnectioDB.ExecuteNonQuery(sql);
        }
        
        public static void eliminar(string prod)
        {
            string sql = String.Format(
                "DELETE FROM ADDRESS WHERE address='{0}';",
                prod);
            
            ConnectioDB. ExecuteNonQuery(sql); 
        }
        
    }
}