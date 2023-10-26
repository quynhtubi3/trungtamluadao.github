using System.ComponentModel.DataAnnotations;

namespace TrungTamLuaDao.Data
{
    public class TutorModel
    {
        [Required] public int accountID {get; set;}
        [Required] public string FirstName {get; set;}
        [Required] public string LastName {get; set;}
        [Required] public string ContactNumber {get; set;}
        public string Address { get; set; }
        public string HomeTown { get; set; }
        [Required] public string Email {get; set;}
    }
}
