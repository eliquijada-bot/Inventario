using Inventario.Entidades;
using System.Data;

namespace Inventario.Datos
{
    public interface IProductoDAL
    {
        void Guardar(Producto producto);
        void Editar(Producto producto);
        void Eliminar(int id);
        DataTable ListarConCategoria();
        Producto? ObtnerPorId(int id);
        bool ExistePorNombre(string nombre, int categoriaId, int? excluirId = null);
    }
}
