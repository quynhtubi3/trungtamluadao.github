using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface ITutorRepo
    {
        PageResult<Tutor> GetAll(Pagination pagination);
        Tutor GetById(int id);
        ErrorType Add(TutorModel tutorModel);
        ErrorType Update(int id, TutorModel tutorModel);
        ErrorType Delete(int id);        
    }
}
