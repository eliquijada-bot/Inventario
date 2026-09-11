using Inventario.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;

namespace Inventario.Datos
{
    public class ProductoDAL : IProductoDAL
    {
        public void Editar(Producto producto)
        {
            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            const string SQL = @"UPDATE Productos 
                                 SET Nombre = @Nombre,
                                     Precio = @Precio,
                                     Stock = @Stock,
                                     CategoriaId = @CategoriaId
                                 WHERE Id = @Id";

            using SqlCommand cmd = new(SQL, cn);
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = producto.Nombre;
            cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = producto.Precio;
            cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = producto.Stock;
            cmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = producto.CategoriaId;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = producto.Id;
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            const string SQL = "DELETE FROM Productos WHERE Id = @Id";
            using SqlCommand cmd = new(SQL, cn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
        }

        public bool ExistePorNombre(string nombre, int categoriaId, int? excluirId = null)
        {
            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            string sql = "SELECT COUNT(*) FROM Productos WHERE Nombre = @Nombre AND CategoriaId = @CategoriaId";

            if (excluirId.HasValue)
                sql += " AND Id <> @Id";

            using SqlCommand cmd = new(sql, cn);
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = nombre;
            cmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = categoriaId;

            if (excluirId.HasValue)
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = excluirId;

            int total = Convert.ToInt32(cmd.ExecuteScalar());

            return total > 0;
        }

        public void Guardar(Producto producto)
        {
            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            const string SQL = @"INSERT INTO Productos(Nombre, Precio, Stock, CategoriaId) 
                                 VALUES(@Nombre, @Precio, @Stock, @CategoriaId)";

            using SqlCommand cmd = new(SQL, cn);
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 100).Value = producto.Nombre;
            cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = producto.Precio;
            cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = producto.Stock;
            cmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = producto.CategoriaId;
            
            cmd.ExecuteNonQuery();
        }

        public DataTable ListarConCategoria()
        {
            DataTable tabla = new();

            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            const string SQL = @"SELECT p.Id, p.Nombre, p.Precio, p.Stock, p.CategoriaId, c.Nombre AS Categoria
                                FROM Productos p
                                INNER JOIN Categorias c ON p.CategoriaId = c.Id
                                ORDER BY p.Nombre";

            using SqlDataAdapter da = new(SQL, cn);
            da.Fill(tabla);

            return tabla;
        }

        public Producto? ObtnerPorId(int id)
        {
            using SqlConnection cn = new(ConexionDb.Cadena);
            cn.Open();

            const string SQL = @"SELECT p.Id, p.Nombre, p.Precio, p.Stock, p.CategoriaId, c.Nombre AS Categoria
                                FROM Productos p
                                INNER JOIN Categorias c ON p.CategoriaId = c.Id
                                WHERE p.Id = @Id";

            using SqlCommand cmd = new(SQL, cn);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

            using SqlDataReader dr = cmd.ExecuteReader();

            if (!dr.Read()) return null;

            return new Producto { 
                Id = Convert.ToInt32(dr["Id"]),
                Nombre = dr["Nombre"].ToString() ?? string.Empty,
                Precio = Convert.ToDecimal(dr["Precio"]),
                Stock = Convert.ToInt32(dr["Stock"]),
                CategoriaId = Convert.ToInt32(dr["CategoriaId"]),
                Categoria = dr["Categoria"].ToString() ?? string.Empty
            };

        }
    }
}
