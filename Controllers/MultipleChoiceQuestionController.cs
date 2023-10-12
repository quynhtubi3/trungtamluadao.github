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
    public class MultipleChoiceQuestionController : ControllerBase
    {
        private readonly IMultipleChoiceQuestionRepo _multipleChoiceQuestionRepo;
        public MultipleChoiceQuestionController()
        {
            _multipleChoiceQuestionRepo = new MultipleChoiceQuestionRepo();
        }
        [HttpGet("{id}"), Authorize(Roles = "Admin, Tutor")]
        public ActionResult GetById(int id)
        {
            var res = _multipleChoiceQuestionRepo.GetById(id);
            if (res != null) return Ok(res);
            return NotFound("Not exist");
        }
        [HttpGet, Authorize(Roles = "Admin, Tutor")]
        public IActionResult GetAll(Pagination pagination)
        {
            var res = _multipleChoiceQuestionRepo.GetAll(pagination);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpPost, Authorize(Roles = "Admin, Tutor")]
        public IActionResult Add(MultipleChoiceQuestionModel model)
        {
            var res = _multipleChoiceQuestionRepo.Add(model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return BadRequest("Failed!");
        }
        [HttpDelete("{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult Delete(int id)
        {
            var res = _multipleChoiceQuestionRepo.Delete(id);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
        [HttpPut("{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult Update(int id, MultipleChoiceQuestionModel model)
        {
            var res = _multipleChoiceQuestionRepo.Update(id, model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
        [HttpGet("asg/{id}"), Authorize(Roles = "Admin, Tutor")]
        public IActionResult GetByAssignmentId(Pagination pagination, int id)
        {
            var res = _multipleChoiceQuestionRepo.GetByAssignmentId(pagination, id);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
    }
}
