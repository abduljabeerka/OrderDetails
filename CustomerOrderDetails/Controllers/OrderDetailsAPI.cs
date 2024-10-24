using CustomerOrderDetails.DataAccessLayer.Interfaces;
using CustomerOrderDetails.Models.RequestModels;
using CustomerOrderDetails.Models.ResponseModels;
using CustomerOrderDetails.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsAPI : ControllerBase
    {
        private OrderService orderService;
        public OrderDetailsAPI(IDBDataAccess databaseContext) {
            orderService=new OrderService(databaseContext);
        }
        [HttpPost(Name = "GetCustomerOrderDetails")]
        public IActionResult GetCustomerOrderDetails([FromBody] string value, OrderDetailsRequest orderDetailsRequest)
        {
            var result = orderService.GetCustomerOrderDetails(orderDetailsRequest);
            return Ok(result);
        }
    }
}
