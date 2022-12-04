using Microsoft.EntityFrameworkCore;
using DAL.Context;
using QR_API.Services;

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

            builder.Services.AddScoped<QrServices>();
            builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

            builder.Services.AddDbContext<DataContext>(
                options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql"), sql => { });
                });


            var _myPolicyCors = "_myPolicyCors";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(_myPolicyCors, policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod();
                });
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
                
                    app.UseSwagger();
                    app.UseSwaggerUI();
                

            

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(_myPolicyCors);
            app.MapControllers();

            app.Run();
        }
    }
}