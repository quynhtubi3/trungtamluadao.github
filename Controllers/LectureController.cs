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
    public class LectureController : ControllerBase
    {
        private readonly ILectureRepo _lectureRepo;
        public LectureController()
        {
            _lectureRepo = new LectureRepo();
        }
        [HttpGet("{id}"), Authorize(Roles = "Admin, Tutor")]
        public ActionResult GetById(int id)
        {
            var res = _lectureRepo.GetById(id);
            if (res != null) return Ok(res);
            return NotFound("Not exist");
        }
        [HttpGet, Authorize(Roles = "Admin, Tutor")]
        public IActionResult GetAll(Pagination pagination)
        {
            var res = _lectureRepo.GetAll(pagination);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpPost, Authorize(Roles = "Admin, Tutor")]
        public IActionResult Add(LectureModel model)
        {
            var res = _lectureRepo.Add(model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return BadRequest("Failed!");
        }
        [HttpDelete("{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult Delete(int id)
        {
            var res = _lectureRepo.Delete(id);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
        [HttpPut("{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult Update(int id, LectureModel model)
        {
            var res = _lectureRepo.Update(id, model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
        [HttpGet("kh/{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult GetByKh(Pagination pagination, int id)
        {
            var res = _lectureRepo.GetByCourseId(pagination, id);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpGet("date"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult GetByDate(Pagination pagination, DateTime date)
        {
            var res = _lectureRepo.GetByCourseDate(pagination, date);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpGet("forStudent"), Authorize(Roles = "Student")]
        public IActionResult GetByStudent(Pagination pagination)
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "username").Value;
            var res = _lectureRepo.GetByStudent(pagination, userName);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }        
    }
}
