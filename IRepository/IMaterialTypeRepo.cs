using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IMaterialTypeRepo
    {
        PageResult<MaterialType> GetAll(Pagination pagination);
        MaterialType GetById(int id);
        ErrorType Add(MaterialTypeModel materialTypeModel);
        ErrorType Update(int id, MaterialTypeModel materialTypeModel);
        ErrorType Delete(int id);
    }
}
