using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class AnswerRepo : IAnswerRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public AnswerRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(AnswerModel answerModel)
        {
            var check = _context.MultipleChoiceQuestions.FirstOrDefault(x => x.MultipleChoiceQuestionID == answerModel.MultipleChoiceQuestionId);
            if (check != null && check.ManyChoices == true)
            {
                Answer answer = new()
                {
                    MultipleChoiceQuestionId = answerModel.MultipleChoiceQuestionId,
                    RightAnswer = answerModel.RightAnswer,
                    Content = answerModel.Content,
                    createAt = DateTime.Now,
                    updateAt = DateTime.Now,
                };
                _context.Answers.Add(answer);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public ErrorType Delete(int id)
        {
            var currentAns = _context.Answers.FirstOrDefault(x => x.AnswerID == id);
            if (currentAns != null)
            {
                _context.Answers.Remove(currentAns);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<Answer> GetAll(Pagination pagination)
        {
            var res = PageResult<Answer>.ToPageResult(pagination, _context.Answers.AsQueryable());
            pagination.TotalCount = _context.Answers.AsQueryable().Count();
            return new PageResult<Answer>(pagination, res);
        }

        public Answer GetById(int id)
        {
            var currentAns = _context.Answers.FirstOrDefault(x => x.AnswerID == id);
            if (currentAns != null) return currentAns;
            return null;
        }

        public PageResult<Answer> GetByMCQId(Pagination pagination, int id)
        {
            var res = PageResult<Answer>.ToPageResult(pagination, _context.Answers.Where(x => x.MultipleChoiceQuestionId == id).AsQueryable());
            pagination.TotalCount = _context.Answers.Where(x => x.MultipleChoiceQuestionId == id).AsQueryable().Count();
            return new PageResult<Answer>(pagination, res);
        }

        public ErrorType Update(int id, AnswerModel answerModel)
        {
            var currentAns = _context.Answers.FirstOrDefault(x => x.AnswerID == id);
            if (currentAns != null)
            {
                var check = _context.MultipleChoiceQuestions.FirstOrDefault(x => x.MultipleChoiceQuestionID == answerModel.MultipleChoiceQuestionId);
                if (check != null && check.ManyChoices == true)
                {
                    currentAns.MultipleChoiceQuestionId = answerModel.MultipleChoiceQuestionId;
                    currentAns.RightAnswer = answerModel.RightAnswer;
                    currentAns.Content = answerModel.Content;
                    currentAns.updateAt = DateTime.Now;
                    _context.Answers.Update(currentAns);
                    _context.SaveChanges();
                    return ErrorType.Succeed;
                }
                return ErrorType.NotExist;
            }
            return ErrorType.NotExist;
        }
    }
}
