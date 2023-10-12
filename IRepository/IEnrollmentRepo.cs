using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IEnrollmentRepo
    {
        PageResult<Enrollment> GetAll(Pagination pagination);
        Enrollment GetById(int id);
        ErrorType Add(EnrollmentModel enrollmentModel);
        ErrorType Update(int id, EnrollmentModel enrollmentModel);
        ErrorType Delete(int id);
        PageResult<Enrollment> GetByStudentId(Pagination pagination, int id);
        PageResult<Enrollment> GetByCourseId(Pagination pagination, int id);
        PageResult<Enrollment> GetByDate(Pagination pagination, DateTime date);
        ErrorType ChangeStatus(int id, int statusId);
        IEnumerable<CoursePercentModel> GetCoursePercents();
        IEnumerable<EnrollStatusPercentModel> GetEnrollStatusPercents();
    }
}
