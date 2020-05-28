using System;
using System.Collections.Generic;
using System.Data;

namespace Hugo_DeliveryApp
{
    public class ProductDAO
    {
        public static List<Product> getLista()
        {
            DataTable dt = ConnectioDB.ExecuteQuery("SELECT * FROM PRODUCT");
            List<Product> lista = new List<Product>();

            foreach (DataRow columna in dt.Rows)
            {
                var p = new Product();
                p.id_product = Convert.ToInt32(columna[0].ToString());
                p.id_business = Convert.ToInt32(columna[1].ToString());
                p.name = columna[2].ToString();
                lista.Add(p);
            }

            return lista;
        }
        
        
        public static void Nuevo(int idprod, string nombre)
        {
            string sql = String.Format(
                "INSERT INTO Product(idbusiness, name) " +
                "VALUES({0}, '{1}');",
                idprod, nombre);

            ConnectioDB.ExecuteNonQuery(sql);
        }

        
        public static void eliminar(string prod)
        {
            string sql = String.Format(
                "DELETE FROM PRODUCT WHERE name='{0}';",
                prod);
            
            ConnectioDB. ExecuteNonQuery(sql); 
        }
    }
}