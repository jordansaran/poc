using AlphaWebAPI.Commands.Product;
using Application.Commands.Product;
using Application.Queries.Product;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var productList = await _mediator.Send(new GetProductListQuery());
            return Ok(productList);
        }
        
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var product = await _mediator.Send(new GetProductByIdQuery() {Id = productId});
            return Ok(product);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var productCreated = await _mediator.Send(new CreateProductCommand(
                product.Reference, product.Name, product.Unit, product.Price, product.CostPrice, product.PurchasePrice
            ));
            return Ok(productCreated);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product? product)
        {
            if (product == null) return BadRequest();
            var isProductCreated = await _mediator.Send(new UpdateProductCommand(
                product.Id, product.Reference, product.Name, product.Unit, product.Price, product.CostPrice,
                product.PurchasePrice
            ));
            if (isProductCreated > 0) return Ok();
            return BadRequest();
        }
        
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var isUserDeleted = await _mediator.Send(new DeleteProductCommand() { Id = productId });
            if (isUserDeleted > 0) return Ok();
            return BadRequest();
        }
    }
}
