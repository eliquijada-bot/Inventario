using Inventario.Entidades;
using System.Data;

namespace Inventario.Negocio
{
    public interface IProductoBL
    {
        void Guardar(Producto producto);
        void Editar(Producto producto);
        void Eliminar(int id);
        DataTable ListarConCategoria();
        Producto? ObtnerPorId(int id);
    }
}
