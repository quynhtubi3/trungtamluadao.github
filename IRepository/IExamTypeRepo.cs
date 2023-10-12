using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IExamTypeRepo
    {
        PageResult<ExamType> GetAll(Pagination pagination);
        ExamType GetById(int id);
        ErrorType Add(ExamTypeModel examTypeModel);
        ErrorType Update(int id, ExamTypeModel examTypeModel);
        ErrorType Delete(int id);
    }
}
