using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;
using TrungTamLuaDao.Repository;

namespace TrungTamLuaDao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialTypeController : ControllerBase
    {
        private readonly IMaterialTypeRepo _materialTypeRepo;
        public MaterialTypeController()
        {
            _materialTypeRepo = new MaterialTypeRepo();
        }
        [HttpGet("{id}"), Authorize(Roles = "Admin, Tutor")]
        public ActionResult GetById(int id)
        {
            var res = _materialTypeRepo.GetById(id);
            if (res != null) return Ok(res);
            return NotFound("Not exist");
        }
        [HttpGet, Authorize(Roles = "Admin, Tutor")]
        public IActionResult GetAll(Pagination pagination)
        {
            var res = _materialTypeRepo.GetAll(pagination);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpPost, Authorize(Roles = "Admin, Tutor")]
        public IActionResult Add(MaterialTypeModel model)
        {
            var res = _materialTypeRepo.Add(model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return BadRequest("Failed!");
        }
        [HttpDelete("{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult Delete(int id)
        {
            var res = _materialTypeRepo.Delete(id);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
        [HttpPut("{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult Update(int id, MaterialTypeModel model)
        {
            var res = _materialTypeRepo.Update(id, model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
    }
}
