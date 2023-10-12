using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrungTamLuaDao.Context;
using TrungTamLuaDao.Data;
using TrungTamLuaDao.Enum;
using TrungTamLuaDao.IRepository;
using TrungTamLuaDao.Models;
using TrungTamLuaDao.Repository;

namespace TrungTamLuaDao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;
        public StudentController()
        {
            _studentRepo = new StudentRepo();
        }
        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public IActionResult GetById(int id)
        {
            var res = _studentRepo.GetById(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("Not exist");
        }
        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult GetAll(Pagination pagination) 
        {
            var res = _studentRepo.GetAll(pagination);
            if (res.data.Count() == 0) return BadRequest("Null");
            return Ok(res);
        }
        [HttpPost, Authorize(Roles = "Admin")]
        public IActionResult Add(StudentModel studentModel)
        {
            var res = _studentRepo.Add(studentModel);
            if (res == ErrorType.Succeed) return Ok("Succeed");
            return NotFound("Not exist");
        }
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public IActionResult Remove(int id)
        {
            var res = _studentRepo.Remove(id);
            if (res == ErrorType.Succeed) return Ok("Succeed");
            return NotFound("Not exist");
        }
        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public IActionResult Update(int id, StudentModel studentModel)
        {
            var res = _studentRepo.Update(id, studentModel);
            if (res == ErrorType.Succeed) return Ok("Succeed");
            return NotFound("Not exist");
        }
        [HttpPut("addMoney/{id}"), Authorize(Roles = "Admin")]
        public IActionResult AddMoney(int id, int amount)
        {
            var res = _studentRepo.UpdateTotalMoney(id, amount, 1);
            if (res == ErrorType.Succeed) return Ok("Done");
            return NotFound();
        }
    }
}
