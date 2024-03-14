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

        public async Task<List<FuncionarioModel>> GetFuncionarios()
        {
            return await _context.Funcionarios.ToListAsync();
        }

        public async Task<FuncionarioModel> GetFuncionarioById(int idFuncionario)
        {
            FuncionarioModel? funcionario = await _context.Funcionarios.FindAsync(idFuncionario);
            return funcionario;
        }

        public async Task<FuncionarioModel> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            _context.Funcionarios.Add(novoFuncionario);
            await _context.SaveChangesAsync();
            return novoFuncionario;
        }

        public Task<FuncionarioModel> DeleteFuncionario(int idFuncionario)
        {
            throw new NotImplementedException();
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
