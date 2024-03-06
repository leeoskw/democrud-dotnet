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
            TbCliente cliente = await _context.TbClientes.FindAsync(id);
            return cliente;
        }

        public async Task<TbCliente> CreateCliente(TbCliente cliente)
        {
            _context.TbClientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<TbCliente> DeleteCliente(int idCliente)
        {
            TbCliente cliente = _context.TbClientes.Find(idCliente);
            
            if (cliente == null)
            {
                return null;
            }

            _context.TbClientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return cliente
        }

       

        public async Task<IEnumerable<TbCliente>> GetClientes()
        {
            List<TbCliente> clientes = _context.TbClientes.ToList();
            await _context.SaveChangesAsync();
            return clientes;
        }

        public Task<TbCliente> UpdateCliente(TbCliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
