using democrud.models;

namespace democrud.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponseModel<List<FuncionarioModel>>> GetFuncionarios();
        Task<ServiceResponseModel<FuncionarioModel>> GetFuncionarioById(int idFuncionario);
        Task<ServiceResponseModel<FuncionarioModel>> CreateFuncionario(FuncionarioModel novoFuncionario);
        Task<ServiceResponseModel<FuncionarioModel>> UpdateFuncionario(FuncionarioModel editadoFuncionario);
        Task<ServiceResponseModel<FuncionarioModel>> DeleteFuncionario(int idFuncionario);
        Task<ServiceResponseModel<FuncionarioModel>> InativaFuncionario(int idFuncionario);
    }
}
