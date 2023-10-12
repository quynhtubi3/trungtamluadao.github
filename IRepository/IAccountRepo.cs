using AuthenticationForm.Models;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IAccountRepo
    {
        string SignIn(SignInModel signInModel);
        bool SignUp(SignUpModel signUpModel);
        bool ChangePassword(string userName, ChangePasswordModel changePasswordModel);
        ErrorType ChangeStatus(string userName, string status);
        PageResult<account> GetListAccount(Pagination pagination);
        PageResult<account> GetByDec(Pagination pagination, int id);
        ErrorType BanAcc(int id);
        //bool RenewToken(string username);
    }
}
