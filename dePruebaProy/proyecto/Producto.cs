// productos.cs

public interface IProducto
{
    string Nombre { get; }
    decimal Precio { get; set; }
    string Categoria { get; }
    void ActualizarPrecio(decimal nuevoPrecio);
}

public class Producto : IProducto
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public string Categoria { get; set; }

    public Producto(string nombre, decimal precio, string categoria)
    {
        Nombre = nombre;
        Precio = precio;
        Categoria = categoria;
    }

    // Método para actualizar el precio
    // 2.3
    public void ActualizarPrecio(decimal nuevoPrecio)
    {
        if (nuevoPrecio < 0)
        {
            throw new ArgumentException("El precio no puede ser negativo.");
        }
        Precio = nuevoPrecio;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Producto other = (Producto)obj;
        return Nombre == other.Nombre && Precio == other.Precio && Categoria == other.Categoria;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Nombre, Precio, Categoria);
    }
}
