using democrud.models;
using democrud.Service.FuncionarioService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace democrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface) 
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public  async Task<ActionResult<ServiceResponseModel<List<FuncionarioModel>>>> getallClientes()
        {
            ServiceResponseModel<List<FuncionarioModel>> funcionarios = await _funcionarioInterface.GetFuncionarios();
            return Ok(funcionarios);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponseModel<FuncionarioModel>>> CreateCliente([FromBody] FuncionarioModel dados)
        {
            ServiceResponseModel<FuncionarioModel> response = await _funcionarioInterface.CreateFuncionario(dados);
            return Ok(response);
        }
 

    }

    
}
