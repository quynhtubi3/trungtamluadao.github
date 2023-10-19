using Microsoft.AspNetCore.Mvc.RazorPages;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IStudentRepo
    {
        PageResult<Student> GetAll(Pagination pagination);
        Student GetById(int id);
        ErrorType Add(StudentModel studentModel);
        ErrorType Remove(int id);
        ErrorType Update(int id, StudentModel studentModel);
        ErrorType UpdateTotalMoney(int id, int money, int type);
        bool UpdateInfomation(string userName, UpdateInfo4Student model);
    }
}
