using System.Data.SqlClient;
using WebAPI.Models;

namespace WebAPI.Controllers.Connection
{
    public class DatabaseConnection
    {
        public DatabaseConnection(JsonModel json)
        {
            connection = new SqlConnection("Data Source=SQL5107.site4now.net,1433;Initial Catalog=db_a8bd1d_dimitry123001;User Id=db_a8bd1d_dimitry123001_admin;Password=xL6Q699gx;");
            //connection = new SqlConnection($"Data Source={json.Source},{json.Port};Initial Catalog={json.DatabaseName};User Id={json.UserId};Password={json.Password};Trusted_Connection=True;");
        }

        public SqlConnection connection { get; set; }

        public static DatabaseConnection? _DatabaseConnection;

        private static readonly object _lock = new object();

        public static DatabaseConnection GetInstance(JsonModel json)
        {
            if (_DatabaseConnection == null)
            {
                lock (_lock)
                {
                    if (_DatabaseConnection == null)
                    {
                        _DatabaseConnection = new DatabaseConnection(json);
                    }
                }
            }
            return _DatabaseConnection;
        }

    }
}
