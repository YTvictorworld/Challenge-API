using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Challenge.Full.Stack.WebDev.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Full.Stack.WebDev.Data;

namespace Challenge.Full.Stack.WebDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _dbContext;


        public ProductController(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_dbContext.Products);
        }

        [HttpGet("{productId:int}")]
        public async Task<ActionResult<Product>> GetById(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{productId:int}")]
        public async Task<ActionResult> Delete(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
