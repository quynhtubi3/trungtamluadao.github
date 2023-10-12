using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class PaymentTypeRepo : IPaymentTypeRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public PaymentTypeRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(PaymentTypeModel model)
        {
            PaymentType paymentType = new PaymentType()
            {
                PaymentTypeName = model.PaymentTypeName,
                creatAt = DateTime.Now,
                updatedAt = DateTime.Now
            };
            _context.PaymentTypes.Add(paymentType);
            _context.SaveChanges();
            return ErrorType.Succeed;
        }

        public ErrorType Remove(int id)
        {
            var current = _context.PaymentTypes.FirstOrDefault(x => x.PaymentTypeID == id);
            if (current != null)
            {
                _context.PaymentTypes.Remove(current);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }
    }
}
