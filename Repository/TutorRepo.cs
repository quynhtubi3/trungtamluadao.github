using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class TutorRepo : ITutorRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public TutorRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(TutorModel tutorModel)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.accountID == tutorModel.accountID);
            if (currentAccount != null)
            {
                bool checkDec = ((_context.Decentralizations.FirstOrDefault(x => x.DecentralizationID == currentAccount.DecentralizationId).AuthorityName) == ("Tutor"));
                if (checkDec)
                {
                    Tutor tutor = new()
                    {
                        accountID = tutorModel.accountID,
                        FirstName = tutorModel.FirstName,
                        LastName = tutorModel.LastName,
                        ContactNumber = tutorModel.ContactNumber,
                        Email = tutorModel.Email,
                        createAt = DateTime.Now,
                        updateAt = DateTime.Now,
                        communeID = tutorModel.communeID,
                        districtID = tutorModel.districtID,
                        provinceID = tutorModel.provinceID
                    };
                    _context.Tutors.Add(tutor);
                    _context.SaveChanges();
                    return ErrorType.Succeed;
                }
                return ErrorType.NotExist;
            }
            return ErrorType.NotExist;
        }

        public ErrorType Delete(int id)
        {
            var currentT = _context.Tutors.FirstOrDefault(x => x.TutorID == id);
            if (currentT != null)
            {
                _context.Tutors.Remove(currentT); 
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<Tutor> GetAll(Pagination pagination)
        {
            var res = PageResult<Tutor>.ToPageResult(pagination, _context.Tutors.AsQueryable());
            pagination.TotalCount = _context.Tutors.AsQueryable().Count();
            return new PageResult<Tutor>(pagination, res);
        }

        public Tutor GetById(int id)
        {
            var currentT = _context.Tutors.FirstOrDefault(x => x.TutorID == id);
            if (currentT != null) return currentT;
            return null;
        }


        public ErrorType Update(int id, TutorModel tutorModel)
        {
            var currentT = _context.Tutors.FirstOrDefault(x => x.TutorID == id);
            if (currentT != null)
            {
                var currentAccount = _context.accounts.FirstOrDefault(x => x.accountID == tutorModel.accountID);
                if (currentAccount != null)
                {
                    bool checkDec = ((_context.Decentralizations.FirstOrDefault(x => x.DecentralizationID == currentAccount.DecentralizationId).AuthorityName) == ("Tutor"));
                    if (checkDec)
                    {
                        currentT.accountID = tutorModel.accountID;
                        currentT.FirstName = tutorModel.FirstName;
                        currentT.LastName = tutorModel.LastName;
                        currentT.ContactNumber = tutorModel.ContactNumber;
                        currentT.Email = tutorModel.Email;
                        currentT.updateAt = DateTime.Now;
                        currentT.provinceID = tutorModel.provinceID;
                        currentT.districtID = tutorModel.districtID;
                        currentT.communeID = tutorModel.communeID;
                        _context.Tutors.Update(currentT);
                        _context.SaveChanges();
                        return ErrorType.Succeed;
                    }
                    return ErrorType.NotExist;
                }
                return ErrorType.NotExist;
            }
            return ErrorType.NotExist;
        }
    }
}
