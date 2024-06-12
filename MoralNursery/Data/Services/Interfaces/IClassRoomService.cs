using MoralNursery.Data.Models;

namespace MoralNursery.Data.Services.Interfaces
{
    public interface IClassRoomService
    {
        List<ClassRoom> ClassRooms { get; set; }
        Task<List<ClassRoom>> GetClassRooms();
        Task<ClassRoom?> GetClassRoomById(int id);
        Task<ClassRoom?> GetClassRoomByName(string className);
        Task<int?> GetStudentNumberInClassroom(int id);
        Task<bool> CreateClassRoom(ClassRoom classRoom);
        Task<bool> UpdateClassRoom(ClassRoom classRoom);
        Task<bool> DeleteClassRoom(ClassRoom classRoom);
    }
}
