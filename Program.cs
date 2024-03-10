using democrud.DataContext;
using democrud.Service.ClienteService;
using democrud.Service.Comercio;
using democrud.Service.FuncionarioService;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace democrud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // configuracoes do bd para persistir os dados da api
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddDbContext<DatabaseFirstCrudDemoContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // configurando o dbcontext para utilizar mysql 

            //builder.Services.AddDbContext<ComercioContext>(options =>
            //{
            //    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnectionString"), ServerVersion.AutoDetect("MySqlConnectionString"));
            //    //Server = myServerAddress; Database = myDataBase; User Id = myUsername; Password = myPassword;
            //});


            builder.Services.AddDbContext<ComercioContext>(options =>
            {
                options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnectionString"),
                                 new MySqlServerVersion(new Version(8, 0, 21))); 
            });




            // injeção de dependência para a Service ser consumida através do controller
            builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();
            builder.Services.AddScoped<IClienteInterface, ClienteService>();

            builder.Services.AddScoped<IProdutoInterface, ProdutoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}