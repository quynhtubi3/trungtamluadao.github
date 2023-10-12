using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class MaterialTypeRepo : IMaterialTypeRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public MaterialTypeRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(MaterialTypeModel materialTypeModel)
        {
            MaterialType materialType = new MaterialType()
            {
                MaterialTypeName = materialTypeModel.MaterialTypeName,
                createAt = DateTime.Now,
                updateAt = DateTime.Now,
            };
            _context.MaterialTypes.Add(materialType);
            _context.SaveChanges();
            return ErrorType.Succeed;
        }

        public ErrorType Delete(int id)
        {
            var currentMaterialType = _context.MaterialTypes.FirstOrDefault(x => x.MaterialTypeID == id);
            if (currentMaterialType != null)
            {
                _context.MaterialTypes.Remove(currentMaterialType);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<MaterialType> GetAll(Pagination pagination)
        {
            var res = PageResult<MaterialType>.ToPageResult(pagination, _context.MaterialTypes.AsQueryable());
            pagination.TotalCount = _context.MaterialTypes.AsQueryable().Count();
            return new PageResult<MaterialType>(pagination, res);
        }

        public MaterialType GetById(int id)
        {
            var currentMaterialType = _context.MaterialTypes.FirstOrDefault(x => x.MaterialTypeID == id);
            if (currentMaterialType != null) return currentMaterialType;
            return null;
        }

        public ErrorType Update(int id, MaterialTypeModel materialTypeModel)
        {
            var currentMaterialType = _context.MaterialTypes.FirstOrDefault(x => x.MaterialTypeID == id);
            if (currentMaterialType != null)
            {
                currentMaterialType.MaterialTypeName = materialTypeModel.MaterialTypeName;
                currentMaterialType.createAt = DateTime.Now;
                currentMaterialType.updateAt = DateTime.Now;
                _context.MaterialTypes.Update(currentMaterialType);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }
    }
}
