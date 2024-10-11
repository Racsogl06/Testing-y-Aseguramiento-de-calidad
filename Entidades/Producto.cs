using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Producto(string nombre, decimal precio, int stock)
        {
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }

        public void ReducirStock(int cantidad)
        {
            if (cantidad > Stock)
            {
                throw new InvalidOperationException("Stock insuficiente.");
            }

            Stock -= cantidad; // Restar la cantidad del stock actual
        }

        public void AumentarStock(int cantidad)
        {
            Stock += cantidad; // Aumentar el stock al devolver el producto
        }
    }
}
