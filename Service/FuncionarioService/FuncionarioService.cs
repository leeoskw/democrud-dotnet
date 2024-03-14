using democrud.DataContext;
using democrud.models;
using democrud.Repositories.Funcionario;
using Microsoft.EntityFrameworkCore;

namespace democrud.Service.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<ServiceResponseModel<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponseModel<List<FuncionarioModel>> serviceResponse = new();

            try
            {
                List<FuncionarioModel> funcionarios = await _funcionarioRepository.GetFuncionarios();
                if (funcionarios == null)
                {
                    serviceResponse.Mensagem = "Não há dados cadastrados";
                }
                serviceResponse.Dados = funcionarios;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponseModel<FuncionarioModel>> GetFuncionarioById(int idFuncionario)
        {
            ServiceResponseModel<FuncionarioModel> serviceResponse = new();
            
            try
            {
                var response = await _funcionarioRepository.GetFuncionarioById(idFuncionario);
                if (response == null)
                {
                    serviceResponse.Mensagem = "Usuário não encontrado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                serviceResponse.Dados = response;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponseModel<FuncionarioModel>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            throw new NotImplementedException();
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

        //public async Task<ServiceResponseModel<FuncionarioModel>> GetFuncionarioById(int idFuncionario)
        //{
        //    ServiceResponseModel<FuncionarioModel> serviceResponse = new ServiceResponseModel<FuncionarioModel>();

        //    try
        //    {
        //        serviceResponse.Dados = _context.Funcionarios.Find(idFuncionario);
        //        if (serviceResponse.Dados == null)
        //        {
        //            serviceResponse.Mensagem = "Funcionário não encontrado";
        //            serviceResponse.Sucesso = false;
        //            return serviceResponse;
        //        }
        //    }
        //    catch (Exception ex) 
        //    {
        //        serviceResponse.Mensagem = ex.Message;
        //        serviceResponse.Sucesso = false;
        //    }
        //    return serviceResponse;

        //}

        //public async Task<ServiceResponseModel<FuncionarioModel>> CreateFuncionario(FuncionarioModel novoFuncionario)
        //{
        //    ServiceResponseModel<FuncionarioModel> serviceResponse = new ServiceResponseModel<FuncionarioModel>();
        //    try
        //    {
        //        if (novoFuncionario == null)
        //        {
        //            serviceResponse.Dados = null;
        //            serviceResponse.Mensagem = "Dados inválidos";
        //            serviceResponse.Sucesso = false;
        //            return serviceResponse;
        //        }

        //        serviceResponse.Mensagem = "Registro criado com sucesso!";

        //        // salva no bd
        //        _context.Funcionarios.Add(novoFuncionario);
        //        await _context.SaveChangesAsync();

        //        serviceResponse.Dados = novoFuncionario;
        //    }
        //    catch (Exception ex)
        //    {
        //        serviceResponse.Mensagem = ex.Message;
        //        serviceResponse.Sucesso = false;
        //    }
        //    return serviceResponse;
        //}

        //public async Task<ServiceResponseModel<FuncionarioModel>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        //{
        //    ServiceResponseModel<FuncionarioModel> serviceResponse = new ServiceResponseModel<FuncionarioModel>();
        //    try
        //    {
        //        // Nota para o Léo do Futuro:
        //        // AsNoTracking() para resolver o erro de "cannot be tracked because another instance with the same key is already being tracked". 
        //        FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);

        //        if (funcionario == null)
        //        {
        //            serviceResponse.Dados = null;
        //            serviceResponse.Mensagem = "Funcionário não encontrado na base de dados";
        //            serviceResponse.Sucesso = false;
        //            return serviceResponse;
        //        }

        //        serviceResponse.Dados = editadoFuncionario;
        //        serviceResponse.Dados.DataDeAlteracao = DateTime.Now.ToLocalTime();
        //        serviceResponse.Mensagem = "Dados alterados com sucesso!";

        //        // sensibiliza o bd
        //        _context.Funcionarios.Update(editadoFuncionario);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception e)
        //    {
        //        serviceResponse.Sucesso = false;
        //        serviceResponse.Mensagem = e.Message;
        //    }
        //    return serviceResponse;
        //}



        //public async Task<ServiceResponseModel<FuncionarioModel>> InativaFuncionario(int idFuncionario)
        //{
        //    ServiceResponseModel<FuncionarioModel> serviceResponse = new ServiceResponseModel<FuncionarioModel>();
        //    try
        //    {
        //        FuncionarioModel funcionario = _context.Funcionarios.Find(idFuncionario);

        //        if (funcionario == null)
        //        {
        //            serviceResponse.Dados = null;
        //            serviceResponse.Mensagem = "Usuário não encontrado na base de dados";
        //            serviceResponse.Sucesso = false;
        //        }

        //        funcionario.Ativo = false;
        //        funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

        //        serviceResponse.Dados = funcionario;
        //        serviceResponse.Mensagem = "Funcionário Inativado com sucesso!";

        //        //sensibiliza o bd
        //        _context.Funcionarios.Update(funcionario);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch(Exception e) 
        //    { 
        //        serviceResponse.Dados = null;
        //        serviceResponse.Sucesso = false;
        //        serviceResponse.Mensagem = e.Message;
        //    }
        //    return serviceResponse;
        //}

        //public async Task<ServiceResponseModel<FuncionarioModel>> DeleteFuncionario(int idFuncionario)
        //{
        //    ServiceResponseModel<FuncionarioModel> serviceResponse = new ServiceResponseModel<FuncionarioModel>();
        //    try
        //    {
        //        FuncionarioModel funcionario = _context.Funcionarios.Find(idFuncionario);

        //        if (funcionario == null)
        //        {
        //            serviceResponse.Mensagem = "Funcionário não encontrado";
        //            serviceResponse.Sucesso = false;
        //            serviceResponse.Dados = null;
        //            return serviceResponse;
        //        }

        //        _context.Funcionarios.Remove(funcionario);
        //        await _context.SaveChangesAsync();

        //        serviceResponse.Mensagem = "Funcionário removido com sucesso!";
        //        serviceResponse.Dados = funcionario;
        //    }
        //    catch (Exception e)
        //    {
        //        serviceResponse.Dados = null;
        //        serviceResponse.Sucesso = false;
        //        serviceResponse.Mensagem = e.Message;
        //    }
        //    return serviceResponse;
        //}


    }
}
