// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Tienda
// {
//     private List<IProducto> _inventario;

//     public Tienda(List<IProducto> inventarioInicial) 
//     {
//         _inventario = inventarioInicial ?? new List<IProducto>();
//     }

//     // Método para agregar un producto al inventario
//     public void AgregarProducto(IProducto producto)
//     {
//         if (producto == null)
//         {
//             throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");
//         }

//         _inventario.Add(producto);
//     }

//     // Método para buscar un producto por su nombre
//     public IProducto BuscarProducto(string nombre)
//     {
//         var producto = _inventario.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
//         if (producto == null)
//         {
//             throw new KeyNotFoundException($"El producto '{nombre}' no fue encontrado en el inventario.");
//         }
//         return producto;
//     }

//     // Método para eliminar un producto del inventario
//     public void EliminarProducto(IProducto producto)
//     {
//         if (!_inventario.Contains(producto))
//         {
//             throw new InvalidOperationException("El producto no existe en el inventario.");
//         }
//         _inventario.Remove(producto);
//     }

//     // Método para calcular el total del carrito
//     public decimal CalcularTotalCarrito(List<IProducto> carrito)
//     {
//         return carrito.Sum(p => p.Precio);
//     }

//     // Método para aplicar un descuento a un producto específico
//     public void AplicarDescuento(string nombreProducto, decimal porcentajeDescuento)
//     {
//         var producto = BuscarProducto(nombreProducto);
//         if (producto != null)
//         {
//             producto.ActualizarPrecio(producto.Precio * (1 - porcentajeDescuento / 100));
//         }
//     }
// }
