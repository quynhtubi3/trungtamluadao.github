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
    public class LectureTypeController : ControllerBase
    {
        private readonly ILectureTypeRepo _lectureTypeRepo;
        public LectureTypeController()
        {
            _lectureTypeRepo = new LectureTypeRepo();
        }
        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public ActionResult GetById(int id)
        {
            var res = _lectureTypeRepo.GetById(id);
            if (res != null) return Ok(res);
            return NotFound("Not exist");
        }
        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult GetAll(Pagination pagination)
        {
            var res = _lectureTypeRepo.GetAll(pagination);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpPost, Authorize(Roles = "Admin")]
        public IActionResult Add(LectureTypeModel model)
        {
            var res = _lectureTypeRepo.Add(model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return BadRequest("Failed!");
        }
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var res = _lectureTypeRepo.Delete(id);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public IActionResult Update(int id, LectureTypeModel model)
        {
            var res = _lectureTypeRepo.Update(id, model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
    }
}
