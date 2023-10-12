using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface ILectureRepo
    {
        PageResult<Lecture> GetAll(Pagination pagination);
        Lecture GetById(int id);
        ErrorType Add(LectureModel lectureModel);
        ErrorType Update(int id, LectureModel lectureModel);
        ErrorType Delete(int id);
        PageResult<Lecture> GetByCourseId(Pagination pagination, int id);
        PageResult<Lecture> GetByCourseDate(Pagination pagination, DateTime date);
        PageResult<LectureModel> GetByStudent(Pagination pagination, string username);
    }
}
