using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class LectureTypeRepo : ILectureTypeRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public LectureTypeRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(LectureTypeModel lectureTypeModel)
        {
            LectureType lectureType = new LectureType()
            {
                LectureTypeName = lectureTypeModel.LectureTypeName,
                createAt = DateTime.Now,
                updateAt = DateTime.Now
            };
            _context.LecturesTypes.Add(lectureType);
            _context.SaveChanges();
            return ErrorType.Succeed;
        }

        public ErrorType Delete(int id)
        {
            var currentLT = _context.LecturesTypes.FirstOrDefault(x => x.LectureTypeID == id);
            if (currentLT != null)
            {
                _context.LecturesTypes.Remove(currentLT);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<LectureType> GetAll(Pagination pagination)
        {
            var res = PageResult<LectureType>.ToPageResult(pagination, _context.LecturesTypes.AsQueryable());
            pagination.TotalCount = _context.LecturesTypes.AsQueryable().Count();
            return new PageResult<LectureType>(pagination, res);
        }

        public LectureType GetById(int id)
        {
            var currentLT = _context.LecturesTypes.FirstOrDefault(x => x.LectureTypeID == id);
            if (currentLT != null) return currentLT;
            return null;
        }

        public ErrorType Update(int id, LectureTypeModel lectureTypeModel)
        {
            var currentLT = _context.LecturesTypes.FirstOrDefault(x => x.LectureTypeID == id);
            if (currentLT != null)
            {
                currentLT.LectureTypeName = lectureTypeModel.LectureTypeName;
                currentLT.createAt = DateTime.Now;
                _context.LecturesTypes.Update(currentLT);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }
    }
}

