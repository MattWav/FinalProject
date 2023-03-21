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
    public class OrdersController : ControllerBase
    {
        private IDECommerceRepository _iDECommerceRepository;


        public OrdersController(IDECommerceRepository DECommerceRepository)
        {
            _iDECommerceRepository = DECommerceRepository;
        }
        //get request
        [Authorize(Roles = "2")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> Get()
        {
            IEnumerable<Orders> Orders = new List<Orders>();
            ActionResult result = null;
            try
            {
                Orders = _iDECommerceRepository.GetOrders();
                result = Ok(Orders);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }
        
        [HttpPost]
        public async Task<ActionResult<Orders>> CreateOrders(Orders orders)
        {
            ActionResult result = null;
            try
            {
                if (orders == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_iDECommerceRepository.CreateOrders(orders))
                    {
                        result = Ok();
                    }
                    else
                    {
                        result = StatusCode(StatusCodes.Status500InternalServerError);
                    }
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error getting users {ex.Message}");
            }

            return result;


        }

        [HttpDelete("{OrderID}")]
        public async Task<ActionResult<Orders>> DeleteOrders(int OrderID)
        {
            ActionResult result = null;
            try
            {
                if (OrderID == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_iDECommerceRepository.DeleteOrders(OrderID))
                    {
                        result = Ok();
                    }
                    else
                    {
                        result = StatusCode(StatusCodes.Status500InternalServerError);
                    }
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error getting users {ex.Message}");
            }

            return result;
        }
        [HttpGet("OrderID{ID}")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrdersByID(int OrderID)
        {
            Orders orders = new Orders();
            ActionResult result = null;
            try
            {
                orders = _iDECommerceRepository.GetOrdersbyId(OrderID);
                result = Ok(orders);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }
        [HttpGet("{UserID}")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrdersbyUserID()
        {
            IEnumerable<Orders> Orders = new List<Orders>();
            ActionResult result = null;
            try
            {
                Orders = _iDECommerceRepository.GetOrdersbyUserId();
                result = Ok(Orders);

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
