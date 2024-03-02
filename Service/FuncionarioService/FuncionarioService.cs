using democrud.DataContext;
using democrud.models;

namespace democrud.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public Task<ServiceResponseModel<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponseModel<List<FuncionarioModel>> serviceResponse = new ServiceResponseModel<List<FuncionarioModel>>();

            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Não há dados cadastrados";
                }
            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return Task.FromResult(serviceResponse);
        }

        public async Task<ServiceResponseModel<FuncionarioModel>> GetFuncionarioById(int idFuncionario)
        {
            ServiceResponseModel<FuncionarioModel> serviceResponse = new ServiceResponseModel<FuncionarioModel>();

            try
            {
                serviceResponse.Dados = _context.Funcionarios.Find(idFuncionario);
            }
            catch (Exception ex) 
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponseModel<FuncionarioModel>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponseModel<FuncionarioModel> serviceResponse = new ServiceResponseModel<FuncionarioModel>();
            try
            {
                if (novoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Dados inválidos";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                // salva no bd
                _context.Funcionarios.Add(novoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = novoFuncionario;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponseModel<FuncionarioModel>> DeleteFuncionario(int idFuncionario)
        {
            throw new NotImplementedException();
        }

       

        

        public Task<ServiceResponseModel<FuncionarioModel>> InativaFuncionario(int idFuncionario)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponseModel<FuncionarioModel>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            throw new NotImplementedException();
        }
    }
}
