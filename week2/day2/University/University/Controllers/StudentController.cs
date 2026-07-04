using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using University.API;
using University.Core.Dtos;
using University.Core.Forms;
using University.Core.Services;

namespace University.Controllers
{
    [ApiController]
    [TypeFilter(typeof(ApiExceptionFilter))]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _ser;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService ser, ILogger<StudentController> logger)
        {
            _ser = ser;
            _logger = logger;
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(StudentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse GetById(int Id)
        {
            _logger.LogInformation("Incoming request: GET /api/student/{Id}", Id);

            var student = _ser.GetById(Id);
            return new ApiResponse(student);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<StudentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse GetAll()
        {
            _logger.LogInformation("Incoming request: GET /api/student");

            var students = _ser.GetAll();
            return new ApiResponse(students);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Add([FromBody] CreateStudent Form)
        {
            _logger.LogInformation("Incoming request: POST /api/student");

            _ser.Add(Form);
            return new ApiResponse("Student created successfully");
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Update(int Id, [FromBody] UpdateStudent Form)
        {
            _logger.LogInformation("Incoming request: PUT /api/student/{Id}", Id);

            _ser.Update(Id, Form);
            return new ApiResponse("Student updated successfully");
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Delete(int Id)
        {
            _logger.LogInformation("Incoming request: DELETE /api/student/{Id}", Id);

            _ser.Delete(Id);
            return new ApiResponse("Student deleted successfully");
        }
    }
}