﻿using democrud.DataContext;
using democrud.Models;
using democrud.Service.ClienteService;
using democrud.Service.FuncionarioService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace democrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataBaseFirstDemoController : ControllerBase
    {
        public readonly IClienteInterface _clienteInterface;

        public DataBaseFirstDemoController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }

        [HttpGet("clientes")]
        public async Task<ActionResult<IEnumerable<TbCliente>>> getClientes()
        {
            var response = await _clienteInterface.GetClientes();
            return Ok(response);
        }

        [HttpPost("clientes")]
        public async Task<ActionResult<TbCliente>> CreateCliente([FromBody] TbCliente entity)
        {
            var response = await _clienteInterface.CreateCliente(entity);

            return Ok(response);
        }
    }
}
