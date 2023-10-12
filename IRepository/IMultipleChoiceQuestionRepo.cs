using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IMultipleChoiceQuestionRepo
    {
        PageResult<MultipleChoiceQuestion> GetAll(Pagination pagination);
        MultipleChoiceQuestion GetById(int id);
        ErrorType Add(MultipleChoiceQuestionModel multipleChoiceQuestionModel);
        ErrorType Update(int id, MultipleChoiceQuestionModel multipleChoiceQuestionModel);
        ErrorType Delete(int id);
        PageResult<MultipleChoiceQuestion> GetByAssignmentId(Pagination pagination, int id);
    }
}
