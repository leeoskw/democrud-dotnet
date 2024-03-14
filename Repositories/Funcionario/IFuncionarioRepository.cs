using democrud.models;

namespace democrud.Repositories.Funcionario
{
    public interface IFuncionarioRepository
    {
        Task<List<FuncionarioModel>> GetFuncionarios();
        Task<FuncionarioModel> GetFuncionarioById(int idFuncionario);
        Task<FuncionarioModel> CreateFuncionario(FuncionarioModel novoFuncionario);
        Task<FuncionarioModel> UpdateFuncionario(FuncionarioModel editadoFuncionario);
        Task<FuncionarioModel> InativaFuncionario(int idFuncionario);
        Task<FuncionarioModel> DeleteFuncionario(int idFuncionario);
    }
}
