using Inventario.Entidades;
using System.Data;

namespace Inventario.Datos
{
    public interface ICategoriaDAL
    {
        void Guardar(Categoria categoria);
        void Editar(Categoria categoria);
        void Eliminar(int id);
        DataTable Listar();
        Categoria? ObtnerPorId(int id);
        bool ExistePorNombre(string nombre, int? excluirId = null);
        bool TieneProductosRelacionados(int categoriaId);
    }
}
