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
        private readonly IVendaServiceInterface _vendaServiceInterface;

        public ComercioController(IProdutoInterface produtoInterface, IVendaServiceInterface vendaServiceInterface)
        {
            _produtoInterface = produtoInterface;
            _vendaServiceInterface = vendaServiceInterface;

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

        [HttpPost("venda")]
        public async Task<IActionResult> createVenda([FromBody] VendaModel venda)
        {
            await _vendaServiceInterface.CreateVenda(venda);
            return Ok(venda);
        }

    }
}
