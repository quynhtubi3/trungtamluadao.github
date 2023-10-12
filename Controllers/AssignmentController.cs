using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;
using TrungTamLuaDao.Repository;

namespace TrungTamLuaDao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentRepo _assignmentRepo;
        public AssignmentController()
        {
            _assignmentRepo = new AssignmentRepo();
        }
        [HttpGet("{id}"), Authorize(Roles = "Admin, Tutor, Student")]
        public ActionResult GetById(int id)
        {
            var res = _assignmentRepo.GetById(id);
            if (res != null) return Ok(res);
            return NotFound("Not exist");
        }
        [HttpGet, Authorize(Roles = "Admin, Tutor")]
        public IActionResult GetAll(Pagination pagination)
        {
            var res = _assignmentRepo.GetAll(pagination);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpPost, Authorize(Roles = "Admin, Tutor")]
        public IActionResult Add(AssignmentModel model)
        {
            var res = _assignmentRepo.Add(model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return BadRequest("Failed!");
        }
        [HttpDelete("{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult Delete(int id)
        {
            var res = _assignmentRepo.Delete(id);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
        [HttpGet("course/{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult GetByKh(Pagination pagination, int id)
        {
            var res = _assignmentRepo.GetByCourseId(pagination, id);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpGet("type/{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult GetByDate(Pagination pagination, int id)
        {
            var res = _assignmentRepo.GetExamTypeId(pagination, id);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpGet("forStudent"), Authorize(Roles = "Student")]
        public IActionResult GetByStudent(Pagination pagination)
        {
            var userName = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "username").Value;
            var res = _assignmentRepo.GetForStudent(pagination, userName);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpPut("{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult Update(int id, AssignmentModel model)
        {
            var res = _assignmentRepo.Update(id, model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
    }
}
