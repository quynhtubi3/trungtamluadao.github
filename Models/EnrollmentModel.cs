﻿using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class EnrollmentModel
    {
        [Required] public int StudentID { get; set; }
        [Required] public int CourseID { get; set; }
        [Required] public DateTime EnrollmentDate { get; set; }
    }
}
