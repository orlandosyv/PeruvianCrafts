using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeruvianCrafts.Website.Models;
using PeruvianCrafts.Website.Services;

namespace PeruvianCrafts.Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }
        [Route("Rate")]
        [HttpGet]

        public ActionResult Get(
            [FromQuery] string ProductId,
            [FromQuery] int rating)
        {
            ProductService.AddRating(ProductId, rating);
            return Ok();
        }
    }
    
}
