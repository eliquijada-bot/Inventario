
using Inventario.Datos;
using Inventario.Entidades;
using System.Data;

namespace Inventario.Negocio
{
    public class ProductoBL : IProductoBL
    {
        private readonly IProductoDAL _productoDAL;

        public ProductoBL(IProductoDAL productoDAL)
        {
            _productoDAL = productoDAL;
        }

        public void Editar(Producto producto)
        {
            if (producto.Id <= 0)
                throw new BussinesException("El producto seleccionado no es valido");

            Validar(producto);

            string nombre = producto.Nombre.Trim();

            if (_productoDAL.ExistePorNombre(nombre, producto.CategoriaId, producto.Id))
                throw new BussinesException("Ya existe un producto con ese nombre, en la categoria seleccionada");

            producto.Nombre = nombre;

            _productoDAL.Editar(producto);
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new BussinesException("El producto seleccionado no es válido.");

            _productoDAL.Eliminar(id);
        }

        public void Guardar(Producto producto)
        {
            Validar(producto);

            string nombre = producto.Nombre.Trim();

            if (_productoDAL.ExistePorNombre(nombre, producto.CategoriaId))
                throw new BussinesException("Ya existe un producto con ese nombre, en la categoria seleccionada");

            producto.Nombre = nombre;

            _productoDAL.Guardar(producto);
        }

        public DataTable ListarConCategoria()
        {
            return _productoDAL.ListarConCategoria();
        }

        public Producto? ObtnerPorId(int id)
        {
            if (id <= 0)
                throw new BussinesException("El producto seleccionado no es válido.");

            return _productoDAL.ObtnerPorId(id);
        }

        private static void Validar(Producto producto) {
            
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new BussinesException("La categoria es obligatoria");

            if (producto.Precio <= 0)
                throw new BussinesException("El precio debe ser mayor que cero");

            if (producto.Stock < 0)
                throw new BussinesException("El stock no puede ser negativo");

            if (producto.CategoriaId <= 0)
                throw new BussinesException("Debe seleccionar una categoria");
        }

    }
}
