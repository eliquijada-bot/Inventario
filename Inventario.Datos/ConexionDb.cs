using System.Configuration;

namespace Inventario.Datos
{
    public static class ConexionDb
    {
        public static string Cadena =>
            ConfigurationManager.ConnectionStrings["InventarioDB"].ConnectionString
            ?? throw new InvalidOperationException("No se encontró la cadena de conexión InventarioDB");
    }
}
