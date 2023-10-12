using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrungTamLuaDao.Data
{
    [Table("PaymentTypes")]
    public class PaymentType
    {
        [Key]
        public int PaymentTypeID { get; set; }
        [Required]
        public string PaymentTypeName { get; set;}
        public DateTime creatAt { get; set; }
        public DateTime updatedAt { get; set; }

        public IEnumerable<PaymentHistory> PaymentHistorys { get; set; }
    }
}
