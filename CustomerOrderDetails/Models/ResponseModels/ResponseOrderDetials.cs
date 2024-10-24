using CustomerOrderDetails.Models.Entities;

namespace CustomerOrderDetails.Models.ResponseModels
{
    public class ResponseOrderDetials
    {
        public ResponseOrderDetials() {
            customer=new ResponseCustomer();
            Orders=new ResponseOrders();
        }
        public ResponseCustomer customer { get; set; }
        public ResponseOrders Orders { get; set; }
    }
    public class ResponseCustomer { 
        public string firstName {  get; set; } = string.Empty;
        public string lastName {  get; set; } = string.Empty;
    }
    public class ResponseOrders
    {
        public string orderNumber { get; set; } = string.Empty;
        public string orderDate { get; set; } = string.Empty;
        public string deliveryAddress { get; set; } = string.Empty;
        public List<ResponseOrderItems> responseOrderItems { get; set; }=new List<ResponseOrderItems>(){ };
        public string deliveryExpected { get; set; } =string.Empty;
    }
    public class ResponseOrderItems
    {
        public string orderNumber { get; set; } = string.Empty;
        public string orderDate { get; set; } = string.Empty;
        public string deliveryAddress { get; set; } = string.Empty;
        public string deliveryExpected { get; set; } = string.Empty;
    }
}
