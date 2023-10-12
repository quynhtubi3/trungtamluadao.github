using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class SubmissionRepo : ISubmissionRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        private readonly IEnrollmentRepo _enrollmentRepo;
        private readonly IFeeRepo _feeRepo;
        public SubmissionRepo()
        {
            _context = new TrungTamLuaDaoContext();
            _enrollmentRepo = new EnrollmentRepo();
            _feeRepo = new FeeRepo();
        }
        public ErrorType Add(SubmissionModel submissionModel)
        {
            bool check = _context.Assignments.Any(x => x.AssignmentID == submissionModel.AssignmentID) && _context.Students.Any(x => x.StudentID == submissionModel.StudentID);
            if (check)
            {                
                var currentAssignment = _context.Assignments.FirstOrDefault(x => x.AssignmentID == submissionModel.AssignmentID);
                var currentEnrollment = _context.Enrollments.FirstOrDefault(x => x.StudentID == submissionModel.StudentID && x.CourseID == currentAssignment.CourseID);
                var lstEnroll = _context.Enrollments.Where(x => x.StudentID == submissionModel.StudentID).ToList();
                if (currentEnrollment != null && currentEnrollment.StatusTypeID != 2 && currentEnrollment.StatusTypeID != 3 && currentEnrollment.StatusTypeID != 4)
                {
                    bool checkTimes = _context.Submissions.Any(x => x.StudentID == submissionModel.StudentID && x.AssignmentID == submissionModel.AssignmentID);
                    if (checkTimes)
                    {
                        var currentTimes = _context.Submissions.Where(x => x.StudentID == submissionModel.StudentID && x.AssignmentID == submissionModel.AssignmentID).ToList();
                        if (currentTimes[currentTimes.Count() - 1].Grade < currentAssignment.MinGrade)
                        {
                            if (currentTimes[currentTimes.Count() - 1].ExamTimes < 3)
                            {
                                var Times = currentTimes[currentTimes.Count() - 1].ExamTimes;
                                Times++;
                                Submission submission1 = new Submission()
                                {
                                    AssignmentID = submissionModel.AssignmentID,
                                    StudentID = submissionModel.StudentID,
                                    SubmissionDate = submissionModel.SubmissionDate,
                                    Grade = submissionModel.Grade,
                                    ExamTimes = Times,
                                    createAt = DateTime.Now,
                                    updateAt = DateTime.Now
                                };
                                _context.Submissions.Add(submission1);
                                _context.SaveChanges();                                
                                _feeRepo.Add(new FeeModel()
                                {
                                    Cost = 100000,
                                    CourseID = currentAssignment.CourseID,
                                    StudenID = submissionModel.StudentID
                                });
                                return ErrorType.Succeed;
                            }
                            var currentGrade = submissionModel.Grade;
                            if (currentGrade < currentAssignment.MinGrade)
                            {
                                _enrollmentRepo.ChangeStatus(currentEnrollment.EnrollmentID, 5);
                            }
                            return ErrorType.OutOfTimes;
                        }
                        return ErrorType.Passed;
                    }
                    Submission submission = new Submission()
                    {
                        AssignmentID = submissionModel.AssignmentID,
                        StudentID = submissionModel.StudentID,
                        SubmissionDate = submissionModel.SubmissionDate,
                        Grade = submissionModel.Grade,
                        ExamTimes = 1,
                        createAt = DateTime.Now,
                        updateAt = DateTime.Now
                    };
                    _context.Submissions.Add(submission);
                    _context.SaveChanges();
                    return ErrorType.Succeed;
                }               
            }
            return ErrorType.NotExist;
        }

        public ErrorType Delete(int id)
        {
            var currentSubmission = _context.Submissions.FirstOrDefault(x => x.SubmissionID == id);
            if (currentSubmission != null)
            {
                _context.Submissions.Remove(currentSubmission);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<SubmissionModelForStudent> ForStudent(Pagination pagination, string username)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.userName == username);
            var currentStudent = _context.Students.FirstOrDefault(x => x.accountID == currentAccount.accountID);
            List<SubmissionModelForStudent> lstres = new List<SubmissionModelForStudent>();
            foreach (var item in _context.Submissions.Where(x => x.StudentID == currentStudent.StudentID).AsQueryable())
            {
                SubmissionModelForStudent model = new SubmissionModelForStudent()
                {
                    AssignmentID = item.AssignmentID,
                    SubmissionDate = item.SubmissionDate,
                    Grade = item.Grade
                };
                lstres.Add(model);
            }
            var res = PageResult<SubmissionModelForStudent>.ToPageResult(pagination, lstres);
            pagination.TotalCount = lstres.Count();
            return new PageResult<SubmissionModelForStudent>(pagination, res);
        }

        public PageResult<Submission> GetAll(Pagination pagination)
        {
            var res = PageResult<Submission>.ToPageResult(pagination, _context.Submissions.AsQueryable());
            pagination.TotalCount = _context.Submissions.AsQueryable().Count();
            return new PageResult<Submission>(pagination, res);
        }

        public PageResult<Submission> GetByAssignmentId(Pagination pagination, int id)
        {
            var res = PageResult<Submission>.ToPageResult(pagination, _context.Submissions.Where(x => x.AssignmentID == id).AsQueryable());
            pagination.TotalCount = _context.Submissions.Where(x => x.AssignmentID == id).AsQueryable().Count();
            return new PageResult<Submission>(pagination, res);
        }

        public PageResult<Submission> GetByDate(Pagination pagination, DateTime date)
        {
            var res = PageResult<Submission>.ToPageResult(pagination, _context.Submissions.Where(x => x.SubmissionDate.Date == date.Date).AsQueryable());
            pagination.TotalCount = _context.Submissions.Where(x => x.SubmissionDate.Date == date.Date).AsQueryable().Count();
            return new PageResult<Submission>(pagination, res);
        }

        public PageResult<Submission> GetByGrade(Pagination pagination, float grade)
        {
            var res = PageResult<Submission>.ToPageResult(pagination, _context.Submissions.Where(x => x.Grade == grade).AsQueryable());
            pagination.TotalCount = _context.Submissions.Where(x => x.Grade == grade).AsQueryable().Count();
            return new PageResult<Submission>(pagination, res);
        }

        public Submission GetById(int id)
        {
            var currentSubmission = _context.Submissions.FirstOrDefault(x => x.SubmissionID == id);
            if (currentSubmission != null) return currentSubmission;
            return null;
        }

        public PageResult<Submission> GetStudentId(Pagination pagination, int id)
        {
            var res = PageResult<Submission>.ToPageResult(pagination, _context.Submissions.Where(x => x.StudentID == id).AsQueryable());
            pagination.TotalCount = _context.Submissions.Where(x => x.StudentID == id).AsQueryable().Count();
            return new PageResult<Submission>(pagination, res);
        }

        public ErrorType Update(int id, SubmissionModel submissionModel)
        {
            var currentSubmission = _context.Submissions.FirstOrDefault(x => x.SubmissionID == id);
            if (currentSubmission != null)
            {
                bool check = _context.Assignments.Any(x => x.AssignmentID == submissionModel.AssignmentID) && _context.Students.Any(x => x.StudentID == submissionModel.StudentID);
                if (check)
                {
                    var currentAssignment = _context.Assignments.FirstOrDefault(x => x.AssignmentID == submissionModel.AssignmentID);
                    var lstEnroll = _context.Enrollments.Where(x => x.StudentID == submissionModel.StudentID).ToList();
                    bool checkCourse = false;
                    foreach (var enroll in lstEnroll)
                    {
                        if (enroll.CourseID == currentAssignment.CourseID)
                        {
                            checkCourse = true;
                            break;
                        }
                    }
                    if (checkCourse)
                    {

                        currentSubmission.AssignmentID = submissionModel.AssignmentID;
                        currentSubmission.StudentID = submissionModel.StudentID;
                        currentSubmission.SubmissionDate = submissionModel.SubmissionDate;
                        currentSubmission.Grade = submissionModel.Grade;
                        currentSubmission.updateAt = DateTime.Now;
                        _context.Submissions.Update(currentSubmission);
                        _context.SaveChanges();
                        return ErrorType.Succeed;
                    }
                }
                return ErrorType.NotExist;
            }
            return ErrorType.NotExist;
        }
        public ErrorType CreateRandomSubmission()
        {
            var lstStudent = _context.Students.ToList();
            foreach (var student in lstStudent)
            {
                var lstEnroll = _context.Enrollments.Where(x => x.StudentID == student.StudentID).ToList();
                foreach (var enroll in lstEnroll)
                {
                    var lstAssignment = _context.Assignments.Where(x => x.CourseID == enroll.CourseID).ToList();
                    foreach (var assignment in lstAssignment)
                    {
                        Random random = new Random();
                        _context.Submissions.Add(new Submission
                        {
                            AssignmentID = assignment.AssignmentID,
                            StudentID = student.StudentID,
                            SubmissionDate = DateTime.Now,
                            Grade = random.Next(0, 11),
                            createAt = DateTime.Now,
                            updateAt = DateTime.Now
                        });
                        _context.SaveChanges();
                    }
                }
            }
            return ErrorType.Succeed;
        }

        public IEnumerable<WarningStudentModel> GetWarningStudents()
        {
            List<WarningStudentModel> res = new List<WarningStudentModel>();
            var lstS = _context.Submissions.ToList();
            foreach(var submission in lstS)
            {
                if (submission.ExamTimes == 2)
                {
                    var currentA = submission.AssignmentID;
                    var currentStd = submission.StudentID;
                    bool check = _context.Submissions.Any(x => x.AssignmentID == currentA && x.StudentID == currentStd && x.ExamTimes == 3);
                    if (!check)
                    {
                        var assignment = _context.Assignments.FirstOrDefault(x => x.AssignmentID == currentA);
                        res.Add(new WarningStudentModel()
                        {
                            AssignmentID = currentA,
                            StudentID = currentStd,
                            MinGrade = assignment.MinGrade,
                            ExamTimes = 2,
                            Grade = submission.Grade
                        });
                    }
                }
            }
            return res;
        }
    }
}
