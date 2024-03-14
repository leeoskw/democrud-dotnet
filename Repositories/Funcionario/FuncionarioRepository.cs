using democrud.DataContext;
using democrud.models;
using Microsoft.EntityFrameworkCore;

namespace democrud.Repositories.Funcionario
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private readonly ApplicationDbContext _context;

        public FuncionarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<FuncionarioModel> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionarioModel> DeleteFuncionario(int idFuncionario)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionarioModel> GetFuncionarioById(int idFuncionario)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FuncionarioModel>> GetFuncionarios()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public Task<FuncionarioModel> InativaFuncionario(int idFuncionario)
        {
            throw new NotImplementedException();
        }

        public Task<FuncionarioModel> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            throw new NotImplementedException();
        }
    }
}
