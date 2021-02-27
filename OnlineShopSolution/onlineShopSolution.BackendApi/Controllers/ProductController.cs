using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using onlineShopSolution.Application.Catalog.Products;
using onlineShopSolution.ViewModel.Catalog.Products;

namespace onlineShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] //co token moi cho goi api
    public class ProductController : ControllerBase
    {
        // phải khai báo trong Startup.cs để sử dụng
        private readonly IProductService _productService;
      
        public ProductController(IProductService productService)
        {
            _productService = productService;
           
        }
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var products = await _productService.GetAll(languageId);
            return Ok(products);
        }
        //[HttpGet("PublicPaging/{languageId}")]
        [HttpGet("PublicPaging")]
        public async Task<IActionResult> GetAllByCategoryId([FromQuery]GetPublicProductPagingRequest request)
        {
            var products = await _productService.GetAllByCategoryId(request);
            return Ok(products);
        }   
     
        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(int id,string languageId)
        {
            var product = await _productService.GetById(id,languageId);
            //BadRequest 400, Not Found 404
            if (product == null) return BadRequest("cannot find product");
            return Ok(product);

        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromForm]ProductCreateRequest request)
        {
            var productId = await _productService.Create(request);
            if (productId == 0) { return BadRequest(); }
            var product = await _productService.GetById(productId,request.LanguageId);
            return CreatedAtAction(nameof(GetById), new {id= productId },product); //Created 201, Ok 200
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromForm]ProductUpdateRequest request)
        {
            var rs = await _productService.Update(request);
            if (rs == 0) { return BadRequest(); }
            return Ok();
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _productService.Delete(id);
            if (rs == 0) { return BadRequest(); }
            return Ok();
        }

        [HttpPut("price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int id,decimal newPrice)
        {
            var rs = await _productService.UpdatePrice(id,newPrice);
            if (rs) return Ok();

            return BadRequest();
        }


        #region test
        //[HttpGet] 
        //[HttpGet("int/{id:int}")] // GET /api/product/int/3
        [HttpGet("get1/{id}")]   // GET /api/Product/get1/3
        public async Task<IActionResult> Test(int id)
        {
           
            return Ok(id);
        }
        #endregion

    }
}