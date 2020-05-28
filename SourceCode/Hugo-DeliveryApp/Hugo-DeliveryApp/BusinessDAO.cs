using System;
using System.Collections.Generic;
using System.Data;

namespace Hugo_DeliveryApp
{
    public class BusinessDAO
    {
        public static List<Business> getLista()
        {
            DataTable dt = ConnectioDB.ExecuteQuery("SELECT * FROM BUSINESS");
            List<Business> lista = new List<Business>();

            foreach (DataRow columna in dt.Rows)
            {
                var b = new Business();
                b.id_Business = Convert.ToInt32(columna[0].ToString());
                b.name = columna[1].ToString();
                b.descrption = columna[2].ToString();
                lista.Add(b);
            }

            return lista;
        }
        
        public static void Nuevo(string nombre, string desc)
        {
            string sql = String.Format(
                "INSERT INTO BUSINESS(name, description) " +
                "VALUES('{0}', '{1}');",
                nombre, desc);

            ConnectioDB.ExecuteNonQuery(sql);
        }
        
        public static void eliminar(string nombre)
        {
            string sql = String.Format(
                "DELETE FROM BUSINESS WHERE name='{0}';",
                nombre);
            
            ConnectioDB. ExecuteNonQuery(sql); 
        }
    }
}