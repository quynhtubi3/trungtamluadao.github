namespace TrungTamLuaDao.Models
{
    public class SignInResponse
    {
        public SignInResponse()
        {
            this.Token = string.Empty;
            this.responseMsg = string.Empty;
        }

        public string Token { get; set; }
        public string responseMsg { get; set; }

    }
}
