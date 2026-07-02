using Microsoft.Extensions.Logging;
using University.Core.Dtos;
using University.Core.Exceptions;
using University.Core.Forms;
using University.Data.Entities;
using University.Data.Repositories;
using UniversitySystemSummer.Core.Validations;

namespace University.Core.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repo;
        private readonly ILogger<CourseService> _logger;

        public CourseService(ICourseRepository repo, ILogger<CourseService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public CourseDto GetById(int Id)
        {
            _logger.LogInformation("Attempting to retrieve Course with ID: {Id}", Id);
            var course = _repo.GetById(Id);

            if (course == null)
            {
                _logger.LogWarning("Course with Id {Id} not found", Id);
                throw new NotFoundException($"Course with Id {Id} not found");
            }

            return new CourseDto
            {
                Id = course.Id,
                Name = course.Name
            };
        }

        public List<CourseDto> GetAll()
        {
            _logger.LogInformation("Attempting to retrieve All Courses ");
            return _repo.GetAll()
                .Select(c => new CourseDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();
        }

        public void Add(CreateCourse Form)
        {
            _logger.LogInformation(
                "Attempting to create new Course with Name: {Name}, Weight: {Weight}",
                Form.Name, Form.Weight);

            var course = new Course
            {
                Name = Form.Name,
                Weight = Form.Weight
            };

            _repo.Add(course);

            _logger.LogInformation(
                "Course created successfully with Name: {Name}, Weight: {Weight}",
                Form.Name, Form.Weight);
        }

        public void Update(int Id, UpdateCourse Form)
        {
            _logger.LogInformation(
                "Attempting to update Course with ID: {Id}, Name: {Name}, Weight: {Weight}",
                Id, Form.Name, Form.Weight);

            var course = _repo.GetById(Id);

            if (course == null)
            {
                _logger.LogError("Course with Id {Id} not found", Id);
                throw new NotFoundException($"Course with Id {Id} not found");
            }

            var isvalid = FormValidator.Validate(Form);
            if (!isvalid.IsValid)
            {
                _logger.LogError("Course Form is not valid for Course Id {Id}", Id);
                throw new BusinessException("Form is not valid", isvalid.Errors);
            }

            if (!string.IsNullOrWhiteSpace(Form.Name))
                course.Name = Form.Name;

            if (Form.Weight != null)
                course.Weight = (int)Form.Weight;

            _repo.Update(course);

            _logger.LogInformation("Course with ID: {Id} updated successfully", Id);
        }

        public void Delete(int Id)
        {
            _logger.LogInformation("Attempting to delete Course with ID: {Id}", Id);

            var course = _repo.GetById(Id);

            if (course == null)
            {
                _logger.LogError("Course with Id {Id} not found", Id);
                throw new NotFoundException($"Course with Id {Id} not found");
            }

            _repo.Delete(Id);

            _logger.LogInformation("Course with ID: {Id} deleted successfully", Id);
        }
    }

    public interface ICourseService
    {
        CourseDto GetById(int Id);
        List<CourseDto> GetAll();
        void Add(CreateCourse Form);
        void Update(int Id, UpdateCourse Form);
        void Delete(int Id);
    }
}