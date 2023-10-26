using System.ComponentModel.DataAnnotations;
using TrungTamLuaDao.Helpers;

namespace TrungTamLuaDao.Models
{
    public class UpdateInfo4Student
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string ContactNumber { get; set; }      
        [EmailAddress]
        public string? Email { get; set; }
    }
}
