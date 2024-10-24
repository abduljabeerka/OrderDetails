using CustomerOrderDetails.DataAccessLayer.Interfaces;
using CustomerOrderDetails.Models.Entities;
using CustomerOrderDetails.Models.RequestModels;
using CustomerOrderDetails.Models.ResponseModels;
using System.Data.SqlClient;

namespace CustomerOrderDetails.Services
{
    public class OrderService
    {
        private readonly IDBDataAccess _orderDataAccess;

        public OrderService(IDBDataAccess databaseContext)
        {
            _orderDataAccess = databaseContext;
        }
        public void SaveData(string name)
        {
            var parameters = new[]
            {
                new SqlParameter("@Name", name)
            };
            _orderDataAccess.Save("sp_SaveData", parameters);
        }

        public void UpdateData(int id, string name)
        {
            var parameters = new[]
            {
            new SqlParameter("@Id", id),
            new SqlParameter("@Name", name)
        };
            _orderDataAccess.Update("sp_UpdateData", parameters);
        }

        public IEnumerable<ResponseOrderDetials> GetAllData()
        {
            return _orderDataAccess.GetAllData("sp_GetAllData", reader => new ResponseOrderDetials
            {
                //Id = reader.GetInt32(0),
                //Name = reader.GetString(1)
                customer = new ResponseCustomer(),
                Orders = new ResponseOrders()
            });
        }
        public IEnumerable<ResponseOrderDetials> GetCustomerOrderDetails(OrderDetailsRequest orderDetailsRequest)
        {
            return _orderDataAccess.GetAllData("USP_CUSTOMER_GET_ORDER_DETAILS", reader => new ResponseOrderDetials
            {
               
                //Id = reader.GetInt32(0),
                customer = new ResponseCustomer(),
                Orders = new ResponseOrders(){
                    orderNumber = reader.GetInt32(0).ToString(),
                    orderDate = reader.GetDateTime(1).ToString(),
                    deliveryAddress = reader.GetDateTime(3).ToString(),

                }
            });
        }

        public ResponseOrderDetials GetDataById(int id)
        {
            var parameters = new[]
            {
            new SqlParameter("@Id", id)
        };
            return _orderDataAccess.GetDataById("sp_GetDataById", parameters, reader => new ResponseOrderDetials
            {
                //Id = reader.GetInt32(0),
                //Name = reader.GetString(1)
                customer = new ResponseCustomer(),
                Orders = new ResponseOrders()
            });
        }

        public void DeleteData(int id)
        {
            var parameters = new[]
            {
            new SqlParameter("@Id", id)
        };
            _orderDataAccess.Delete("sp_DeleteData", parameters);
        }
    }
}
