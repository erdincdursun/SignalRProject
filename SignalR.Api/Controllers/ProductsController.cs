using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.Business.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetAll());
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(p => p.Category).Select(c => new ResultProductWithCategory
            {
                Description = c.Description,
                ImageUrl = c.ImageUrl,
                Price = c.Price,
                ProductId = c.ProductId,
                ProductName = c.ProductName,
                ProductsStatus = c.ProductsStatus,
                CategoryName = c.Category.CategoryName
            });
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreatedProduct(CreateProductDto createProductDto)
        {
            #region Mapping
            //var value = _mapper.Map<Product>(createProductDto);
            //_productService.TAdd(value);
            #endregion

            _productService.TAdd(new Product()
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Price = createProductDto.Price,
                ProductName = createProductDto.ProductName,
                ProductsStatus = createProductDto.ProductsStatus,
                CategoryId = createProductDto.CategoryId
            });
            return Ok("Product has been added successfully.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Product has been deleted successfully.");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _mapper.Map<GetProductDto>(_productService.TGetById(id));
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            #region Mapping
            //var value = _mapper.Map<Product>(updateProductDto);
            //_productService.TUpdate(value);
            #endregion

            _productService.TUpdate(new Product()
            {
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                Price = updateProductDto.Price,
                ProductId = updateProductDto.ProductId,
                ProductName = updateProductDto.ProductName,
                ProductsStatus = updateProductDto.ProductsStatus,
                CategoryId = updateProductDto.CategoryId
            });
            return Ok("Product has been updated successfully.");
        }
    }
}
