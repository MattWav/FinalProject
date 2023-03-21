using DECommerce.Interfaces;
using DECommerce.Models;
using DECommers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DynamicECommerce.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IDECommerceRepository _iDECommerceRepository;


        public UsersController(IDECommerceRepository iDECommerceRepository)
        {
            _iDECommerceRepository = iDECommerceRepository;
        }

      //  [Authorize(Roles = "2,1")]

        //implements crud operatiom
        //get request
        [Authorize(Roles = "2")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            IEnumerable<Users> Users = new List<Users>();
            ActionResult result = null;
            try
            {
                Users = _iDECommerceRepository.GetUsers();
                result = Ok(Users);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }
       
        [HttpPost]
        public async Task<ActionResult<Users>> CreateUserRole([FromBody] Users user)
        {
            ActionResult result = null;
            try
            {
                if (user == null)
                {
                    result = BadRequest();
                }
                else
                {
                    Roles role = _iDECommerceRepository.GetRoleById(2);
                    if (_iDECommerceRepository.CreateUsers(user))
                    {
                        UserRole userRole = new UserRole { UserID = user.UserID, RoleID = role.RoleID };
                        if (_iDECommerceRepository.AddUserRole(userRole))
                        {
                            result = Ok();
                        }
                        else
                        {
                            result = StatusCode(StatusCodes.Status500InternalServerError);
                        }
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
                    $"Error creating new user record {ex.Message}");
            }

            return result;
        }
        //get request byID
        [Authorize]
        [HttpGet("{ID}")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUserId(int UserID)
        {
            Users user = new Users();
            ActionResult result = null;
            try
            {
                user = _iDECommerceRepository.GetUserById(UserID);
                result = Ok(user);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }
        [Authorize(Roles = "1")]
        [HttpDelete("{ID:int}")]
        public async Task<ActionResult<Users>> DeleteUsers(int UserID)
        {
            ActionResult result = null;
            try
            {
                if (UserID == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_iDECommerceRepository.DeleteUsers(UserID))
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

        [HttpGet("{username}")]
        public async Task<ActionResult<Users>> GetUserByUsername(string username)
        {
            Users user = null;
            ActionResult result = null;

            try
            {
                user = _iDECommerceRepository.GetUserByUsername(username);
                if (user == null)
                {
                    result = NotFound($"User with id {username} not found.");
                }
                else
                {
                    result = Ok(user);
                }
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error getting user {ex.Message}");
            }

            return result;
        }

    }

}

