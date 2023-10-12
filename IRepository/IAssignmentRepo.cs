using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IAssignmentRepo
    {
        PageResult<Assignment> GetAll(Pagination pagination);
        Assignment GetById(int id);
        ErrorType Add(AssignmentModel assignmentModel);
        ErrorType Update(int id, AssignmentModel assignmentModel);
        ErrorType Delete(int id);
        PageResult<Assignment> GetByCourseId(Pagination pagination, int id);
        PageResult<Assignment> GetExamTypeId(Pagination pagination, int id);
        PageResult<AssignmentModelForStudent> GetForStudent(Pagination pagination, string username);
    }
}
