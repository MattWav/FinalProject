using DECommerce.Interfaces;
using DECommers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IDECommerceRepository _iDECommerceRepository;


        public ProductsController(IDECommerceRepository DECommerceRepository)
        {
            _iDECommerceRepository = DECommerceRepository;
        }
        //get request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> Get()
        {
            IEnumerable<Products> Products = new List<Products>();
            ActionResult result = null;
            try
            {
                Products = _iDECommerceRepository.GetProducts();
                result = Ok(Products);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }

        [HttpGet("ProductID{ID}")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductId(int ProductID)
        {
            Products products = new Products();
            ActionResult result = null;
            try
            {
                products = _iDECommerceRepository.GetProductsbyId(ProductID);
                result = Ok(products);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }
        [HttpGet("ProductCategoriesID{ID}")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProductsbyCategories(int ProductCategoriesID)
        {
            IEnumerable <Products> products = new List <Products>();
            ActionResult result = null;
            try
            {
                products = _iDECommerceRepository.GetProductsbyCategoriesId(ProductCategoriesID);
                result = Ok(products);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }
            return result;
        }
        [Authorize(Roles = "2")]
        [HttpDelete("{ProductID:int}")]
        public async Task<ActionResult<Products>> DeleteProducts(int ProductID)
        {
            ActionResult result = null;
            try
            {
                if (ProductID == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_iDECommerceRepository.DeleteProducts(ProductID))
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
        //Post request
        [Authorize(Roles = "2")]
        [HttpPost]
        public async Task<ActionResult<Products>> CreateProduct(Products product)
        {
            ActionResult result = null;
            try
            {
                if (product == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_iDECommerceRepository.CreateProduct(product))
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
    }
}





