﻿using AuthenticationForm.Models;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IAccountRepo
    {
        string SignIn(SignInModel signInModel);
        bool SignUp(SignUpModel signUpModel);
        bool AddAccount(accountModel model);
        bool ChangePassword(string userName, ChangePasswordModel changePasswordModel);
        ErrorType ChangeStatus(string userName, string status);
        PageResult<account> GetListAccount(Pagination pagination);
        PageResult<account> GetByDec(Pagination pagination, int id);
        string ChangePasswordAfterForgot(ForGotPasswordScreenModel FPSModel, ChangePasswordAfterForgotModel CPModel);
        ErrorType BanAcc(int id);
        string CheckVerifyCodeForgotPassword(ForGotPasswordScreenModel model);
        //bool RenewToken(string username);
    }
}
