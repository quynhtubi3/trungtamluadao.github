namespace TrungTamLuaDao.Models
{
    public class SignInResponse
    {
        public SignInResponse()
        {
            this.Token = string.Empty;
            this.responseMsg = string.Empty;
            this.decentralization = string.Empty;
            this.userName = string.Empty;
            this.password = string.Empty;
        }

        public string Token { get; set; }
        public string responseMsg { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string decentralization { get; set; }
    }
}
