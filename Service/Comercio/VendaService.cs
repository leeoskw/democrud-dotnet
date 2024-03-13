using democrud.DataContext;
using democrud.models.ComercioModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace democrud.Service.Comercio
{
    public class VendaService : IVendaServiceInterface
    {
        private readonly ComercioContext _context;

        public VendaService(ComercioContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateVenda(VendaModel venda)
        {
            var clienteIdExiste = _context.Cliente.Find(venda.cliente_id);
            var produtoIdExiste = _context.Produto.Find(venda.produto_id);

            if (clienteIdExiste == null || produtoIdExiste == null)
            {
                // cliente ou produto não foram cadastrados;
                //return new BadRequestObjectResult("Cliente ou produto inválido");
                throw new Exception("finge que é um statuscode 400. Parâmetros inválidos.");
            }

            _context.Venda.Add(venda);
            await _context.SaveChangesAsync();
            return new CreatedResult("", venda);
        }

        public Task<IActionResult> DeleteVenda(int id)
        {
            throw new NotImplementedException();
        }

        public Task<VendaModel> GetVendaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VendaModel>> GetVendas()
        {
            throw new NotImplementedException();
        }

        public Task<VendaModel> UpdateVenda(VendaModel venda)
        {
            throw new NotImplementedException();
        }
    }
}
