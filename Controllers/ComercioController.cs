using democrud.DataContext;
using democrud.models.ComercioModels;
using democrud.Service.Comercio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace democrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : ControllerBase
    {
        private readonly IProdutoInterface _produtoInterface;

        public ComercioController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }


        [HttpGet("produtos")]
        public async Task<ActionResult<Produto>> getProdutos()
        {
            return Ok(await _produtoInterface.GetProdutos());
        }

        [HttpPost("produto")]
        public async Task<ActionResult<Produto>> createProduto([FromBody] Produto produto)
        {
            return await _produtoInterface.CreateProduto(produto);
        }

    }
}
