using TrungTamLuaDao.Data;

namespace TrungTamLuaDao.Models
{
    public class Fee4Student
    {
        public int TotalFee { get; set; }
        public PageResult<Fee> Result { get; set; }

        public static int CalFee(PageResult<Fee> pageResult)
        {
            int totalFee = 0;
            foreach (var item in pageResult.data) 
            {
                if (item.Status == "Not Yet") totalFee += item.Cost;
            }
            return totalFee;
        }
    }
}
