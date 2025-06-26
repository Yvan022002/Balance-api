
using Balance_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Balance_API
{
    public class Program
    {


        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<BalanceDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BalanceDbContext>();
                Console.WriteLine(db.Database.GetDbConnection().ConnectionString);
                Console.WriteLine(db.Database.CanConnect() ? " Connexion OK" : "Connexion échouée");
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BalanceDbContext>();
                Console.WriteLine("Chaîne : " + db.Database.GetDbConnection().ConnectionString);
                Console.WriteLine(db.Database.CanConnect() ? "✔ Connexion OK" : "❌ Connexion échouée");
            }


            app.Run();
        }
    }
}
