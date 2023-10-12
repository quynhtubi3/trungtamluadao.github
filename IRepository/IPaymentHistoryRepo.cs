using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IPaymentHistoryRepo
    {
        ErrorType Add(PaymentHistoryModel model);
        ErrorType Remove(int id);
        PageResult<PaymentHistory> GetAll(Pagination pagination);
        PaymentHistory GetByID(int id);
        PageResult<PaymentHistory> GetByStudentID(Pagination pagination, int id);
        PageResult<PaymentHistory> ForStudent(Pagination pagination, string username);
        int GetRevenue();
    }
}
