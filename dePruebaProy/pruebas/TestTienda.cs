using NUnit.Framework;
using System.Collections.Generic;
using Moq;

namespace Pruebas
{
    [TestFixture]
    public class TiendaTests
    {
        private Tienda _tienda;
        private List<Producto> _productos;

        [SetUp]
        public void Setup()
        {
            // Inicializa el inventario y la tienda antes de cada prueba
            _productos = new List<Producto>
            {
                new Producto("Teclado", 50000, "Electronica"),
                new Producto("Laptop", 1100000, "Electronica")
            }.ConvertAll(p => (Producto)p); // Convertir a IProducto

            _tienda = new Tienda(_productos);
        }

        [Test]
        public void AgregarProducto_DeberiaAgregarProductoAlInventario()
        {
            // Arrange
            var nuevoProducto = new Producto("Silla Gamer", 450000, "Mobiliario");

            // Act
            _tienda.AgregarProducto(nuevoProducto);

            // Assert
            Assert.Contains(nuevoProducto, _productos);
        }

        [Test]
        public void BuscarProducto_PorNombre_ProductoExistente_DeberiaDevolverProductoCorrecto()
        {
            // Act
            var productoEncontrado = _tienda.BuscarProducto("Laptop");

            // Assert
            Assert.IsNotNull(productoEncontrado);
            Assert.AreEqual("Laptop", productoEncontrado.Nombre);
        }

        // [Test]
        // public void BuscarProducto_PorNombre_ProductoNoExistente_DeberiaDevolverNull()
        // {
        //     // Act
        //     var productoEncontrado = _tienda.BuscarProducto("Mouse");

        //     // Assert
        //     Assert.IsNull(productoEncontrado); 
        // } //corregir

        [Test]
        public void EliminarProducto_DeberiaEliminarProductoDelInventario()
        {
            // Arrange
            var productoAEliminar = _productos[0];

            // Act
            _tienda.EliminarProducto(productoAEliminar);

            // Assert
            Assert.IsFalse(_productos.Contains(productoAEliminar));
        }

        // [Test]
        // public void EliminarProducto_ProductoNoExistente_NoDeberiaHacerNada()
        // {
        //     // Arrange
        //     var productoNoExistente = new Producto("Mouse", 20000, "Electronica");

        //     // Act
        //     _tienda.EliminarProducto(productoNoExistente);

        //     // Assert
        //     Assert.IsTrue(_productos.Count == 2); // Asegurarse que el inventario sigue teniendo dos productos
        // } //corregir

        [Test]
        public void AgregarYBuscarProducto_DeberiaEncontrarElProductoAgregado()
        {
            // Arrange
            var tienda = new Tienda(new List<Producto>());
            var nuevoProducto = new Producto("Silla Gamer", 450000, "Mobiliario");

            // Act
            tienda.AgregarProducto(nuevoProducto);
            var productoEncontrado = tienda.BuscarProducto("Silla Gamer");

            // Assert
            Assert.IsNotNull(productoEncontrado);
            Assert.AreEqual(nuevoProducto.Nombre, productoEncontrado.Nombre);
        }

        // [Test]
        // public void BuscarProducto_ProductoNoExistente_DeberiaLanzarExcepcion()
        // {
        //     // Act & Assert
        //     var ex = Assert.Throws<KeyNotFoundException>(() => _tienda.BuscarProducto("Mouse"));
        //     Assert.That(ex.Message, Is.EqualTo("El producto 'Mouse' no fue encontrado en el inventario."));
        // } //corregir?

        [Test]
        public void EliminarProducto_ProductoNoExistente_DeberiaLanzarExcepcion()
        {
            // Arrange
            var productoNoExistente = new Producto("Mouse", 20000, "Electronica");

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _tienda.EliminarProducto(productoNoExistente));
            Assert.That(ex.Message, Is.EqualTo("El producto no existe en el inventario."));
        }

        [Test]
        public void ActualizarPrecio_PrecioNegativo_DeberiaLanzarExcepcion()
        {
            // Arrange
            var producto = new Producto("Monitor", 300000, "Electronica");

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => producto.ActualizarPrecio(-1000));
            Assert.That(ex.Message, Is.EqualTo("El precio no puede ser negativo."));
        }

        // ---- 3 -------

        public void AplicarDescuento_ProductoExistente_ActualizaPrecioCorrectamente()
        {
            // Arrange
            var mockProducto = new Mock<Producto>("Teclado", 1000, "Electronica");
            var productos = new List<Producto> { mockProducto.Object };
            var tienda = new Tienda(productos);

            decimal porcentajeDescuento = 10;

            // Act
            tienda.AplicarDescuento("Teclado", porcentajeDescuento);

            // Assert
            mockProducto.Verify(p => p.ActualizarPrecio(It.Is<decimal>(precio => precio == 900)), Times.Once);
        }


    }
}
