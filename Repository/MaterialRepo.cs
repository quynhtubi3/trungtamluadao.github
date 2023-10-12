using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;

namespace TrungTamLuaDao.Repository
{
    public class MaterialRepo : IMaterialRepo
    {
        private readonly TrungTamLuaDaoContext _context;
        public MaterialRepo()
        {
            _context = new TrungTamLuaDaoContext();
        }
        public ErrorType Add(MaterialModel materialModel)
        {
            bool check = (_context.Courses.Any(x => x.CourseID == materialModel.CourseID) && _context.MaterialTypes.Any(x => x.MaterialTypeID == materialModel.MaterialTypeId));
            if (check)
            {
                Material material = new()
                {
                    CourseID = materialModel.CourseID,
                    MaterialTitle = materialModel.MaterialTitle,
                    MaterialTypeId = materialModel.MaterialTypeId,
                    MaterialLink = materialModel.MaterialLink,
                    createAt = DateTime.Now,
                    updateAt = DateTime.Now,
                };
                _context.Materials.Add(material);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public ErrorType Delete(int id)
        {
            var currentMaterial = _context.Materials.FirstOrDefault(x => x.MaterialID == id);
            if (currentMaterial != null)
            {
                _context.Materials.Remove(currentMaterial);
                _context.SaveChanges();
                return ErrorType.Succeed;
            }
            return ErrorType.NotExist;
        }

        public PageResult<Material> GetAll(Pagination pagination)
        {
            var res = PageResult<Material>.ToPageResult(pagination, _context.Materials.AsQueryable());
            pagination.TotalCount = _context.Materials.AsQueryable().Count();
            return new PageResult<Material>(pagination, res);
        }

        public PageResult<Material> GetByCourseId(Pagination pagination, int id)
        {
            var res = PageResult<Material>.ToPageResult(pagination, _context.Materials.Where(x => x.CourseID == id).AsQueryable());
            pagination.TotalCount = _context.Materials.Where(x => x.CourseID == id).AsQueryable().Count();
            return new PageResult<Material>(pagination, res);
        }

        public Material GetById(int id)
        {
            var currentMaterial = _context.Materials.FirstOrDefault(x => x.MaterialID == id);
            if (currentMaterial != null) return currentMaterial;
            return null;
        }

        public PageResult<Material> GetByMaterialType(Pagination pagination, int id)
        {
            var res = PageResult<Material>.ToPageResult(pagination, _context.Materials.Where(x => x.MaterialTypeId == id).AsQueryable());
            pagination.TotalCount = _context.Materials.Where(x => x.MaterialTypeId == id).AsQueryable().Count();
            return new PageResult<Material>(pagination, res);
        }

        public PageResult<MaterialModelForStudent> GetByStudent(Pagination pagination, string username)
        {
            var currentAccount = _context.accounts.FirstOrDefault(x => x.userName == username);
            var currentStudent = _context.Students.FirstOrDefault(x => x.accountID == currentAccount.accountID);
            var lstEnroll = _context.Enrollments.Where(x => x.StudentID == currentStudent.StudentID).ToList();
            List<MaterialModelForStudent> res = new List<MaterialModelForStudent>();
            foreach (var enroll in lstEnroll)
            {
                foreach (var material in _context.Materials.ToList())
                {
                    if (material.CourseID == enroll.CourseID)
                    {
                        MaterialModelForStudent model = new MaterialModelForStudent()
                        {
                            MaterialTitle = material.MaterialTitle,
                            MaterialLink = material.MaterialLink
                        };
                        res.Add(model);
                    }
                }
            }
            pagination.TotalCount = res.Count();
            return new PageResult<MaterialModelForStudent>(pagination, res);
        }

        public ErrorType Update(int id, MaterialModel materialModel)
        {
            var currentMaterial = _context.Materials.FirstOrDefault(x => x.MaterialID == id);
            if (currentMaterial != null)
            {
                bool check = (_context.Courses.Any(x => x.CourseID == materialModel.CourseID) && _context.MaterialTypes.Any(x => x.MaterialTypeID == materialModel.MaterialTypeId));
                if (check)
                {
                    currentMaterial.CourseID = materialModel.CourseID;
                    currentMaterial.MaterialTitle = materialModel.MaterialTitle;
                    currentMaterial.MaterialTypeId = materialModel.MaterialTypeId;
                    currentMaterial.MaterialLink = materialModel.MaterialLink;
                    currentMaterial.updateAt = DateTime.Now;
                    _context.Materials.Add(currentMaterial);
                    _context.SaveChanges();
                    return ErrorType.Succeed;
                }
                return ErrorType.NotExist;
            }
            return ErrorType.NotExist;
        }
    }
}
