using democrud.DataContext;
using democrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace democrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataBaseFirstDemoController : ControllerBase
    {
        private readonly DatabaseFirstCrudDemoContext _context;

        public DataBaseFirstDemoController(DatabaseFirstCrudDemoContext context)
        {
            _context = context;
        }

        [HttpGet("clientes")]
        public IEnumerable<TbCliente> getClientes()
        {
            return _context.TbClientes.ToList();
        }

        [HttpPost("clientes")]
        public ActionResult<TbCliente> CreateCliente([FromBody] TbCliente entity)
        {
            _context.TbClientes.Add(entity);
            _context.SaveChanges();
            return Ok(entity);
        }
    }
}
