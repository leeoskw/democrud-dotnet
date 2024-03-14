using democrud.models;
using democrud.Repositories.Funcionario;
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

        [HttpGet("funcionarios")]
        public async Task<ActionResult<ServiceResponseModel<List<FuncionarioModel>>>> getAllFuncionarios()
        {
            ServiceResponseModel<List<FuncionarioModel>> funcionarios = await _funcionarioInterface.GetFuncionarios();
            return Ok(funcionarios);
        }

        //[HttpGet("{idFuncionario}")]
        //public async Task<ActionResult<ServiceResponseModel<FuncionarioModel>>> getFuncionarioById([FromRoute] int idFuncionario)
        //{
        //    ServiceResponseModel<FuncionarioModel> response = await _funcionarioInterface.GetFuncionarioById(idFuncionario);
        //    return Ok(response);
        //}

        //[HttpPost]
        //public async Task<ActionResult<ServiceResponseModel<FuncionarioModel>>> CreateCliente([FromBody] FuncionarioModel dados)
        //{
        //    ServiceResponseModel<FuncionarioModel> response = await _funcionarioInterface.CreateFuncionario(dados);
        //    return Ok(response);
        //}

        //[HttpPut]
        //public async Task<ActionResult<ServiceResponseModel<FuncionarioModel>>> UpdateCliente([FromBody] FuncionarioModel dados)
        //{
        //    ServiceResponseModel<FuncionarioModel> response = await _funcionarioInterface.UpdateFuncionario(dados);
        //    return Ok(response);
        //}

        //[HttpPut("{idFuncionario}")]
        //public async Task<ActionResult<ServiceResponseModel<FuncionarioModel>>> InativaFuncionario(int idFuncionario)
        //{
        //    ServiceResponseModel<FuncionarioModel> response = await _funcionarioInterface.InativaFuncionario(idFuncionario);
        //    return Ok(response);
        //}

        //[HttpDelete("{idFuncionario}")]
        //public async Task<ActionResult<ServiceResponseModel<FuncionarioModel>>> DeleteFuncionario(int idFuncionario)
        //{
        //    ServiceResponseModel<FuncionarioModel> response = await _funcionarioInterface.DeleteFuncionario(idFuncionario);
        //    return Ok(response);
        //}
    }

    
}
