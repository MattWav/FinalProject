using DECommerce.Interfaces;
using DECommerce.Models;
using DECommers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private IDECommerceRepository _iDECommerceRepository;


        public UserRolesController(IDECommerceRepository DECommerceRepository)
        {
            _iDECommerceRepository = DECommerceRepository;
        }
        //get request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> Get()
        {
            IEnumerable<UserRole> UserRole = new List<UserRole>();
            ActionResult result = null;
            try
            {
                UserRole = _iDECommerceRepository.GetUserRoles();
                result = Ok(UserRole);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }


        //post request
        [HttpPost]
        public async Task<ActionResult<UserRole>> CreateUserRoles(UserRole userRole)
        {
            ActionResult result = null;
            try
            {
                if (userRole == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_iDECommerceRepository.CreateUserRole(userRole))
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
        //METODO PER IL LOGIN
        //GET api/OrderDetails/orderId
        [HttpGet("{UserByUserRole}")]
        public async Task<ActionResult<UserRole>> GetUserRoleByUserId(int UserID)
        {
            UserRole userRole = null;
            ActionResult result = null;

            try
            {
                userRole = _iDECommerceRepository.GetUserRoleByUserId(UserID);
                if (userRole == null)
                {
                    result = NotFound($"User Role with UserID {UserID} not found.");
                }
                else
                {
                    result = Ok(userRole);
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error getting User Role {ex.Message}");
            }

            return result;
        }


    }

}