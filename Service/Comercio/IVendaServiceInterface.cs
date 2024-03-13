using democrud.models.ComercioModels;
using Microsoft.AspNetCore.Mvc;

namespace democrud.Service.Comercio
{
    public interface IVendaServiceInterface
    {
        public Task<List<VendaModel>> GetVendas();
        public Task<VendaModel> GetVendaById(int id);
        public Task<VendaModel> UpdateVenda(VendaModel venda);
        public Task<IActionResult> DeleteVenda(int id);

        public Task<IActionResult> CreateVenda(VendaModel venda);
    }
}