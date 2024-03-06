using democrud.Models;

namespace democrud.Service.ClienteService
{
    public interface IClienteInterface
    {
        public Task<IEnumerable<TbCliente>> GetClientes();
        public Task<TbCliente> GetCliente(int id);
        public Task<TbCliente> CreateCliente(TbCliente cliente);
        public Task<TbCliente> UpdateCliente(TbCliente cliente);
        public Task<TbCliente> DeleteCliente(int idCliente);
    }
}
