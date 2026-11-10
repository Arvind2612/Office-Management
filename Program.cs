using CSharp_Ado.net.Models;
using Microsoft.EntityFrameworkCore;
using Office_managementAPI.Data;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        #region Data connectivity
        builder.Services.AddDbContext<ApplicationDBContent>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
        #endregion
        

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddScoped<IStudentdetails, StudentinforServices>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
        });

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

