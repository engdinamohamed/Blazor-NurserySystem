using Microsoft.EntityFrameworkCore;
using MoralNursery.Data.Context;
using MoralNursery.Data.Models;
using MoralNursery.Data.Services.Interfaces;
using System.Numerics;

namespace MoralNursery.Data.Services
{
    public class ClassRoomService : IClassRoomService
    {
        private readonly NurseryDbContext _nurseryDbContext;
        public ClassRoomService(NurseryDbContext nurseryDbContext)
        {
            _nurseryDbContext = nurseryDbContext;
        }
        public List<ClassRoom> ClassRooms { get; set; }=new List<ClassRoom>();

        public async Task<List<ClassRoom>> GetClassRooms()
        {
            return await _nurseryDbContext.ClassRooms.ToListAsync();
           // if (result is not null)
           //     ClassRooms = result;
        }

        public async Task<bool> CreateClassRoom(ClassRoom classRoom)
        {
            await _nurseryDbContext.ClassRooms.AddAsync(classRoom);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateClassRoom(ClassRoom classRoom)
        {
            _nurseryDbContext.ClassRooms.Update(classRoom);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClassRoom(ClassRoom classRoom)
        {
            _nurseryDbContext.ClassRooms.Remove(classRoom);
            await _nurseryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ClassRoom?> GetClassRoomById(int id)
        {
            ClassRoom classRoom = await _nurseryDbContext.ClassRooms.FirstOrDefaultAsync(c => c.Id.Equals(id));
            return classRoom;
        }

        public async Task<ClassRoom?> GetClassRoomByName(string className)
        {
            ClassRoom classRoom = await _nurseryDbContext.ClassRooms.FirstOrDefaultAsync(c => c.ClassName.Equals(className));
            return classRoom;
        }

        public async Task<int?> GetStudentNumberInClassroom(int id)
        {
            int count = 0;
            count = await _nurseryDbContext.Students.Where(s=> s.ClassRoomId==id).CountAsync();
            return count;
        }
    }
}
