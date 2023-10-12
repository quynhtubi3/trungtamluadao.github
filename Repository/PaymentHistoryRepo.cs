using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class PaymentHistoryRepo : IPaymentHistoryRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public PaymentHistoryRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(PaymentHistoryModel model)
        {
            PaymentHistory paymentHistory = new PaymentHistory()
            {
                Amount = model.Amount,
                createAt = DateTime.Now,
                PaymentName = model.PaymentName,
                PaymentTypeID = model.PaymentTypeID,
                StudentID = model.StudentID,
                updateAt = DateTime.Now
            };
            _context.PaymentHistorys.Add(paymentHistory);
            _context.SaveChanges();
            return ErrorType.Succeed;
        }

        public PageResult<PaymentHistory> ForStudent(Pagination pagination, string username)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.userName ==  username);
            var currentStudent = _context.Students.FirstOrDefault(x => x.accountID == currentAccount.accountID);
            return GetByStudentID(pagination, currentStudent.StudentID);
        }

        public PageResult<PaymentHistory> GetAll(Pagination pagination)
        {
            var res = PageResult<PaymentHistory>.ToPageResult(pagination, _context.PaymentHistorys.AsQueryable());
            pagination.TotalCount = _context.PaymentHistorys.AsQueryable().Count();
            return new PageResult<PaymentHistory>(pagination, res);
        }

        public PaymentHistory GetByID(int id)
        {
            var current = _context.PaymentHistorys.FirstOrDefault(x => x.PaymentHistoryID == id);
            if (current != null) return current;
            return null;
        }

        public PageResult<PaymentHistory> GetByStudentID(Pagination pagination, int id)
        {
            var res = PageResult<PaymentHistory>.ToPageResult(pagination, _context.PaymentHistorys.Where(x => x.StudentID == id).AsQueryable());
            pagination.TotalCount = _context.PaymentHistorys.Where(x => x.StudentID == id).AsQueryable().Count();
            return new PageResult<PaymentHistory>(pagination, res);
        }

        public int GetRevenue()
        {
            var lstP = _context.PaymentHistorys.Where(x => x.PaymentTypeID == 2).ToList();
            int revenue = 0;
            foreach (var payment in lstP)
            {
                revenue += payment.Amount;
            }
            return revenue;
        }

        public ErrorType Remove(int id)
        {
            var current = _context.PaymentHistorys.FirstOrDefault(x => x.PaymentHistoryID == id);
            if (current != null)
            {
                _context.PaymentHistorys.Remove(current);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }
    }
}
