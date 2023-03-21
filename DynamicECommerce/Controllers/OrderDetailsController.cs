using DECommerce.Interfaces;
using DECommers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private IDECommerceRepository _iDECommerceRepository;


        public OrderDetailsController(IDECommerceRepository DECommerceRepository)
        {
            _iDECommerceRepository = DECommerceRepository;
        }
        //get request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> Get()
        {
            IEnumerable<OrderDetails> OrderDetails = new List<OrderDetails>();
            ActionResult result = null;
            try
            {
                OrderDetails = _iDECommerceRepository.GetOrderDetails();
                result = Ok(OrderDetails);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }
        [HttpGet("OrderDetailsID{ID}")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetailsByID(int OrderDetailsID)
        {
            OrderDetails orderDetails = new OrderDetails();
            ActionResult result = null;
            try
            {
                orderDetails = _iDECommerceRepository.GetOrderDetailsByID(OrderDetailsID);
                result = Ok(orderDetails);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }
        [HttpGet("OrderID{ID}")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetailsByOrderID(int OrderID)
        {
            IEnumerable<OrderDetails> orderDetails = new List<OrderDetails>();
            ActionResult result = null;
            try
            {
                orderDetails = _iDECommerceRepository.GetOrderDetailsByOrderID(OrderID);
                result = Ok(orderDetails);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }
    }
}
