using System;
using System.Collections.Generic;
using System.Data;

namespace Hugo_DeliveryApp
{
    public class OrdenDAO
    {
        public static List<Orden> getLista()
        {
            DataTable dt = ConnectioDB.ExecuteQuery("SELECT * FROM APPORDER");
            List<Orden> lista = new List<Orden>();

            foreach (DataRow columna in dt.Rows)
            {
                var o = new Orden();
                o.idorder = Convert.ToInt32(columna[0].ToString());
                o.createdate = DateTime.Parse(columna[1].ToString());  
                o.idproduct = Convert.ToInt32(columna[2].ToString());
                o.idaddres = Convert.ToInt32(columna[3].ToString());
                lista.Add(o);
            }

            return lista;
        }
        
        public static void Nuevo(DateTime fecha, int idprod, int iddir)
        {
            string sql = String.Format(
                "INSERT INTO APPORDER(createDate, idProduct, idAddress) " +
                "VALUES('{0}', {1}, {2});",
                fecha, idprod, iddir);

            ConnectioDB.ExecuteNonQuery(sql);
        }
        
        public static void eliminar(int idPed)
        {
            string sql = String.Format(
                "DELETE FROM APPORDER WHERE idOrder='{0}';",
                idPed);
            
            ConnectioDB. ExecuteNonQuery(sql); 
        }
    }
}