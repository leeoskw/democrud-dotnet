using democrud.DataContext;
using democrud.Enums;
using democrud.models;
using democrud.Repositories.Funcionario;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace democrud.Tests.Repositories
{
    public class FuncionarioRepositoryTest
    {
        [Fact]
        public async Task GetFuncionarios_ReturnsListOfFuncionarios()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var funcionariosInMemory = new List<FuncionarioModel>
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

            using (var context = new ApplicationDbContext(options))
            {
                context.Funcionarios.AddRange(funcionariosInMemory);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var funcionarioRepository = new FuncionarioRepository(context);

                // Act
                var funcionarios = await funcionarioRepository.GetFuncionarios();

                // Assert
                Assert.NotNull(funcionarios);
                Assert.Equal(funcionariosInMemory.Count, funcionarios.Count);
                foreach (var funcionario in funcionarios)
                {
                    Assert.Contains(funcionario, funcionariosInMemory);
                }
            }
        }

        [Fact]
        public async Task GetFuncionarioById_ReturnsFuncionario_WhenExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var funcionarioInMemory = new FuncionarioModel { Id = 1, Nome = "João", /* outros atributos */ };

            using (var context = new ApplicationDbContext(options))
            {
                context.Funcionarios.Add(funcionarioInMemory);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var funcionarioRepository = new FuncionarioRepository(context);

                // Act
                var funcionario = await funcionarioRepository.GetFuncionarioById(1);

                // Assert
                Assert.NotNull(funcionario);
                Assert.Equal(funcionarioInMemory.Id, funcionario.Id);
            }
        }

        [Fact]
        public async Task CreateFuncionario_ReturnsCreatedFuncionario()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var novoFuncionario = new FuncionarioModel { Id = 1, Nome = "João", /* outros atributos */ };

            using (var context = new ApplicationDbContext(options))
            {
                var funcionarioRepository = new FuncionarioRepository(context);

                // Act
                var createdFuncionario = await funcionarioRepository.CreateFuncionario(novoFuncionario);

                // Assert
                Assert.NotNull(createdFuncionario);
                Assert.Equal(novoFuncionario.Id, createdFuncionario.Id);

                var funcionarioFromDb = await context.Funcionarios.FindAsync(novoFuncionario.Id);
                Assert.NotNull(funcionarioFromDb);
                Assert.Equal(novoFuncionario, funcionarioFromDb);
            }
        }
    }
}
