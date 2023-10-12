using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class AssignmentRepo : IAssignmentRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public AssignmentRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(AssignmentModel assignmentModel)
        {
            var check = _context.Courses.Any(x => x.CourseID == assignmentModel.CourseID) && _context.ExamTypes.Any(x => x.ExamTypeID == assignmentModel.ExamTypeID);
            if (check)
            {
                Assignment assignment = new()
                {
                    CourseID = assignmentModel.CourseID,
                    ExamTypeID = assignmentModel.ExamTypeID,
                    AssignmentName = assignmentModel.AssignmentName,
                    Description = assignmentModel.Description,
                    WorkTime = assignmentModel.WorkTime,
                    DueDate = assignmentModel.DueDate,
                    MinGrade = assignmentModel.MinGrade,
                    createAt = DateTime.Now,
                    updateAt = DateTime.Now,
                };
                _context.Assignments.Add(assignment);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public ErrorType Delete(int id)
        {
            var currentAssign = _context.Assignments.FirstOrDefault(x => x.AssignmentID == id);
            if (currentAssign != null)
            {
                _context.Assignments.Remove(currentAssign);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<Assignment> GetAll(Pagination pagination)
        {
            var res = PageResult<Assignment>.ToPageResult(pagination, _context.Assignments.AsQueryable());
            pagination.TotalCount = _context.Assignments.AsQueryable().Count();
            return new PageResult<Assignment>(pagination,res);
        }

        public PageResult<Assignment> GetByCourseId(Pagination pagination, int id)
        {
            var res = PageResult<Assignment>.ToPageResult(pagination, _context.Assignments.Where(x => x.CourseID == id).AsQueryable());
            pagination.TotalCount = _context.Assignments.Where(x => x.CourseID == id).AsQueryable().Count();
            return new PageResult<Assignment>(pagination, res);
        }

        public Assignment GetById(int id)
        {
            var assignment = _context.Assignments.FirstOrDefault(x => x.AssignmentID == id);
            if (assignment != null) return assignment;
            return null;
        }

        public PageResult<Assignment> GetExamTypeId(Pagination pagination, int id)
        {
            var res = PageResult<Assignment>.ToPageResult(pagination, _context.Assignments.Where(x => x.ExamTypeID == id).AsQueryable());
            pagination.TotalCount = _context.Assignments.Where(x => x.ExamTypeID == id).AsQueryable().Count();
            return new PageResult<Assignment>(pagination, res);
        }

        public PageResult<AssignmentModelForStudent> GetForStudent(Pagination pagination, string username)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.userName == username);
            var currentStudent = _context.Students.FirstOrDefault(x => x.accountID == currentAccount.accountID);
            var lstEnrollment = _context.Enrollments.Where(x => x.StudentID == currentStudent.StudentID).ToList();
            List<AssignmentModelForStudent> res = new List<AssignmentModelForStudent>();
            foreach (var enrollment in lstEnrollment)
            {
                foreach (var assignment in _context.Assignments.ToList())
                {
                    if (assignment.CourseID == enrollment.CourseID)
                    {
                        AssignmentModelForStudent model = new AssignmentModelForStudent()
                        {
                            AssignmentName = assignment.AssignmentName,
                            Description = assignment.Description,
                            WorkTime = assignment.WorkTime,
                            DueDate = assignment.DueDate,
                            MinGrade = assignment.MinGrade
                        };
                        res.Add(model);
                    }
                }
            }
            return new PageResult<AssignmentModelForStudent>(pagination, res);
        }

        public ErrorType Update(int id, AssignmentModel assignmentModel)
        {
            var currentAssign = _context.Assignments.FirstOrDefault(x => x.AssignmentID == id);
            if (currentAssign != null)
            {
                var check = _context.Courses.Any(x => x.CourseID == assignmentModel.CourseID) && _context.ExamTypes.Any(x => x.ExamTypeID == assignmentModel.ExamTypeID);
                if (check)
                {
                    currentAssign.CourseID = assignmentModel.CourseID;
                    currentAssign.ExamTypeID = assignmentModel.ExamTypeID;
                    currentAssign.AssignmentName = assignmentModel.AssignmentName;
                    currentAssign.Description = assignmentModel.Description;
                    currentAssign.WorkTime = assignmentModel.WorkTime;
                    currentAssign.DueDate = assignmentModel.DueDate;
                    currentAssign.MinGrade = assignmentModel.MinGrade;
                    currentAssign.updateAt = DateTime.Now;
                    _context.Assignments.Update(currentAssign);
                    _context.SaveChanges();
                    return ErrorType.Succeed;
                }
                return ErrorType.NotExist;                
            }
            return ErrorType.NotExist;
        }
    }
}
