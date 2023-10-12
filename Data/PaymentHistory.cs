using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("PaymentHistorys")]
    public class PaymentHistory
    {
        [Key]
        public int PaymentHistoryID { get; set; }
        public int StudentID { get; set; }
        public int PaymentTypeID { get; set; }
        public string PaymentName { get; set; }
        public int Amount { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }

        public Student Student { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
