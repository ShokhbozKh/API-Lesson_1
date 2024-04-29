using lesson1_1.Models;
using lesson1_1.Stores;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson1_1.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    public ProductDataStore _store;
    public ProductController()
    {
        _store = new ProductDataStore();
    }
    // GET: api/Product
    [HttpGet]
    public  ActionResult<IEnumerable<Product>> GetAllProducts()
    {
        var result = _store.GetAllProducts();
        return Ok(result);
    }

    // GET api/Product/5
    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var result = _store.GetById(id);

        if(result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{id}/Product")]

    public ActionResult<List<Product>> GetProductId(int id)
    {
        return _store.GetAllProducts(id);
    }

    // POST api/Product/Post
    [HttpPost]
    public ActionResult<Product> Post([FromBody] Product product)
    {
        if(product == null)
        {
            return NotFound();
        }
        _store.Create(product);
        return NoContent();
    }

    // PUT api/Product/5
    [HttpPut("{id}")]
    public ActionResult<Product> Put(int id, [FromBody] Product product)
    {
        if(id != product.Id)
        {
            return BadRequest();
        }


        var findIndex = _store.GetById(id);


        if (findIndex!.Id == 0)
        {
            return NoContent();
        }
        _store.Update(product);
        return Ok($"okey {product}");
    }

    // DELETE api/Product/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var findIndex = _store.GetById(id);

        if(findIndex!.Id == 0)
        {
            return NotFound($"content yuq{findIndex}");
        }
        _store.Delete(findIndex);

        return NoContent();
    }
}

