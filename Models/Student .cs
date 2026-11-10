using System;
using Microsoft.Data.SqlClient;
using Swashbuckle.AspNetCore.Annotations;

namespace CSharp_Ado.net.Models
{
    public class Student
    {
        public int Student_id { get; set; }
        public required string Student_Name { get; set; }
        public required string Subject_name { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public  TimeSpan? Leaving_time { get; set; }
        public string Created_By { get; set; } = "";

        [SwaggerSchema(ReadOnly = true)]
        public DateTime? Created_Date { get; set; }

        public string Updated_By { get; set; } = "";

        [SwaggerSchema(ReadOnly = true)]
        public DateTime? Updated_Date { get; set; }
    }
}



