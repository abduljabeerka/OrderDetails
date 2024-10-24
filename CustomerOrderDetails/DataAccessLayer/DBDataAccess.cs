using CustomerOrderDetails.DataAccessLayer.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace CustomerOrderDetails.DataAccessLayer
{
    public class DBDataAccess: IDBDataAccess
    {
        private readonly string _connectionString;

        public DBDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public void Save(string storedProcedure, SqlParameter[] parameters)
        {
            using (var connection = CreateConnection())
            {
                using (var command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Update(string storedProcedure, SqlParameter[] parameters)
        {
            Save(storedProcedure, parameters);
        }

        public IEnumerable<T> GetAllData<T>(string storedProcedure, Func<IDataReader, T> map)
        {
            var results = new List<T>();
            using (var connection = CreateConnection())
            {
                using (var command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(map(reader));
                        }
                    }
                }
            }
            return results;
        }

        public T GetDataById<T>(string storedProcedure, SqlParameter[] parameters, Func<IDataReader, T> map)
        {
            using (var connection = CreateConnection())
            {
                using (var command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return map(reader);
                        }
                    }
                }
            }
            return default;
        }

        public void Delete(string storedProcedure, SqlParameter[] parameters)
        {
            Save(storedProcedure, parameters);
        }

    }
}
