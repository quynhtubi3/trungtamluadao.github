using Microsoft.EntityFrameworkCore;
using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        private readonly IPaymentHistoryRepo _historyRepo;
        public StudentRepo()
        {
            _context = new TrungTamLuaDaoContext();
            _historyRepo = new PaymentHistoryRepo();
        }
        public ErrorType Add(StudentModel studentModel)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.accountID == studentModel.accountId);
            if (currentAccount != null)
            {
                bool checkDec = ((_context.Decentralizations.FirstOrDefault(x => x.DecentralizationID == currentAccount.DecentralizationId).AuthorityName) == "Student");
                if (checkDec)
                {
                    Student student = new()
                    {
                        accountID = studentModel.accountId,
                        FirstName = studentModel.FirstName,
                        LastName = studentModel.LastName,
                        ContactNumber = studentModel.ContactNumber,
                        Email = studentModel.Email,
                        TotalMoney = 0,
                        createAt = DateTime.Now,
                        updateAt = DateTime.Now
                    };
                    _context.Students.Add(student);
                    _context.SaveChanges();
                    return ErrorType.Succeed;
                }
                return ErrorType.NotExist;
            }
            return ErrorType.NotExist;
        }

        public PageResult<Student> GetAll(Pagination pagination)
        {
            var res = PageResult<Student>.ToPageResult(pagination, _context.Students.AsQueryable());
            pagination.TotalCount = _context.Students.AsQueryable().Count();
            return new PageResult<Student>(pagination, res);
        }

        public Student GetById(int id)
        {
            var currentStudent = _context.Students.FirstOrDefault(x => x.accountID == id);
            if (currentStudent != null)
            {
                return currentStudent;
            }
            Student fail = null;
            return fail;
        }

        public ErrorType Remove(int id)
        {
            var currentStudent = _context.Students.FirstOrDefault(x => x.accountID == id);
            if (currentStudent != null)
            {
                _context.Students.Remove(currentStudent);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public ErrorType Update(int id, StudentModel studentModel)
        {
            var currentStudent = _context.Students.FirstOrDefault(x => x.accountID == id);
            var newAccount = _context.accounts.FirstOrDefault(x => x.accountID == studentModel.accountId);
            if (currentStudent != null && (_context.Decentralizations.FirstOrDefault(x => x.DecentralizationID == newAccount.DecentralizationId).AuthorityName) == ("Student"))
            {
                currentStudent.updateAt = DateTime.Now;
                currentStudent.accountID = studentModel.accountId;
                currentStudent.FirstName = studentModel.FirstName;
                currentStudent.LastName = studentModel.LastName;
                currentStudent.Email = studentModel.Email;
                _context.Students.Update(currentStudent);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public bool UpdateInfomation(string userName, UpdateInfo4Student model)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.userName ==  userName);
            var currentStudent = _context.Students.FirstOrDefault(x => x.accountID == currentAccount.accountID);
            if (model.FirstName != null) currentStudent.FirstName = model.FirstName;
            if (model.LastName != null) currentStudent.LastName = model.LastName;
            if (model.ContactNumber == null) model.ContactNumber = "0";
            if (model.ContactNumber != null) currentStudent.ContactNumber = model.ContactNumber;
            if (model.avatar != null) currentAccount.avatar = model.avatar;
            _context.Students.Update(currentStudent);
            _context.accounts.Update(currentAccount);
            _context.SaveChanges();
            return true;
        }

        public ErrorType UpdateTotalMoney(int id, int money, int type)
        {
            var currentStudent = _context.Students.FirstOrDefault(x => x.StudentID == id);
            if (currentStudent != null)
            {
                using (var trans = _context.Database.BeginTransaction())
                {
                    try
                    {
                        currentStudent.TotalMoney = currentStudent.TotalMoney + money * type;
                        _context.Students.Update(currentStudent);                        
                        if (type == 1) 
                        _historyRepo.Add(new PaymentHistoryModel()
                        {
                            Amount = money,
                            PaymentTypeID = 1,
                            PaymentName = "Add " + money.ToString() + " to student account.",
                            StudentID = id,
                        });
                        trans.Commit();
                        _context.SaveChanges();
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
    }
}
