using System.Data.SqlClient;
using System.Data;

namespace CustomerOrderDetails.DataAccessLayer.Interfaces
{
    public interface IDBDataAccess
    {
        void Save(string storedProcedure, SqlParameter[] parameters);
        void Update(string storedProcedure, SqlParameter[] parameters);
        IEnumerable<T> GetAllData<T>(string storedProcedure, Func<IDataReader, T> map);
        T GetDataById<T>(string storedProcedure, SqlParameter[] parameters, Func<IDataReader, T> map);
        void Delete(string storedProcedure, SqlParameter[] parameters);
    }
}
