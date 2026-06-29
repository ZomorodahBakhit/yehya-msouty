using Microsoft.AspNetCore.Mvc;
using University.Core;
using University.Core.Forms;
using University.Api;
namespace University.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController: ControllerBase
    {
        private readonly IStudentService _ser;
        public StudentController (IStudentService ser)
        {
            _ser = ser;
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(StudentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse GetById(int Id)
        {
            var student = _ser.GetById(Id);
            return new ApiResponse(student);
        }

       
        [HttpGet()]
        [ProducesResponseType(typeof(List<StudentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse GetAll()
        {
            var students = _ser.GetAll();
            return new ApiResponse(students);
        }


        [HttpPost()]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Add([FromBody] CreateForm Form)
        {
            _ser.Add(Form);
            return new ApiResponse("Student created successfully");
        }


        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ApiResponse Update(int Id, [FromBody] UpdateForm Form)
        {
            _ser.Update(Id,Form);
            return new ApiResponse("Student Updated successfully");
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Delete(int Id)
        {
            _ser.Delete(Id);
            return new ApiResponse("Student Deleted successfully");
        }

    }
}
