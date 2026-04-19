using Microsoft.AspNetCore.Mvc;
using Task10_Mini_Microservice.server.Services.Interfaces;
using Task10_Mini_Microservice.server.Models;

namespace Task10_Mini_Microservice.server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{rollNo}")]
        public async Task<IActionResult> Get(int rollNo)
        {
            var Student = await _service.GetByrollNoAsync(rollNo);
            return Student == null ? NotFound() : Ok(Student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student Student)
        {
            var created = await _service.AddAsync(Student);
            return CreatedAtAction(nameof(Get), new { rollNo = created.rollNo }, created);
        }

        [HttpPut("{rollNo}")]
        public async Task<IActionResult> Update(int rollNo, Student Student)
        {
            var success = await _service.UpdateAsync(rollNo, Student);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{rollNo}")]
        public async Task<IActionResult> Delete(int rollNo)
        {
            var success = await _service.DeleteAsync(rollNo);
            return success ? NoContent() : NotFound();
        }
    }
}