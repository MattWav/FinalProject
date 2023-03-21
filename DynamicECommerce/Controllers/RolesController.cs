using DECommerce.Interfaces;
using DECommerce.Models;
using DECommers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IDECommerceRepository _iDECommerceRepository;


        public RolesController(IDECommerceRepository DECommerceRepository)
        {
            _iDECommerceRepository = DECommerceRepository;
        }
        //get request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> Get()
        {
            IEnumerable<Roles> Roles = new List<Roles>();
            ActionResult result = null;
            try
            {
                Roles = _iDECommerceRepository.GetRoles();
                result = Ok(Roles);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }
        [HttpPost]
        public async Task<ActionResult<UserRole>> AddUserRole(UserRole userRole)
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
                    if (_iDECommerceRepository.AddUserRole(userRole))
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
                    $"Error creating new UserRole record {ex.Message}");
            }

            return result;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRole(int roleId)
        {
            Roles role = null;
            ActionResult result = null;

            try
            {
                role = _iDECommerceRepository.GetRoleById(2);
                if (role == null)
                {
                    result = NotFound($"Role with id {roleId} not found.");
                }
                else
                {
                    result = Ok(role);
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error getting Role {ex.Message}");
            }

            return result;
        }
    }
}
