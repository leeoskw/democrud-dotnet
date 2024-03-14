using democrud.models;
using democrud.Service.FuncionarioService;
using Xunit;
using Moq;
using democrud.Enums;
using democrud.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace democrud.Tests.Controllers
{
    public class FuncionarioControllerTest
    {
        [Fact]
        public async Task GetAllFuncionarios_ReturnsOkResult_WithFuncionarios()
        {
            // Arrange
            var funcionarioServiceMock = new Mock<IFuncionarioInterface>();
            var funcionarios = new List<FuncionarioModel>()
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

            var expectedResponse = new ServiceResponseModel<List<FuncionarioModel>> { Dados = funcionarios };
            funcionarioServiceMock.Setup(service => service.GetFuncionarios()).ReturnsAsync(expectedResponse);
            
            var funcionarioController = new FuncionarioController(funcionarioServiceMock.Object);

            // Act
            var result = await funcionarioController.getAllFuncionarios();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var serviceResponse = Assert.IsType<ServiceResponseModel<List<FuncionarioModel>>>(okResult.Value);
            Assert.Equal(funcionarios, serviceResponse.Dados);
        }

    }
}
