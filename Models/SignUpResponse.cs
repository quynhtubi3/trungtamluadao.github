namespace TrungTamLuaDao.Models
{
    public class SignUpResponse
    {
        public bool succeed { get; set; }
        public string? Msg { get; set; }
        public SignUpResponse() 
        {
            this.Msg = string.Empty;
            this.succeed = false;
        }
    }
}
