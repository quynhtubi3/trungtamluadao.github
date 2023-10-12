using AuthenticationForm.Models;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class AccountRepo : IAccountRepo
    {
        private readonly IConfiguration _configuration;
        private readonly TrungTamLuaDaoContext _context;

        public AccountRepo(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._context = new TrungTamLuaDaoContext();
        }

        public ErrorType BanAcc(int id)
        {
            var current = _context.accounts.FirstOrDefault(x => x.accountID == id);
            if (current != null && current.Decentralization.AuthorityName != "Admin") 
            {
                current.status = "Banned";
                _context.accounts.Update(current);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public bool ChangePassword(string userName, ChangePasswordModel changePasswordModel)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.userName == userName);
            if (VerifyPassword(changePasswordModel.Password, currentAccount.password) && changePasswordModel.NewPassword == changePasswordModel.ConfirmPassword)
            {
                currentAccount.password = HashPassword(changePasswordModel.NewPassword);
                currentAccount.updateAt = DateTime.Now;
                _context.accounts.Update(currentAccount);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ErrorType ChangeStatus(string userName, string status)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.userName == userName);
            if (currentAccount != null)
            {
                currentAccount.status = status;
                currentAccount.updateAt = DateTime.Now;
                _context.accounts.Update(currentAccount);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<account> GetByDec(Pagination pagination, int id)
        {
            var res = PageResult<account>.ToPageResult(pagination, _context.accounts.Where(x => x.DecentralizationId == id).AsQueryable());
            pagination.TotalCount = _context.accounts.Where(x => x.DecentralizationId == id).AsQueryable().Count();
            return new PageResult<account>(pagination, res);
        }

        public PageResult<account> GetListAccount(Pagination pagination)
        {
            var res = PageResult<account>.ToPageResult(pagination, _context.accounts.AsQueryable());
            pagination.TotalCount = _context.accounts.AsQueryable().Count();
            return new PageResult<account>(pagination, res);
        }

        /* public string RenewToken(string username)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.userName.ToLower() == username.ToLower());
            string currentRole = _context.Decentralizations.FirstOrDefault(x => x.DecentralizationID == currentAccount.DecentralizationId).AuthorityName.ToString();
            string token = CreateToken(username, currentRole, 10);
            currentAccount.ResetPasswordToken = token;
            currentAccount.ResetPasswordTokenExpiry = DateTime.Now.AddHours(10);
            _context.accounts.Update(currentAccount);
            _context.SaveChanges();
            return token;
        } */

        public string SignIn(SignInModel signInModel)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.userName.ToLower() == signInModel.UserName.ToLower());
            if (currentAccount != null && VerifyPassword(signInModel.Password, currentAccount.password) && currentAccount.status == "Working")
            {
                var role = _context.Decentralizations.FirstOrDefault(x => x.DecentralizationID == currentAccount.DecentralizationId).AuthorityName.ToString();
                string token = CreateToken(signInModel.UserName, role, 10);
                currentAccount.ResetPasswordToken = token;
                currentAccount.ResetPasswordTokenExpiry = DateTime.Now.AddHours(10);
                _context.accounts.Update(currentAccount);
                _context.SaveChanges();
                return token;
            }
            return null;
        }

        public bool SignUp(SignUpModel signUpModel)
        {
            if (!(_context.accounts.Any(x => x.userName == signUpModel.UserName)) && 
                signUpModel.Password == signUpModel.ConfirmPassword && 
                _context.Decentralizations.Any(x => x.DecentralizationID == signUpModel.DecentralizationID))
            {
                account _account = new()
                {
                    userName = signUpModel.UserName,
                    avatar = null,
                    password = HashPassword(signUpModel.Password),
                    status = "Working",
                    DecentralizationId = signUpModel.DecentralizationID,
                    ResetPasswordToken = string.Empty,
                    ResetPasswordTokenExpiry = null,
                    createAt = DateTime.Now,
                    updateAt = DateTime.Now
                };
                _context.accounts.Add(_account);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        private string CreateToken(string username, string decentralization, int expireTime)
        {
            var authClaims = new List<Claim>
            {
                new Claim("username", Convert.ToString(username)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, decentralization)
            };
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value));
            var token = new JwtSecurityToken
                (
                    expires: DateTime.Now.AddHours(expireTime),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            password = password + _configuration.GetSection("JwtConfig:Secret").ToString();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }
        private bool VerifyPassword(string password, string hashedPassword)
        {
            password = password + _configuration.GetSection("JwtConfig:Secret").ToString();
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
