using Inventario.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Inventario.Datos
{
    public class CategoriaDAL : ICategoriaDAL
    {
        public void Editar(Categoria categoria)
        {
            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            const string SQL = "UPDATE Categorias SET Nombre = @Nombre WHERE Id = @Id";
            using SqlCommand cmd = new(SQL, cn);
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = categoria.Nombre;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = categoria.Id;
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            const string SQL = "DELETE FROM Categorias WHERE Id = @Id";
            using SqlCommand cmd = new(SQL, cn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
        }

        public bool ExistePorNombre(string nombre, int? excluirId = null)
        {
            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            string sql = "SELECT COUNT(*) FROM Categorias WHERE Nombre = @Nombre ";

            if (excluirId.HasValue)
                sql += "AND Id <> @Id";

            using SqlCommand cmd = new(sql, cn);
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = nombre;

            if (excluirId.HasValue)
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = excluirId;

            int total = Convert.ToInt32(cmd.ExecuteScalar());

            return total > 0;
        }

        public void Guardar(Categoria categoria)
        {
            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            const string SQL = "INSERT INTO Categorias(Nombre) VALUES(@Nombre)";

            using SqlCommand cmd = new(SQL, cn);
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = categoria.Nombre;

            cmd.ExecuteNonQuery();
        }

        public void GuardarSP(Categoria categoria)
        {
            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            const string SQL = "sp_GuardarCategoria";

            using SqlCommand cmd = new(SQL, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = categoria.Nombre;

            cmd.ExecuteNonQuery();
        }

        public DataTable Listar()
        {
            DataTable tabla = new();

            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            const string SQL = "SELECT Id, Nombre FROM Categorias ORDER BY Nombre";

            using SqlDataAdapter da = new(SQL, cn);
            da.Fill(tabla);

            return tabla;
        }

        public Categoria? ObtnerPorId(int id)
        {
            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            const string SQL = "SELECT Id, Nombre FROM Categorias WHERE Id = @Id";
            
            using SqlCommand cmd = new(SQL, cn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            using SqlDataReader dr = cmd.ExecuteReader();

            if (!dr.Read()) return null;

            return new Categoria
            {
                Id = Convert.ToInt32(dr["Id"]),
                Nombre = dr["Nombre"]?.ToString() ?? string.Empty
            };
        }

        public bool TieneProductosRelacionados(int categoriaId)
        {
            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            string sql = "SELECT COUNT(*) FROM Productos WHERE CategoriaId = @CategoriaId";

            using SqlCommand cmd = new(sql, cn);
            cmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = categoriaId;

            int total = Convert.ToInt32(cmd.ExecuteScalar());

            return total > 0;
        }
    }
}
