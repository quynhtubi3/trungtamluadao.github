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
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialRepo _materialRepo;
        public MaterialController()
        {
            _materialRepo = new MaterialRepo();
        }
        [HttpGet("{id}"), Authorize(Roles = "Admin, Tutor")]
        public ActionResult GetById(int id)
        {
            var res = _materialRepo.GetById(id);
            if (res != null) return Ok(res);
            return NotFound("Not exist");
        }
        [HttpGet, Authorize(Roles = "Admin, Tutor")]
        public IActionResult GetAll(Pagination pagination)
        {
            var res = _materialRepo.GetAll(pagination);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpPost, Authorize(Roles = "Admin, Tutor")]
        public IActionResult Add(MaterialModel model)
        {
            var res = _materialRepo.Add(model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return BadRequest("Failed!");
        }
        [HttpDelete("{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult Delete(int id)
        {
            var res = _materialRepo.Delete(id);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
        [HttpPut("{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult Update(int id, MaterialModel model)
        {
            var res = _materialRepo.Update(id, model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
        [HttpGet("kh/{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult GetByCourseId(Pagination pagination, int id)
        {
            var res = _materialRepo.GetByCourseId(pagination, id);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpGet("forStudent"), Authorize(Roles = "Student")]
        public IActionResult GetByStudent(Pagination pagination)
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "username").Value;
            var res = _materialRepo.GetByStudent(pagination, userName);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpGet("type/{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult GetByType(Pagination pagination, int id)
        {
            var res = _materialRepo.GetByMaterialType(pagination, id);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
    }
}
