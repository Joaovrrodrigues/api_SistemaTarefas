using Microsoft.EntityFrameworkCore;
using SistemaTarefas1.Data;
using SistemaTarefas1.Repositorios.Interfaces;
using SistemaTarefas1.Repositorios;

namespace SistemaTarefas1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionStringMySql = builder.Configuration.GetConnectionString("DataBase");
            builder.Services.AddDbContext<SistemaTarefasDBContex>(options => options.UseMySql(
                connectionStringMySql, ServerVersion.Parse("8.0.36")));

            builder.Services.AddControllers();
            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();

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
