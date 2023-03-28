using DECommerce.Interfaces;
using DECommers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private IDECommerceRepository _iDECommerceRepository;   


        public ProductCategoriesController(IDECommerceRepository DECommerceRepository)
        {
            _iDECommerceRepository = DECommerceRepository;
        }
        //get request
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategories>>> Get()
        {
            IEnumerable<ProductCategories> Products = new List<ProductCategories>();
            ActionResult result = null;
            try
            {
                Products = _iDECommerceRepository.GetProductCategories();
                result = Ok(Products);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting users {ex.Message}");
            }

            return result;
        }

        //get request
        [HttpGet("{ProductCategoriesID:int}")]
        public async Task<ActionResult<IEnumerable<ProductCategories>>> GetProductsCategoriesbyId(int ProductCategoriesID)
        {
            ProductCategories ProductCategories = new ProductCategories();
            ActionResult result = null;
            try
            {
                ProductCategories = _iDECommerceRepository.GetProductsCategoriesbyId(ProductCategoriesID);
                result = Ok(ProductCategories);

            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error while getting BankAccounts {ex.Message}");
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategories>> CreateProductCategories(ProductCategories productCategories)
        {
            ActionResult result = null;
            try
            {
                if (productCategories == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_iDECommerceRepository.CreateProductCategories(productCategories))
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
        [Authorize(Roles = "2")]
        [HttpDelete("{ProductCategoriesID:int}")]
        public async Task<ActionResult<ProductCategories>> DeleteProductCategories(int ProductCategoriesID)
        {
            ActionResult result = null;
            try
            {
                if (ProductCategoriesID == null)
                {
                    result = BadRequest();
                }
                else
                {
                    if (_iDECommerceRepository.DeleteProductCategories(ProductCategoriesID))
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

