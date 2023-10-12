using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TrungTamLuaDao.Repository
{
    public class StatusTypeRepo : IStatusTypeRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public StatusTypeRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(StatusTypeModel tutorModel)
        {
            _context.StatusTypes.Add(new StatusType()
            {
                StatusName = tutorModel.StatusName,
                createAt = DateTime.Now,
                updateAt = DateTime.Now
            });
            _context.SaveChanges();
            return ErrorType.Succeed;
        }

        public ErrorType Delete(int id)
        {
            var currentST = _context.StatusTypes.FirstOrDefault(x => x.StatusTypeID == id);
            if (currentST != null)
            {
                _context.StatusTypes.Remove(currentST);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<StatusType> GetAll(Pagination pagination)
        {
            var res = PageResult<StatusType>.ToPageResult(pagination, _context.StatusTypes.AsQueryable());
            pagination.TotalCount = _context.StatusTypes.AsQueryable().Count();
            return new PageResult<StatusType>(pagination, res);
        }

        public StatusType GetById(int id)
        {
            var currentST = _context.StatusTypes.FirstOrDefault(x => x.StatusTypeID == id);
            if (currentST != null) return currentST;
            return null;
        }

        public ErrorType Update(int id, StatusTypeModel tutorModel)
        {
            var currentST = _context.StatusTypes.FirstOrDefault(x => x.StatusTypeID == id);
            if (currentST != null)
            {
                currentST.StatusName = tutorModel.StatusName;
                currentST.updateAt = DateTime.Now;
                _context.StatusTypes.Update(currentST);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }
    }
}
