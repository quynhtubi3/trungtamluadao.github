using Microsoft.EntityFrameworkCore;
using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class FeeRepo : IFeeRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        private readonly IStudentRepo _studentRepo;
        private readonly IPaymentHistoryRepo _paymentHistoryRepo;
        public FeeRepo()
        {
            _context = new TrungTamLuaDaoContext();
            _studentRepo = new StudentRepo();
            _paymentHistoryRepo = new PaymentHistoryRepo();
        }
        public ErrorType Add(FeeModel feeModel)
        {
            if (_context.Students.Any(x => x.StudentID == feeModel.StudenID) && _context.Courses.Any(x => x.CourseID == feeModel.CourseID))
            {
                Fee fee = new Fee()
                {
                    StudentID = feeModel.StudenID,
                    CourseID = feeModel.CourseID,
                    Cost = feeModel.Cost,
                    Status = "Not Yet",
                    createAt = DateTime.Now,
                    updateAt = DateTime.Now
                };
                _context.Fees.Add(fee);
                _context.SaveChanges();
                return ErrorType.Succeed;                                      
            }
            return ErrorType.NotExist;
        }

        public void ChangeStatus(int id)
        {
            var currentFee = _context.Fees.FirstOrDefault(x => x.FeeID == id);
            if (currentFee != null)
            {
                if (currentFee.Status == "Done") currentFee.Status = "Not Yet";
                if (currentFee.Status == "Not Yet") currentFee.Status = "Done";
                _context.Fees.Update(currentFee);
                _context.SaveChanges();             
            }
        }

        public Fee4Student forStudent(string username, Pagination pagination)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.userName == username);
            var currentStudent = _context.Students.FirstOrDefault(x => x.accountID == currentAccount.accountID);
            if (currentStudent != null)
            {
                var res = PageResult<Fee>.ToPageResult(pagination, _context.Fees.Where(x => x.StudentID == currentStudent.StudentID).AsQueryable());
                pagination.TotalCount = _context.Fees.Where(x => x.StudentID == currentStudent.StudentID).AsQueryable().Count();
                var res2 = new PageResult<Fee>(pagination, res);
                return new Fee4Student()
                {
                    TotalFee = Fee4Student.CalFee(res2),
                    Result = res2
                };
            }
            return null;
        }

        public PageResult<Fee> GetAll(Pagination pagination)
        {
            var res = PageResult<Fee>.ToPageResult(pagination, _context.Fees.AsQueryable());
            pagination.TotalCount = _context.Fees.AsQueryable().Count();
            return new PageResult<Fee>(pagination, res);
        }

        public IEnumerable<StudentNotPaidModel> GetStudentNotPaid()
        {
            List<StudentNotPaidModel> res = new List<StudentNotPaidModel>();
            var lstStd = _context.Students.ToList();
            var lstF = _context.Fees.OrderBy(x => x.StudentID).ToList();
            int i = 0;
            List<Fee> feeList = new List<Fee>() { lstF[0] };
            if (lstF.Count() < 2)
            {
                while (i < lstF.Count() - 1)
                {
                    if (lstF[i + 1].StudentID == lstF[i].StudentID)
                    {
                        feeList.Add(lstF[i + 1]);
                        i++;
                    }
                    else
                    {
                        res.Add(new StudentNotPaidModel()
                        {
                            Fees = feeList,
                            StudentID = lstF[i].StudentID
                        });
                        i++;
                        feeList = new List<Fee> { lstF[i] };
                    }
                }
            }
            else
            {
                res.Add(new StudentNotPaidModel()
                {
                    Fees = feeList,
                    StudentID = lstF[0].StudentID
                });
            }
            return res;
        }

        public ErrorType payFee(string username, int id)
        {
            var currentFee = _context.Fees.FirstOrDefault(x => x.FeeID == id);
            var currentAccount = _context.accounts.FirstOrDefault(x => x.userName == username);
            var currentStudent = _context.Students.FirstOrDefault(x => x.accountID == currentAccount.accountID);
            if (currentFee != null)
            {
                if (currentStudent.TotalMoney >= currentFee.Cost)
                {
                    ChangeStatus(id);
                    _studentRepo.UpdateTotalMoney(currentStudent.StudentID, currentFee.Cost, -1);
                    _paymentHistoryRepo.Add(new PaymentHistoryModel()
                    {
                        StudentID = currentStudent.StudentID,
                        PaymentTypeID = 2,
                        PaymentName = "Pay for course " + currentFee.CourseID.ToString() + ".",
                        Amount = currentFee.Cost
                    });
                    return ErrorType.Succeed;                                               
                }
                return ErrorType.NotEnoughMoney;
            }
            return ErrorType.NotExist;
        }

        public ErrorType Remove(int id)
        {
            var currentFee = _context.Fees.FirstOrDefault(x => x.FeeID == id);
            if (currentFee != null)
            {
                _context.Fees.Remove(currentFee);
                _context.SaveChanges();
                return ErrorType.Succeed;                                       
            }
            return ErrorType.NotExist;
        }
    }
}
