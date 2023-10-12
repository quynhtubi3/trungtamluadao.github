using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class LectureRepo : ILectureRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public LectureRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(LectureModel lectureModel)
        {
            var check = _context.Courses.Any(x => x.CourseID == lectureModel.CourseID);
            if (check)
            {
                Lecture lecture = new Lecture()
                {
                    CourseID = lectureModel.CourseID,
                    LectureTypeID = lectureModel.LectureTypeID,
                    LectureTitle = lectureModel.LectureTitle,
                    LectureDate = lectureModel.LectureDate,
                    LectureContent = lectureModel.LectureContent,
                    createAt = DateTime.Now,
                    updateAt = DateTime.Now
                };
                _context.Lectures.Add(lecture);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public ErrorType Delete(int id)
        {
            var currentLecture = _context.Lectures.FirstOrDefault(x => x.LectureID == id);
            if (currentLecture != null)
            {
                _context.Lectures.Remove(currentLecture);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<Lecture> GetAll(Pagination pagination)
        {
            var res = PageResult<Lecture>.ToPageResult(pagination, _context.Lectures.AsQueryable());
            pagination.TotalCount = _context.Lectures.AsQueryable().Count();
            return new PageResult<Lecture>(pagination, res);
        }

        public PageResult<Lecture> GetByCourseDate(Pagination pagination, DateTime date)
        {
            var res = PageResult<Lecture>.ToPageResult(pagination, _context.Lectures
                .Where(x => x.LectureDate.Date == date.Date).AsQueryable());
            pagination.TotalCount = _context.Lectures
                .Where(x => x.LectureDate.Date == date.Date).AsQueryable().Count();
            return new PageResult<Lecture>(pagination, res);
        }

        public PageResult<Lecture> GetByCourseId(Pagination pagination, int id)
        {
            var lstL = _context.Lectures.Where(x => x.CourseID == id).AsQueryable();
            var res = PageResult<Lecture>.ToPageResult(pagination, lstL);
            pagination.TotalCount = lstL.Count();
            return new PageResult<Lecture>(pagination, res);
        }

        public Lecture GetById(int id)
        {
            var currentLecture = _context.Lectures.FirstOrDefault(x => x.LectureID == id);
            if (currentLecture != null) return currentLecture;
            return null;
        }

        public PageResult<LectureModel> GetByStudent(Pagination pagination, string username)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.userName ==  username);
            var currentStudent = _context.Students.FirstOrDefault(x => x.accountID == currentAccount.accountID);
            var lstEnroll = _context.Enrollments.Where(x => x.StudentID == currentStudent.StudentID).ToList();
            List<LectureModel> res = new List<LectureModel>();
            foreach (var enroll in lstEnroll)
            {
                foreach (var lecture in _context.Lectures.ToList())
                {
                    if (lecture.CourseID == enroll.CourseID)
                    {
                        LectureModel model = new LectureModel()
                        {
                            CourseID = lecture.CourseID,
                            LectureTypeID = lecture.LectureTypeID,
                            LectureContent = lecture.LectureContent,
                            LectureDate = lecture.LectureDate,
                            LectureTitle = lecture.LectureTitle
                        };
                        res.Add(model);
                    }
                }
            }
            pagination.TotalCount = res.Count();
            return new PageResult<LectureModel>(pagination, res);
        }

        public ErrorType Update(int id, LectureModel lectureModel)
        {
            var currentLecture = _context.Lectures.FirstOrDefault(x => x.LectureID == id);
            if (currentLecture != null)
            {
                var check = _context.Courses.Any(x => x.CourseID == lectureModel.CourseID);
                if (check)
                {
                    currentLecture.CourseID = lectureModel.CourseID;
                    currentLecture.LectureTypeID = lectureModel.LectureTypeID;
                    currentLecture.LectureTitle = lectureModel.LectureTitle;
                    currentLecture.LectureDate = lectureModel.LectureDate;
                    currentLecture.LectureContent = lectureModel.LectureContent;
                    currentLecture.updateAt = DateTime.Now;
                    _context.Lectures.Update(currentLecture);
                    _context.SaveChanges();
                    return ErrorType.Succeed;
                }
                return ErrorType.NotExist;
            }
            return ErrorType.NotExist;
        }
    }
}
