using Microsoft.EntityFrameworkCore;
using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class EnrollmentRepo : IEnrollmentRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        private readonly ITutorAssignmentRepo _tutorAssignmentRepo;
        private readonly IFeeRepo _feeRepo;
        public EnrollmentRepo()
        {
            _context = new TrungTamLuaDaoContext();
            _tutorAssignmentRepo = new TutorAssignmentRepo();
            _feeRepo = new FeeRepo();
        }
        public ErrorType Add(EnrollmentModel enrollmentModel)
        {
            bool check = _context.Students.Any(x => x.StudentID == enrollmentModel.StudentID) && _context.Courses.Any(x => x.CourseID == enrollmentModel.CourseID);
            if (check)
            {
                var lstC = _context.TutorAssignments.Where(x => x.CourseID == enrollmentModel.CourseID).OrderBy(x => x.NumberOfStudent).ToList();
                Enrollment enrollment = new Enrollment()
                {
                    StudentID = enrollmentModel.StudentID,
                    CourseID = enrollmentModel.CourseID,
                    EnrollmentDate = enrollmentModel.EnrollmentDate,
                    StatusTypeID = 1,
                    TutorID = lstC[0].TutorID,
                    createAt = DateTime.Now,
                    updateAt = DateTime.Now
                };
                _context.Enrollments.Add(enrollment);
                _context.SaveChanges();
                _tutorAssignmentRepo.UpdateNumberOfStudent(lstC[0].TutorAssignmentID, 1);
                var currentCourse = _context.Courses.FirstOrDefault(x => x.CourseID == enrollmentModel.CourseID);
                FeeModel model = new FeeModel()
                {
                    StudenID = enrollmentModel.StudentID,
                    CourseID = enrollment.CourseID,
                    Cost = currentCourse.Cost
                };
                _feeRepo.Add(model);
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public ErrorType ChangeStatus(int id, int statusId)
        {
            var currentS = _context.StatusTypes.FirstOrDefault(x => x.StatusTypeID == statusId);
            var currentE = _context.Enrollments.FirstOrDefault(x => x.EnrollmentID == id);
            var currentTA = _context.TutorAssignments.FirstOrDefault(x => x.CourseID == currentE.CourseID && x.TutorID == currentE.TutorID);
            if (currentE != null && currentE.StatusTypeID != currentS.StatusTypeID && currentS != null)
            {
                if (currentS.StatusTypeID != 4)
                {
                    currentE.StatusTypeID = currentS.StatusTypeID;
                    _context.Enrollments.Update(currentE);
                    _context.SaveChanges();
                    if (currentS.StatusTypeID == 1) _tutorAssignmentRepo.UpdateNumberOfStudent(currentTA.TutorAssignmentID, 1);
                    else _tutorAssignmentRepo.UpdateNumberOfStudent(currentTA.TutorAssignmentID, -1);
                    return ErrorType.Succeed;
                }
                else
                {
                    var lstFee = _context.Fees.Where(x => x.StudentID == currentE.StudentID && x.CourseID == currentE.CourseID).ToList();
                    bool check = true;
                    foreach (var item in lstFee)
                    {
                        if (item.Status == "Not Yet")
                        {
                            check = false;
                            break;
                        }
                    }
                    if (check == true)
                    {
                        currentE.StatusTypeID = currentS.StatusTypeID;
                        _context.Enrollments.Update(currentE);
                        _context.SaveChanges();
                        _tutorAssignmentRepo.UpdateNumberOfStudent(currentTA.TutorAssignmentID, -1);
                        return ErrorType.Succeed;                                                      
                    }
                    return ErrorType.FeeNotYet;
                }
            }
            if (currentE.StatusTypeID == currentS.StatusTypeID) return ErrorType.Fail;
            return ErrorType.NotExist;
        }

        public ErrorType Delete(int id)
        {            
            var currentEnroll = _context.Enrollments.FirstOrDefault(x => x.EnrollmentID == id);
            if (currentEnroll != null)
            {
                using (var trans = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var currentTA = _context.TutorAssignments.FirstOrDefault(x => x.CourseID == currentEnroll.CourseID && x.TutorID == currentEnroll.TutorID);
                        if (currentEnroll.StatusTypeID == 0) _tutorAssignmentRepo.UpdateNumberOfStudent(currentTA.TutorAssignmentID, -1);
                        var currentFee = _context.Fees.FirstOrDefault(x => x.CourseID == currentEnroll.CourseID && x.StudentID == currentEnroll.StudentID);
                        _feeRepo.Remove(currentFee.FeeID);
                        _context.Enrollments.Remove(currentEnroll);
                        _context.SaveChanges();
                        trans.Commit();
                        return ErrorType.Succeed;                        
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                    }
                }                
            }
            return ErrorType.NotExist;
        }

        public PageResult<Enrollment> GetAll(Pagination pagination)
        {
            var res = PageResult<Enrollment>.ToPageResult(pagination, _context.Enrollments.AsQueryable());
            pagination.TotalCount = _context.Enrollments.AsQueryable().Count();
            return new PageResult<Enrollment>(pagination, res);
        }

        public PageResult<Enrollment> GetByCourseId(Pagination pagination, int id)
        {
            var res = PageResult<Enrollment>.ToPageResult(pagination, _context.Enrollments.Where(x => x.CourseID == id).AsQueryable());
            pagination.TotalCount = _context.Enrollments.Where(x => x.CourseID == id).AsQueryable().Count();
            return new PageResult<Enrollment>(pagination, res);
        }

        public PageResult<Enrollment> GetByDate(Pagination pagination, DateTime date)
        {
            var res = PageResult<Enrollment>.ToPageResult(pagination, _context.Enrollments.
                Where(x => x.EnrollmentDate.Date == date.Date).
                AsQueryable());
            pagination.TotalCount = _context.Enrollments.
                Where(x => x.EnrollmentDate.Date == date.Date).
                AsQueryable().Count();
            return new PageResult<Enrollment>(pagination, res);
        }

        public Enrollment GetById(int id)
        {
            var currentEnroll = _context.Enrollments.FirstOrDefault(x => x.EnrollmentID == id);
            if (currentEnroll != null) return currentEnroll;
            return null;
        }

        public PageResult<Enrollment> GetByStudentId(Pagination pagination, int id)
        {
            var res = PageResult<Enrollment>.ToPageResult(pagination, _context.Enrollments.Where(x => x.StudentID == id).AsQueryable());
            pagination.TotalCount = _context.Enrollments.Where(x => x.StudentID == id).AsQueryable().Count();
            return new PageResult<Enrollment>(pagination, res);
        }

        public IEnumerable<CoursePercentModel> GetCoursePercents()
        {
            List<CoursePercentModel> res = new List<CoursePercentModel>();
            var lstE = _context.Enrollments.ToList();
            var total = lstE.Count();
            var lstC = _context.Courses.ToList();
            foreach(var course in lstC)
            {
                int count = 0;
                foreach(var enroll in lstE)
                {
                    if (course.CourseID == enroll.CourseID) 
                    {
                        count++; 
                    }
                }
                res.Add(new CoursePercentModel()
                {
                    CourseName = course.CourseName,
                    Percentage = (count * 100.0) / (total * 1.0)
                });
            }
            return res;
        }

        public IEnumerable<EnrollStatusPercentModel> GetEnrollStatusPercents()
        {
            List<EnrollStatusPercentModel> res = new List<EnrollStatusPercentModel>();
            var lstE = _context.Enrollments.ToList();
            var total = lstE.Count();
            var lstS = _context.StatusTypes.ToList();
            foreach(var status in lstS)
            {
                int count = 0;
                foreach(var enroll in lstE)
                {
                    if (status.StatusTypeID == enroll.StatusTypeID)
                    {
                        count++;
                    }
                }
                res.Add(new EnrollStatusPercentModel()
                {
                    StatusName = status.StatusName,
                    Percent = (count * 100.0) / (total * 1.0)
                });
            }
            return res;
        }

        public ErrorType Update(int id, EnrollmentModel enrollmentModel)
        {
            var currentEnroll = _context.Enrollments.FirstOrDefault(x => x.EnrollmentID == id);
            if (currentEnroll != null)
            {
                bool check = _context.Students.Any(x => x.StudentID == enrollmentModel.StudentID) && _context.Courses.Any(x => x.CourseID == enrollmentModel.CourseID);
                if (check)
                {
                    if (currentEnroll.StudentID != enrollmentModel.StudentID || currentEnroll.CourseID != enrollmentModel.CourseID)
                    {
                        var currentTA = _context.TutorAssignments.FirstOrDefault(x => x.CourseID == currentEnroll.CourseID && x.TutorID == currentEnroll.TutorID);
                        _tutorAssignmentRepo.UpdateNumberOfStudent(currentTA.TutorAssignmentID, -1);
                        var currentFee = _context.Fees.FirstOrDefault(x => x.CourseID == currentEnroll.CourseID && x.StudentID == currentEnroll.StudentID);
                        _feeRepo.Remove(currentFee.FeeID);
                        currentEnroll.StudentID = enrollmentModel.StudentID;
                        currentEnroll.CourseID = enrollmentModel.CourseID;
                        currentEnroll.EnrollmentDate = enrollmentModel.EnrollmentDate;
                        currentEnroll.updateAt = DateTime.Now;
                        var newCourse = _context.Courses.FirstOrDefault(x => x.CourseID == enrollmentModel.CourseID);
                        _feeRepo.Add(new FeeModel()
                        {
                            StudenID = enrollmentModel.StudentID,
                            CourseID = enrollmentModel.CourseID,
                            Cost = newCourse.Cost
                        });
                        var lstC = _context.TutorAssignments.Where(x => x.CourseID == enrollmentModel.CourseID).OrderBy(x => x.NumberOfStudent).ToList();
                        _tutorAssignmentRepo.UpdateNumberOfStudent(lstC[0].TutorAssignmentID, 1);
                        _context.Enrollments.Update(currentEnroll);
                        _context.SaveChanges();
                        return ErrorType.Succeed;                      
                    }
                    return ErrorType.Fail;
                }
                return ErrorType.NotExist;
            }
            return ErrorType.NotExist;
        }
    }
}
