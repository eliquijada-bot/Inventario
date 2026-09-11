using Inventario.Datos;
using Inventario.Entidades;
using System.Data;

namespace Inventario.Negocio
{
    public class CategoriaBL : ICategoriaBL
    {

        private readonly ICategoriaDAL _categoriaDAL;

        public CategoriaBL(ICategoriaDAL categoriaDAL)
        {
            _categoriaDAL = categoriaDAL;
        }

        public void Editar(Categoria categoria)
        {
            if (categoria.Id <= 0)
                throw new BussinesException("La categoria seleccionada no es valida");

            if (string.IsNullOrWhiteSpace(categoria.Nombre))
                throw new BussinesException("La categoria es obligatoria");

            string nombre = categoria.Nombre.Trim();

            if (_categoriaDAL.ExistePorNombre(nombre, categoria.Id))
                throw new BussinesException("Ya existe una categoria con ese nombre");

            categoria.Nombre = nombre;

            _categoriaDAL.Editar(categoria);
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new BussinesException("La categoria seleccionada no es valida");

            if(_categoriaDAL.TieneProductosRelacionados(id))
                throw new BussinesException("No se puede eliminar la categoria porque tiene producto relacionado");

            _categoriaDAL.Eliminar(id);
        }

        public void Guardar(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nombre))
                throw new BussinesException("La categoria es obligatoria");

            string nombre = categoria.Nombre.Trim();

            if (_categoriaDAL.ExistePorNombre(nombre))
                throw new BussinesException("Ya existe una categoria con ese nombre");

            categoria.Nombre = nombre;

            _categoriaDAL.Guardar(categoria);
        }

        public DataTable Listar() => _categoriaDAL.Listar();

        public Categoria? ObtnerPorId(int id)
        {
            if (id <= 0)
                throw new BussinesException("La categoria seleccionada no es valida");

            return _categoriaDAL.ObtnerPorId(id);
        }
    }
}
