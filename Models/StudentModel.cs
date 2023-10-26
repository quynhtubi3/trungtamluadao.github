using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class StudentModel
    {
        [Required] public int accountId { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string HomeTown { get; set; }
        [Required] public string Email { get; set; }
    }
}
