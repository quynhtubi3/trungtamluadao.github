using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class MultipleChoiceQuestionRepo : IMultipleChoiceQuestionRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public MultipleChoiceQuestionRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(MultipleChoiceQuestionModel multipleChoiceQuestionModel)
        {
            bool check = _context.Assignments.Any(x => x.AssignmentID == multipleChoiceQuestionModel.AssignmentID);
            if (check)
            {
                MultipleChoiceQuestion multipleChoiceQuestion = new MultipleChoiceQuestion()
                {
                    AssignmentID = multipleChoiceQuestionModel.AssignmentID,
                    Content = multipleChoiceQuestionModel.Content,
                    ManyChoices = multipleChoiceQuestionModel.ManyChoices,
                    createAt = DateTime.Now,
                    updateAt = DateTime.Now
                };
                _context.MultipleChoiceQuestions.Add(multipleChoiceQuestion);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public ErrorType Delete(int id)
        {
            var currentMCQ = _context.MultipleChoiceQuestions.FirstOrDefault(x => x.MultipleChoiceQuestionID == id);
            if (currentMCQ != null)
            {
                _context.MultipleChoiceQuestions.Remove(currentMCQ);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<MultipleChoiceQuestion> GetAll(Pagination pagination)
        {
            var res = PageResult<MultipleChoiceQuestion>.ToPageResult(pagination, _context.MultipleChoiceQuestions.AsQueryable());
            pagination.TotalCount = _context.MultipleChoiceQuestions.AsQueryable().Count();
            return new PageResult<MultipleChoiceQuestion>(pagination, res);
        }

        public PageResult<MultipleChoiceQuestion> GetByAssignmentId(Pagination pagination, int id)
        {
            var res = PageResult<MultipleChoiceQuestion>.ToPageResult(pagination, _context.MultipleChoiceQuestions.Where(x => x.AssignmentID == id).AsQueryable());
            pagination.TotalCount = _context.MultipleChoiceQuestions.Where(x => x.AssignmentID == id).AsQueryable().Count();
            return new PageResult<MultipleChoiceQuestion>(pagination, res);
        }

        public MultipleChoiceQuestion GetById(int id)
        {
            var currentMCQ = _context.MultipleChoiceQuestions.FirstOrDefault(x => x.MultipleChoiceQuestionID == id);
            if (currentMCQ != null) return currentMCQ;
            return null;
        }

        public ErrorType Update(int id, MultipleChoiceQuestionModel multipleChoiceQuestionModel)
        {
            var currentMCQ = _context.MultipleChoiceQuestions.FirstOrDefault(x => x.MultipleChoiceQuestionID == id);
            if (currentMCQ != null)
            {
                bool check = _context.Assignments.Any(x => x.AssignmentID == multipleChoiceQuestionModel.AssignmentID);
                if (check)
                {
                    currentMCQ.AssignmentID = multipleChoiceQuestionModel.AssignmentID;
                    currentMCQ.Content = multipleChoiceQuestionModel.Content;
                    currentMCQ.ManyChoices = multipleChoiceQuestionModel.ManyChoices;
                    currentMCQ.updateAt = DateTime.Now;
                    _context.MultipleChoiceQuestions.Update(currentMCQ);
                    _context.SaveChanges();
                    return ErrorType.Succeed;
                }
                return ErrorType.NotExist;
            }
            return ErrorType.NotExist;
        }
    }
}
