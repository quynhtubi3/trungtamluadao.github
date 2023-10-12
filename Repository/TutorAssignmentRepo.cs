using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class TutorAssignmentRepo : ITutorAssignmentRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public TutorAssignmentRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(TutorAssignmentModel tutorAssignmentModel)
        {
            bool check = _context.Tutors.Any(x => x.TutorID == tutorAssignmentModel.TutorID) && _context.Courses.Any(x => x.CourseID == tutorAssignmentModel.CourseID);
            if (check)
            {
                TutorAssignment tutorAssignment = new TutorAssignment()
                {
                    TutorID = tutorAssignmentModel.TutorID,
                    CourseID = tutorAssignmentModel.CourseID,
                    AssignmentDate = tutorAssignmentModel.AssignmentDate,
                    NumberOfStudent = 0,
                    createAt = DateTime.Now,
                    updateAt = DateTime.Now
                };
                _context.TutorAssignments.Add(tutorAssignment);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public ErrorType Delete(int id)
        {
            var currentTA = _context.TutorAssignments.FirstOrDefault(x => x.TutorAssignmentID == id);
            if (currentTA != null)
            {
                _context.TutorAssignments.Remove(currentTA);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<TutorAssignment> GetAll(Pagination pagination)
        {
            var res = PageResult<TutorAssignment>.ToPageResult(pagination, _context.TutorAssignments.AsQueryable());
            pagination.TotalCount = _context.TutorAssignments.AsQueryable().Count();
            return new PageResult<TutorAssignment>(pagination, res);
        }

        public PageResult<TutorAssignment> GetByCourseId(Pagination pagination, int id)
        {
            var res = PageResult<TutorAssignment>.ToPageResult(pagination, _context.TutorAssignments.Where(x => x.CourseID == id).AsQueryable());
            pagination.TotalCount = _context.TutorAssignments.Where(x => x.CourseID == id).AsQueryable().Count();
            return new PageResult<TutorAssignment>(pagination, res);
        }

        public PageResult<TutorAssignment> GetByDate(Pagination pagination, DateTime date)
        {
            var res = PageResult<TutorAssignment>.ToPageResult(pagination, _context.TutorAssignments.Where(x => x.AssignmentDate.Date == date.Date).AsQueryable());
            pagination.TotalCount = _context.TutorAssignments.Where(x => x.AssignmentDate.Date == date.Date).AsQueryable().Count();
            return new PageResult<TutorAssignment>(pagination, res);
        }

        public TutorAssignment GetById(int id)
        {
            var currentTA = _context.TutorAssignments.FirstOrDefault(x => x.TutorAssignmentID == id);
            if (currentTA != null) return currentTA;
            return null;
        }

        public PageResult<TutorAssignment> GetByTutorId(Pagination pagination, int id)
        {
            var res = PageResult<TutorAssignment>.ToPageResult(pagination, _context.TutorAssignments.Where(x => x.TutorID == id).AsQueryable());
            pagination.TotalCount = _context.TutorAssignments.Where(x => x.TutorID == id).AsQueryable().Count();
            return new PageResult<TutorAssignment>(pagination, res);
        }

        public PageResult<TutorAssignment> GetForTutor(Pagination pagination, string username)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.userName == username);
            var currentTutor = _context.Tutors.FirstOrDefault(x => x.accountID == currentAccount.accountID);
            var res = PageResult<TutorAssignment>.ToPageResult(pagination, _context.TutorAssignments.Where(x => x.TutorID == currentTutor.TutorID).AsQueryable());
            pagination.TotalCount = res.Count();
            return new PageResult<TutorAssignment>(pagination, res);
        }

        public ErrorType Update(int id, TutorAssignmentModel tutorAssignmentModel)
        {
            var currentTA = _context.TutorAssignments.FirstOrDefault(x => x.TutorAssignmentID == id);
            if (currentTA != null)
            {
                bool check = _context.Tutors.Any(x => x.TutorID == tutorAssignmentModel.TutorID) && _context.Courses.Any(x => x.CourseID == tutorAssignmentModel.CourseID);
                if (check)
                {
                    currentTA.TutorID = tutorAssignmentModel.TutorID;
                    currentTA.CourseID = tutorAssignmentModel.CourseID;
                    currentTA.AssignmentDate = tutorAssignmentModel.AssignmentDate;
                    currentTA.updateAt = DateTime.Now;
                    _context.TutorAssignments.Update(currentTA);
                    _context.SaveChanges();
                    return ErrorType.Succeed;
                }
                return ErrorType.NotExist;
            }
            return ErrorType.NotExist;
        }

        public ErrorType UpdateNumberOfStudent(int id, int type)
        {
            var currentTA = _context.TutorAssignments.FirstOrDefault(x => x.TutorAssignmentID == id);
            currentTA.NumberOfStudent = currentTA.NumberOfStudent + 1 * type;
            _context.TutorAssignments.Update(currentTA);
            _context.SaveChanges();
            return ErrorType.Succeed;
        }
    }
}
