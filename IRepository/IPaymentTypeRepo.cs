using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IPaymentTypeRepo
    {
        ErrorType Add(PaymentTypeModel model);
        ErrorType Remove(int id);
    }
}
