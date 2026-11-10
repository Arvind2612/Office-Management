
using CSharp_Ado.net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver.Core.Configuration;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace CSharp_Ado.net.Models
{
    public class StudentinforServices : IStudentdetails
    {
        private readonly string connectionString;

        public StudentinforServices(IConfiguration configuration)
        {
            connectionString =
                   configuration.GetConnectionString("DefaultConnection")!;

        }

        //Read All;
        public List<Student> GetAll()
        {
            var students = new List<Student>();

            using var Stu = new SqlConnection(connectionString);
            using var Stu2 = new SqlCommand(
                "SP_GetAllStudents", Stu);
            Stu2.CommandType = CommandType.StoredProcedure;

            Stu.Open();
            using var reader = Stu2.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student
                {
                    Student_id = reader.GetInt32(0),
                    Student_Name = reader.GetString(1),
                    Subject_name = reader.GetString(2),
                    Leaving_time = reader.GetTimeSpan(3)
                });



            }

            return students;
        }
        //Get Operation ;
        public Student? GetById(int id)
        {
            Student? student = null;
            using SqlConnection Stu = new SqlConnection(connectionString);
            using SqlCommand Stu2 = new SqlCommand(
                "Sp_GetStudentsByID", Stu);
            Stu2.CommandType = CommandType.StoredProcedure;

            Stu2.Parameters.AddWithValue("@Student_id", SqlDbType.Int).Value = id;

            Stu.Open();

            using var reader = Stu2.ExecuteReader();


            if (reader.Read())
            {
                 student = new Student
                {
                    Student_id = Convert.ToInt32(reader["Student_id"]),

                    Student_Name = reader["Student_Name"].ToString()!,

                    Subject_name = reader["Subject_name"].ToString()!,

                    Leaving_time = reader["Leaving_time"] as TimeSpan?,


                };
            }

            return student;
        }


        //Post operation 
        public string Insert(Student student)
        {
            using SqlConnection con = new SqlConnection(connectionString);

            using SqlCommand cmd = new SqlCommand(
                "SP_StudentInsertion", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Student_id", SqlDbType.Int)
                .Value = student.Student_id;

            cmd.Parameters.Add("@Student_Name", SqlDbType.VarChar, 20)
                .Value = student.Student_Name;

            cmd.Parameters.Add("@Subject_name", SqlDbType.VarChar, 20)
                .Value = student.Subject_name;

            cmd.Parameters.Add("@Created_By", SqlDbType.VarChar, 20)
                .Value = student.Created_By;

            con.Open();

            int result = cmd.ExecuteNonQuery();


            if (result > 0)
            {
                return "Student inserted successfully";
            }

            return "Student inserted";
        }
        //Put Operation 

        public string Update(int id, Student student)
        {
            using SqlConnection con = new SqlConnection(connectionString);

            using SqlCommand cmd = new SqlCommand(
                "SP_StudentsUpdates", con);

            cmd.CommandType = CommandType.StoredProcedure;

            // Pass Student ID
            cmd.Parameters.Add("@Student_id", SqlDbType.Int).Value = id;

            // Pass Student Name
            cmd.Parameters.Add("@Student_Name", SqlDbType.VarChar, 20)
                .Value = student.Student_Name;

            // Pass Subject Name
            cmd.Parameters.Add("@Subject_name", SqlDbType.VarChar, 20)
                .Value = student.Subject_name;

            // Pass Updated By
            cmd.Parameters.Add("@Updated_By", SqlDbType.VarChar, 20)
                .Value = student.Updated_By;

            con.Open();

            // Get the message returned by SQL Server
            string result = Convert.ToString(cmd.ExecuteScalar())!;

            return result;

        }
        public int Delete(int id)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(
                "SP_StudentDelete", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@Student_id", SqlDbType.Int).Value = id;

            con.Open();

            int result = (cmd.ExecuteNonQuery())!;

            return result;
        }
    }
}

    








