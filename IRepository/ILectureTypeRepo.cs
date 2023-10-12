using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface ILectureTypeRepo
    {
        PageResult<LectureType> GetAll(Pagination pagination);
        LectureType GetById(int id);
        ErrorType Add(LectureTypeModel lectureModel);
        ErrorType Update(int id, LectureTypeModel lectureModel);
        ErrorType Delete(int id);
    }
}
