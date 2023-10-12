using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class CourseRepo : ICourseRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public CourseRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }

        public ErrorType Add(CourseModel courseModel)
        {
            Course course = new Course()
            {
                CourseName = courseModel.CourseName,
                CourseDescription = courseModel.CourseDescription,
                Cost = courseModel.Cost,
                CourseStartDate = courseModel.CourseStartDate,
                CourseEndDate = courseModel.CourseEndDate,
                createAt = DateTime.Now,
                updateAt = DateTime.Now,
            };
            _context.Courses.Add(course);
            _context.SaveChanges();
            return ErrorType.Succeed;
        }

        public ErrorType Delete(int id)
        {
            var currentCourse = _context.Courses.FirstOrDefault(x => x.CourseID == id); 
            if (currentCourse != null)
            {
                _context.Courses.Remove(currentCourse);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<Course> GetAll(Pagination pagination)
        {
            var res = PageResult<Course>.ToPageResult(pagination, _context.Courses.AsQueryable());
            pagination.TotalCount = _context.Courses.AsQueryable().Count();
            return new PageResult<Course>(pagination, res);
        }

        public Course GetById(int id)
        {
            var currentCourse = _context.Courses.FirstOrDefault(x => x.CourseID == id);
            if (currentCourse != null) return currentCourse;
            return null;
        }

        public ErrorType Update(int id, CourseModel courseModel)
        {
            var currentCourse = _context.Courses.FirstOrDefault(x => x.CourseID == id);
            if (currentCourse != null)
            {
                currentCourse.CourseName = courseModel.CourseName;
                currentCourse.CourseDescription = courseModel.CourseDescription;
                currentCourse.Cost = courseModel.Cost;
                currentCourse.CourseStartDate = courseModel.CourseStartDate;
                currentCourse.CourseEndDate = courseModel.CourseEndDate;
                currentCourse.updateAt = DateTime.Now;
                _context.Courses.Update(currentCourse);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }
    }
}
