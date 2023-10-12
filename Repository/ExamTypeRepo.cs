using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class ExamTypeRepo : IExamTypeRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public ExamTypeRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(ExamTypeModel examTypeModel)
        {
            ExamType examType = new ExamType()
            {
                ExamTypeName = examTypeModel.ExamTypeName,
                createAt = DateTime.Now,
                updateAt = DateTime.Now
            };
            _context.ExamTypes.Add(examType);
            _context.SaveChanges();
            return ErrorType.Succeed;
        }

        public ErrorType Delete(int id)
        {
            var currentExamType = _context.ExamTypes.FirstOrDefault(x => x.ExamTypeID == id);
            if (currentExamType != null)
            {
                _context.ExamTypes.Remove(currentExamType);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<ExamType> GetAll(Pagination pagination)
        {
            var res = PageResult<ExamType>.ToPageResult(pagination, _context.ExamTypes.AsQueryable());
            pagination.TotalCount = _context.ExamTypes.AsQueryable().Count();
            return new PageResult<ExamType>(pagination, res);
        }

        public ExamType GetById(int id)
        {
            var cuurentExamType = _context.ExamTypes.FirstOrDefault(x => x.ExamTypeID == id);
            if (cuurentExamType != null) return cuurentExamType;
            return null;
        }

        public ErrorType Update(int id, ExamTypeModel examTypeModel)
        {
            var currentExamType = _context.ExamTypes.FirstOrDefault(x => x.ExamTypeID == id);
            if (currentExamType != null)
            {
                currentExamType.ExamTypeName = examTypeModel.ExamTypeName;
                currentExamType.updateAt = DateTime.Now;
                _context.ExamTypes.Update(currentExamType);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }
    }
}
