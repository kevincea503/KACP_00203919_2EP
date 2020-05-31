using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparcial.Modelo
{
    public class Inventario
    {
        int idArticulo { get; } // el id debe ser de tipo entero, así se definió en la base de datos
        string producto { get; }
        string descripcion { get; }
        decimal precio { get; } // el precio debe se ser decimal
        int stock { get; } // el stock se cambió a entero

        public Inventario(int idArticulo, string producto, string descripcion, decimal precio, int stock)
        {
            this.idArticulo = idArticulo;
            this.producto = producto;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }
    }
}
