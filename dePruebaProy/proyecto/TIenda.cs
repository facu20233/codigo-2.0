using System;
using System.Collections.Generic;
using System.Linq;

public class Tienda
{
    private List<Producto> _inventario;

    public Tienda(List<Producto> inventarioInicial)
    {
        _inventario = inventarioInicial ?? new List<Producto>();
    }

    // Método para agregar un producto al inventario
    public void AgregarProducto(Producto producto)
    {
        if (producto == null)
        {
            throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");
        }

        _inventario.Add(producto);
    }

    // Método para buscar un producto por su nombre
    public Producto BuscarProducto(string nombre)
    {
        // 2.1
        var producto = _inventario.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (producto == null)
        {
            // 2.1
            throw new KeyNotFoundException($"El producto '{nombre}' no fue encontrado en el inventario.");
        }
        return producto;
    }


    public void EliminarProducto(Producto producto)
    {
        // 2.2
        if (!_inventario.Contains(producto))
        {
            throw new InvalidOperationException("El producto no existe en el inventario.");
        }
        _inventario.Remove(producto);
    }


    // Método para calcular el total del carrito
    public decimal CalcularTotalCarrito(List<Producto> carrito)
    {
        return carrito.Sum(p => p.Precio);
    }

    public void AplicarDescuento(string nombreProducto, decimal porcentajeDescuento)
    {
        var producto = BuscarProducto(nombreProducto);
        if (producto != null)
        {
            producto.ActualizarPrecio(producto.Precio * (1 - porcentajeDescuento / 100));
        }
    }

}
