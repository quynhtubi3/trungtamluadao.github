using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IFeeRepo
    {
        ErrorType Add(FeeModel feeModel);
        ErrorType Remove(int id);
        void ChangeStatus(int id);
        PageResult<Fee> GetAll(Pagination pagination);
        Fee4Student forStudent(string username, Pagination pagination);
        ErrorType payFee(string username, int id);
        IEnumerable<StudentNotPaidModel> GetStudentNotPaid();
    }
}
