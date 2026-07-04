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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _ser;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ICourseService ser, ILogger<CourseController> logger)
        {
            _ser = ser;
            _logger = logger;
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(CourseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse GetById(int Id)
        {
            _logger.LogInformation("Incoming request: GET /api/course/{Id}", Id);

            var course = _ser.GetById(Id);
            return new ApiResponse(course);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CourseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse GetAll()
        {
            _logger.LogInformation("Incoming request: GET /api/course");

            var courses = _ser.GetAll();
            return new ApiResponse(courses);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Add([FromBody] CreateCourse Form)
        {
            _logger.LogInformation("Incoming request: POST /api/course");

            _ser.Add(Form);
            return new ApiResponse("Course created successfully");
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Update(int Id, [FromBody] UpdateCourse Form)
        {
            _logger.LogInformation("Incoming request: PUT /api/course/{Id}", Id);

            _ser.Update(Id, Form);
            return new ApiResponse("Course updated successfully");
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Delete(int Id)
        {
            _logger.LogInformation("Incoming request: DELETE /api/course/{Id}", Id);

            _ser.Delete(Id);
            return new ApiResponse("Course deleted successfully");
        }
    }
}