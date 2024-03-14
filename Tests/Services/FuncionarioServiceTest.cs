using democrud.Enums;
using democrud.models;
using democrud.Repositories.Funcionario;
using democrud.Service.FuncionarioService;
using Moq;
using Xunit;

namespace democrud.Tests.Services
{
    public class FuncionarioServiceTest
    {
        [Fact]
        public async Task GetFuncionarios_ReturnsServiceResponse_WithFuncionarios()
        {
            // Arrange
            var funcionarioRepositoryMock = new Mock<IFuncionarioRepository>();
            var funcionarios = new List<FuncionarioModel>
            {
                new FuncionarioModel
                {
                    Id = 1,
                    Nome = "João",
                    Sobrenome = "Silva",
                    Departamento = DepartamentoEnum.Financeiro,
                    Ativo = true,
                    Turno = TurnoEnum.Manha,
                    DataDeCriacao = DateTime.Now.AddDays(-5),
                    DataDeAlteracao = DateTime.Now.AddDays(-2)
                },
                new FuncionarioModel
                {
                    Id = 2,
                    Nome = "Maria",
                    Sobrenome = "Souza",
                    Departamento = DepartamentoEnum.RH,
                    Ativo = true,
                    Turno = TurnoEnum.Tarde,
                    DataDeCriacao = DateTime.Now.AddDays(-3),
                    DataDeAlteracao = DateTime.Now.AddDays(-1)
                }
            };
            funcionarioRepositoryMock.Setup(repo => repo.GetFuncionarios()).ReturnsAsync(funcionarios);

            var funcionarioService = new FuncionarioService(funcionarioRepositoryMock.Object);

            // Act
            var serviceResponse = await funcionarioService.GetFuncionarios();

            // Assert
            Assert.NotNull(serviceResponse);
            Assert.True(serviceResponse.Sucesso);
            Assert.Equal(funcionarios, serviceResponse.Dados);
        }

        [Fact]
        public async Task GetFuncionarioById_ReturnsServiceResponse_WithFuncionario()
        {
            // Arrange
            var funcionarioRepositoryMock = new Mock<IFuncionarioRepository>();
            var funcionario = new FuncionarioModel
            {
                Id = 2,
                Nome = "Maria",
                Sobrenome = "Souza",
                Departamento = DepartamentoEnum.RH,
                Ativo = true,
                Turno = TurnoEnum.Tarde,
                DataDeCriacao = DateTime.Now.AddDays(-3),
                DataDeAlteracao = DateTime.Now.AddDays(-1)
            };


            funcionarioRepositoryMock.Setup(repo => repo.GetFuncionarioById(1)).ReturnsAsync(funcionario);

            var funcionarioService = new FuncionarioService(funcionarioRepositoryMock.Object);

            // Act
            var serviceResponse = await funcionarioService.GetFuncionarioById(1);

            // Assert
            Assert.NotNull(serviceResponse);
            Assert.True(serviceResponse.Sucesso);
            Assert.Equal(funcionario, serviceResponse.Dados);
        }
    }
}
