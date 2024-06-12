﻿using MoralNursery.Data.Models;

namespace MoralNursery.Data.Dtos
{
    public class RegisterDto
    {
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string FeeMethodName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public DateTime AddedIn { get; set; }
        public string? FullName { get; set; }
        public float TotalFees { get; set; }
    }
}
