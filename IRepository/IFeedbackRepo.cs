using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IFeedbackRepo
    {
        PageResult<Feedback> GetAll(Pagination pagination);
        Feedback GetById(int id);
        ErrorType Add(FeedbackModel feedbackModel);
        ErrorType Update(int id, FeedbackModel feedbackModel);
        ErrorType Delete(int id);
        PageResult<Feedback> GetBySubId(Pagination pagination, int id);
        PageResult<Feedback> GetByTutorId(Pagination pagination, int id);
        PageResult<Feedback> GetByDate(Pagination pagination, DateTime date);
        PageResult<Feedback> GetByGrade(Pagination pagination, float grade);
        ErrorType CreateRandomFeedback();
    }
}
