using MoralNursery.Data.Models;

namespace MoralNursery.Data.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudents();
        Task<Student?> GetStudentById(int id);
        Task<string?> GetMaxStudentCode(string year);        
        Task<List<Student>> GetStudenstByClassroomId(int classroomId);

        Task<bool> CreateStudent(Student student);
        Task<bool> UpdateStudent(Student student);
        Task<bool> DeleteStudent(Student student);
    }
}
