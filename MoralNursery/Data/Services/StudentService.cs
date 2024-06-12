using MoralNursery.Data.Context;
using MoralNursery.Data.Models;
using Microsoft.EntityFrameworkCore;
using MoralNursery.Data.Services.Interfaces;

namespace MoralNursery.Data.Services
{
    public class StudentService : IStudentService
    {
        private readonly NurseryDbContext _nurseryDbContext;
        public StudentService(NurseryDbContext nurseryDbContext)
        {
            _nurseryDbContext = nurseryDbContext;
        }
        public List<Student> Students { get; set; } = new List<Student>();

        public async Task<List<Student>> GetStudents()
        {
            return await _nurseryDbContext.Students
                .Include(x => x.ClassRoom)
                .OrderBy(x => x.StudentName).ToListAsync();
            // if (result is not null)
            //     Students = result;
        }

        public async Task<bool> CreateStudent(Student Student)
        {
            await _nurseryDbContext.Students.AddAsync(Student);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStudent(Student Student)
        {
            _nurseryDbContext.Students.Update(Student);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStudent(Student Student)
        {
            _nurseryDbContext.Students.Remove(Student);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Student?> GetStudentById(int id)
        {
            Student Student = await _nurseryDbContext.Students.Include(x => x.ClassRoom)
                .FirstOrDefaultAsync(c => c.Id.Equals(id));
            return Student;
        }

        public async Task<List<Student>> GetStudenstByClassroomId(int classroomId)
        {
            return await _nurseryDbContext.Students
            .Include(x => x.ClassRoom)
            .Where(x => x.ClassRoomId == classroomId && x.IsActive==true)  
            .OrderBy(x => x.StudentName)
            .ToListAsync();
        }

        public async Task<string?> GetMaxStudentCode(string year)
        {
            return await _nurseryDbContext.Students
                .Where(s => s.StudentCode.StartsWith(year))
                .Select(s=> s.StudentCode).OrderByDescending(code => code)
                .FirstOrDefaultAsync(); 
        }
    }
}
