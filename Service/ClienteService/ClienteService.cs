using democrud.DataContext;
using democrud.Models;

namespace democrud.Service.ClienteService
{
    public class ClienteService : IClienteInterface
    {
        private readonly DatabaseFirstCrudDemoContext _context;

        public ClienteService(DatabaseFirstCrudDemoContext context)
        {
            _context = context;
        }

        public async Task<TbCliente> GetCliente(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TbCliente> CreateCliente(TbCliente cliente)
        {
            _context.TbClientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public Task<TbCliente> DeleteCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

       

        public Task<IEnumerable<TbCliente>> GetClientes()
        {
            throw new NotImplementedException();
        }

        public Task<TbCliente> UpdateCliente(TbCliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
