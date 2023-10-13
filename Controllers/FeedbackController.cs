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
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackRepo _feedbackRepo;
        public FeedbackController()
        {
            _feedbackRepo = new FeedbackRepo();
        }
        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public ActionResult GetById(int id)
        {
            var res = _feedbackRepo.GetById(id);
            if (res != null) return Ok(res);
            return NotFound("Not exist");
        }
        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult GetAll(Pagination pagination)
        {
            var res = _feedbackRepo.GetAll(pagination);
            if (res.data.Count() != 0) return Ok(res);
            return BadRequest("Null");
        }
        [HttpPost, Authorize(Roles = "Admin, Student")]
        public IActionResult Add(FeedbackModel model)
        {
            var res = _feedbackRepo.Add(model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return BadRequest("Failed!");
        }
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var res = _feedbackRepo.Delete(id);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public IActionResult Update(int id, FeedbackModel model)
        {
            var res = _feedbackRepo.Update(id, model);
            if (res == ErrorType.Succeed) return Ok("Added");
            return NotFound("Not exist!");
        }
        [HttpGet("sub/{id}"), Authorize(Roles = "Admin")]
        public ActionResult GetBySubId(Pagination pagination, int id)
        {
            var res = _feedbackRepo.GetBySubId(pagination, id);
            if (res != null) return Ok(res);
            return NotFound("Not exist");
        }
        [HttpGet("tutor/{id}"), Authorize(Roles = "Admin")]
        public ActionResult GetByStdId(Pagination pagination, int id)
        {
            var res = _feedbackRepo.GetByTutorId(pagination, id);
            if (res != null) return Ok(res);
            return NotFound("Not exist");
        }
        [HttpGet("date"), Authorize(Roles = "Admin")]
        public ActionResult GetByDate(Pagination pagination, DateTime date)
        {
            var res = _feedbackRepo.GetByDate(pagination, date);
            if (res != null) return Ok(res);
            return NotFound("Not exist");
        }
        [HttpGet("grade/{grade}"), Authorize(Roles = "Admin")]
        public ActionResult GetByGrade(Pagination pagination, float grade)
        {
            var res = _feedbackRepo.GetByGrade(pagination, grade);
            if (res != null) return Ok(res);
            return NotFound("Not exist");
        }
        [HttpPost("createRanDomFeedback")]
        public IActionResult ChamDiem()
        {
            var res = _feedbackRepo.CreateRandomFeedback();
            if (res == ErrorType.Succeed) return Ok("Succeed");
            return BadRequest();
        }
    }
}
