using TrungTamLuaDao.Data;

namespace TrungTamLuaDao.Models
{
    public class StudentNotPaidModel
    {
        public int StudentID { get; set; }
        public IEnumerable<Fee> Fees { get; set; }
    }
}
