﻿using Preparcial.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Preparcial.Controlador
{
    public static class ControladorInventario
    {
        // Metodo encargado de devolver un DataTable con todos los elementos del inventario
        public static DataTable GetProductosTable()
        {
            DataTable productos = null;

            // Solamente la consulta y conexion a la BD van en el try, ya que lo demas no puede ocasionar excepcion
            try
            {
                productos = ConexionBD.EjecutarConsulta("SELECT * FROM INVENTARIO");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

            return productos;
        }

        // Metodo que devuelve los productos en formato de List
        public static List<Inventario> GetProductos()
        {
            // Declaracion de lista y DataTable
            var productos = new List<Inventario>();
            DataTable dt = null;


            try
            { 
                // Consulta para llenar el DataTable
                dt = ConexionBD.EjecutarConsulta("SELECT * FROM INVENTARIO");

                // Por cada fila del DataTable, crear un nuevo usuario anadiendolo a la lista
                foreach (DataRow dr in dt.Rows)
                {
                    productos.Add(new Inventario
                    (
                        Convert.ToInt32(dr[0].ToString()), // el idArticulo convirtió a entero
                        dr[1].ToString(),
                        dr[2].ToString(),
                        Convert.ToDecimal(dr[3].ToString()), //el precio se convirtió a decimal
                        Convert.ToInt32(dr[4].ToString()) //el stock se convirtió a entero
                    )
                  );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            return productos;
        }

        // Metodo para anadir productos
        public static void AnadirProducto(string nombre, string descripcion, decimal precio, int stock)
        {
            try
            {
                ConexionBD.EjecutarComando("INSERT INTO INVENTARIO(nombreart, descripcion, precio, stock)" +  // se cambió nombreArticulo a nombreart, ya que así se definió en la base de datos
                    $" VALUES('{nombre}', '{descripcion}', {precio}, {stock})");

                MessageBox.Show("Se ha agregado el producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        // Metodo para eliminar productos
        public static void EliminarProducto(string id)
        {
            try
            {
                ConexionBD.EjecutarComando($"DELETE FROM INVENTARIO WHERE idarticulo = {id}");

                MessageBox.Show("Se ha eliminado el producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error" + ex.Message);
            }
        }

        // Metodo para actualizar stock de un producto
        public static void ActualizarProducto(int id, int stock)
        {
            try
            {
                ConexionBD.EjecutarComando($"UPDATE INVENTARIO SET stock = {stock} WHERE idarticulo = {id}");
                // se cambio idArticulo a idarticulo, ya que así se definió en la base de datos

                MessageBox.Show("Se ha actualizado el producto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }
    }
}
