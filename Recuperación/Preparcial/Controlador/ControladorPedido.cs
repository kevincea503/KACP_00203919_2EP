using System;
using System.Data;
using System.Windows.Forms;

namespace Preparcial.Controlador
{
    public static class ControladorPedido
    {
        public static DataTable GetPedidosUsuarioTable(int id)
        {
            DataTable pedidos = null;

            try
            { 
                pedidos = ConexionBD.EjecutarConsulta(
                    "SELECT p.idPedido, i.nombreart, p.cantidad, i.precio, (i.precio * p.cantidad) AS total" +
                    " FROM PEDIDO p, INVENTARIO i, USUARIO u" + // se cambió nombreArticulo a nombreart
                    " WHERE p.idArticulo = i.idarticulo" + // cambiando idArticulo a idarticulo y idArticulo a idarticulo 
                    " AND p.idusuario = u.idusuario" +  // se cambió idUsuario a idusuario
                    $" AND u.idusuario = {id}");
                
            
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            return pedidos;

        }

        public static DataTable GetPedidosTable()
        {
            DataTable pedidos = null;

            try
            {
                pedidos = ConexionBD.EjecutarConsulta("SELECT p.idPedido, i.nombreart, p.cantidad, i.precio, (i.precio * p.cantidad) AS total" +
                                            " FROM PEDIDO p, INVENTARIO i, USUARIO u" +
                                            " WHERE p.idPedido = i.idarticulo" +
                                            " AND p.idusuario = u.idusuario");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

            return pedidos;
        }

        public static void HacerPedido(int idUsuario, int idArticulo, int cantidad) // se cambiaron los tipos de variables a enteras
        {
            try
            {
                ConexionBD.EjecutarComando("INSERT INTO PEDIDO(idUsuario, idarticulo, cantidad) " + //se cambio idUsuario a idusuario
                    $"VALUES({idUsuario}, {idArticulo}, {cantidad})");                              // idArticulo a idarticulo
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }
    }
}
