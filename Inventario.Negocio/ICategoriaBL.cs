using Inventario.Entidades;
using System.Data;

namespace Inventario.Negocio
{
    public interface ICategoriaBL
    {
        void Guardar(Categoria categoria);
        void Editar(Categoria categoria);
        void Eliminar(int id);
        DataTable Listar();
        Categoria? ObtnerPorId(int id);
    }
}
