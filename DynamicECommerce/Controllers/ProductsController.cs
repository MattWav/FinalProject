using DECommerce.Interfaces;
using DECommers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Text;

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
        [HttpGet, DisableRequestSizeLimit]
        public async Task<ActionResult<IEnumerable<Products>>> Get()
        {
            IEnumerable<Products> products = new List<Products>();
            ActionResult result = null;
            try
            {
                products = _iDECommerceRepository.GetProducts();
                foreach (var product in products)
                {
                    if (!string.IsNullOrEmpty(product.imageValue))
                    {
                        byte[] imageBytes = Convert.FromBase64String(product.imageValue);
                        string imageSrc = Convert.ToBase64String(imageBytes);
                        product.imageValue = imageSrc;
                    }
                }

                result = Ok(products);

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

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<Products>> CreateProduct([FromForm] Products product , IFormCollection formData)
        {
            ActionResult result = null;
            try
            {
                //var product = new Products();

                if (product == null)    
                {
                    result = BadRequest();
                }
                else
                {
                    

                    
                    var image = formData.Files[0];

                

                    if (image.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            image.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            var base64String = Convert.ToBase64String(fileBytes);
                            product.imageValue = base64String;
                        }

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
            }
            catch (Exception ex)
            {
                result = StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error getting products {ex.Message} {ex.InnerException?.Message}");
            }

            return result;


        }
    }
}





