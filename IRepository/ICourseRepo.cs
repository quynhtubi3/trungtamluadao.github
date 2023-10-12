using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface ICourseRepo
    {
        PageResult<Course> GetAll(Pagination pagination);
        Course GetById(int id);
        ErrorType Add(CourseModel courseModel);
        ErrorType Update(int id, CourseModel courseModel);
        ErrorType Delete(int id);
    }
}
