
using ApiScp.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiScp
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

            //string de conexão com o bd
            string sqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(sqlConnection));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (false)
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
