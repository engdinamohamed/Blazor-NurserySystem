using MoralNursery.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MoralNursery.Data.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string GuardianPrimaryName { get; set; }
        public string GuardianPrimaryTel { get; set; }
        public string GuardianPrimaryAddress { get; set; }
        //public string? GuardianSecName { get; set; }
        //public string? GuardianSecTel { get; set; }
        //public string? GuardianSecAddress { get; set; }
        //public string? Allergies { get; set; }
        //public string? MdeicalConditions { get; set; }
        //public DateTime AddedIn { get; set; }
        //public int ClassRoomId { get; set; }
        public string ClassName { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }

        public bool IsActive { get; set; }

    }
}
