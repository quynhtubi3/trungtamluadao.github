using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IAnswerRepo
    {
        PageResult<Answer> GetAll(Pagination pagination);
        PageResult<Answer> GetByMCQId(Pagination pagination, int id);
        Answer GetById(int id);
        ErrorType Add(AnswerModel answerModel);
        ErrorType Update(int id, AnswerModel answerModel);
        ErrorType Delete(int id);
    }
}
