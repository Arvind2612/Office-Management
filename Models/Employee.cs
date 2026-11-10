using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Office_managementAPI.Models
{
  

    public class Employee
    {
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters")]
        public required string Name { get; set; } 
        public required string Role { get; set; }  
        public required string DomainName { get; set; }
        public required string Email { get; set; }
       


       
    }
}
    

