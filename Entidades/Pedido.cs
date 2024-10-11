using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public class Pedido
    {
        public List<(Producto producto, int cantidad)> Items { get; set; }

        public const decimal Impuesto = 0.12m;

        public Pedido()
        {
            this.Items = new List<(Producto producto, int cantidad)>();
        }

        public void AgregarProducto(Producto producto, int cantidad)
        {
            if (producto.Stock < cantidad)
            {
                throw new InvalidOperationException("No hay suficiente Stock Disponible.");
            }

            this.Items.Add((producto, cantidad));
        }

        public decimal CalcularTotal()
        {
            decimal subTotal = 0;
            foreach (var item in this.Items)
            {
                decimal precioItem = item.producto.Precio * item.cantidad;
                if (item.cantidad > 10)
                {
                    precioItem *= 0.9m;
                }
                subTotal += precioItem;
            }
            decimal totalConImpuesto = subTotal + (subTotal * Impuesto);
            return totalConImpuesto;
        }

        public void ProcesarPedido()
        {
            foreach (var item in Items)
            {
                item.producto.ReducirStock(item.cantidad);
            }
        }

        // Método para prestar un producto (préstamo de libros)
        public void PrestarProducto(Producto producto, int cantidad)
        {
            if (producto.Stock < cantidad)
            {
                throw new InvalidOperationException("Stock insuficiente para el préstamo.");
            }

            // Simula que se presta el libro, pero se deja constancia del préstamo
            producto.ReducirStock(cantidad);
            Console.WriteLine($"Se han prestado {cantidad} unidades de {producto.Nombre}.");
        }

        // Método para devolver un producto (devolución de libros)
        public void DevolverProducto(Producto producto, int cantidad)
        {
            // Al devolver, simplemente se aumenta el stock
            producto.AumentarStock(cantidad);
            Console.WriteLine($"Se han devuelto {cantidad} unidades de {producto.Nombre}.");
        }
    }
}
