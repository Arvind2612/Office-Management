using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Office_managementAPI.Models;
namespace Office_managementAPI.Data
{
    public class ApplicationDBContent : DbContext
    {
        public ApplicationDBContent(DbContextOptions<ApplicationDBContent>options) : base(options)
        {

        }
        public DbSet<Employee> EmpDB { get; set; }


    }
     
}
