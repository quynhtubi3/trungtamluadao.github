﻿using AuthenticationForm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrungTamLuaDao.Context;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _accountRepo;
        private readonly TrungTamLuaDaoContext _context;
        public AccountController(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
            _context = new TrungTamLuaDaoContext();
        }
        [HttpPost("signIn")]
        public IActionResult SignIn(SignInModel signIn)
        {            
            var res = _accountRepo.SignIn(signIn);
            if (res != null)
            {
                var currentAccount = _context.accounts.FirstOrDefault(x => x.userName == signIn.UserName);
                var currentDecen = _context.Decentralizations.FirstOrDefault(x => x.DecentralizationID == currentAccount.DecentralizationId);
                return Ok(new SignInResponse()
                {
                    Token = res,
                    responseMsg = "Signed In",
                    userName = currentAccount.userName,
                    password = currentAccount.password,
                    decentralization = currentDecen.AuthorityName
                });
            }
            return Unauthorized(new SignInResponse()
            {
                Token = res,
                responseMsg = "Invalid UserName/ Password"
            });
        }
        [HttpPost("signUp")]
        public IActionResult SignUp(SignUpModel signUp)
        {
            var res = _accountRepo.SignUp(signUp);
            if (res == true)
            {
                return Ok(new SignUpResponse()
                {
                    succeed = true,
                    Msg = "Signed up",                    
                });
            }
            return BadRequest(new SignUpResponse()
            {
                succeed = false,
                Msg = "Invalid UserName/ Password"
            });
        }
        [HttpPut("changePassword"), Authorize(Roles = "Student, Admin, Tutor")]
        public IActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "username").Value;
            var res = _accountRepo.ChangePassword(userName, changePasswordModel);
            if (res == true) return Ok("Password changed!");
            return BadRequest("Invalid password!");
        }
        [HttpPut("changeStatus"), Authorize(Roles = "Admin")]
        public IActionResult ChangeStatus(string userName, string status)
        {
            var res = _accountRepo.ChangeStatus(userName, status);
            if (res == ErrorType.Succeed) return Ok("Succeed");
            return BadRequest("Not exist");
        }
        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult ShowAll(Pagination pagination)
        {
            var res = _accountRepo.GetListAccount(pagination);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public IActionResult GetByDecId(Pagination pagination, int id)
        {
            var res = _accountRepo.GetByDec(pagination, id);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpPut("Ban/{id}"), Authorize(Roles = "Admin")]
        public IActionResult BanAcc(int id)
        {
            var res = _accountRepo.BanAcc(id);
            if (res == ErrorType.Succeed) return Ok("Done");
            return NotFound();
        }
        [HttpPost("ForgetPassword"), AllowAnonymous]
        public IActionResult ForgetPassword(ForgetPasswordModel model)
        {
            var res = _accountRepo.ChangePasswordAfterForgot(model.model1, model.model2);
            if (res == "None") return BadRequest();
            if (res == "False") return BadRequest("The code is incorrect or has expired");
            if (res == "Sent") return Ok(res);
            if (res == "Changed") return Ok("Updated password!");
            if (res == "Not exist") return NotFound("This email are unauthozired!");
            return BadRequest(res);
        }
        /* [HttpPost("renewToken"), Authorize(Roles = "Admin, Tutor, Student")]
        public IActionResult RenewToken()
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "username").Value;
            var res = _accountRepo.RenewToken(userName);
            return Ok(res);
        } */
    }
}
