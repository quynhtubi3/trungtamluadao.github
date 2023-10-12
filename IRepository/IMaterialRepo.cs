using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.IRepository
{
    public interface IMaterialRepo
    {
        PageResult<Material> GetAll(Pagination pagination);
        Material GetById(int id);
        ErrorType Add(MaterialModel materialModel);
        ErrorType Update(int id, MaterialModel materialModel);
        ErrorType Delete(int id);
        PageResult<Material> GetByCourseId(Pagination pagination, int id);
        PageResult<Material> GetByMaterialType(Pagination pagination, int id);
        PageResult<MaterialModelForStudent> GetByStudent(Pagination pagination, string username);
    }
}
