using CSharp_Ado.net.Models;
 

namespace CSharp_Ado.net.Models
{
    public interface IStudentdetails
    {
        
        List<Student> GetAll();
        Student? GetById(int id);
        string Insert(Student student);
        string Update(int id,  Student  student);
        int  Delete(int id);


    }
}
