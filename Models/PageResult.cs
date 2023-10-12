namespace TrungTamLuaDao.Models
{
    public class PageResult<T>
    {
        public Pagination pagination { get; set; }
        public IEnumerable<T> data { get; set; }

        public PageResult(Pagination _pagination, IEnumerable<T> _data)
        {
            pagination = _pagination;
            data = _data;
        }
        public static IEnumerable<T> ToPageResult(Pagination pagination, IEnumerable<T> data)
        {
            pagination.PageNumber = pagination.PageNumber < 1 ? 1 : pagination.PageNumber;
            data = data.Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize).AsQueryable();
            return data;
        }
    }
}
