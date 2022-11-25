using Microsoft.EntityFrameworkCore;
using DAL.Context;

namespace QR_API
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

            builder.Services.AddDbContext<DataContext>(
                options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql"), sql => { });
                });


            var app = builder.Build();

            using (var scoped = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                if(scoped!= null)
                {
                    var context = scoped.ServiceProvider.GetRequiredService<DataContext>();
                    context.Database.Migrate();
                }
            }


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