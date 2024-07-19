using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MiIngresoHitss.Controllers
{
    public class TestController : Controller
    {
        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            var connectionString = _configuration.GetConnectionString("MiIngresoHitssDatabase");
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    return Content("Conexión exitosa a la base de datos.");
                }
            }
            catch (SqlException ex)
            {
                return Content($"Error de conexión: {ex.Message}");
            }
        }

        public async Task<IActionResult> GetData()
        {
            var connectionString = _configuration.GetConnectionString("MiIngresoHitssDatabase");
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string query = "SELECT TOP 1 * FROM Productos";
                    using (var command = new SqlCommand(query, connection))
                    {
                        var reader = await command.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            await reader.ReadAsync();
                            var productName = reader["Nombre"].ToString();
                            return Content($"Producto: {productName}");
                        }
                        else
                        {
                            return Content("No se encontraron productos.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                return Content($"Error de conexión: {ex.Message}");
            }
        }
    }
}
