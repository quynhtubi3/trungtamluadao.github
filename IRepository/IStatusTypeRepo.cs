using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IStatusTypeRepo
    {
        PageResult<StatusType> GetAll(Pagination pagination);
        StatusType GetById(int id);
        ErrorType Add(StatusTypeModel tutorModel);
        ErrorType Update(int id, StatusTypeModel tutorModel);
        ErrorType Delete(int id);
    }
}
