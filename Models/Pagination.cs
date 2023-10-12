namespace TrungTamLuaDao.Models
{
    public class Pagination
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages
        {
            get
            {
                if (PageSize == 0) return 0;
                int total = TotalCount / PageSize;
                if (TotalCount % PageSize != 0) total++;
                return total;
            }
        }
        public Pagination()
        {
            PageSize = -1;
            PageNumber = 1;
        }
    }
}
