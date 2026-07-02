using Microsoft.Extensions.Logging;
using University.Core.Dtos;
using University.Core.Exceptions;
using University.Core.Forms;
using University.Data.Entities;
using University.Data.Repositories;
using UniversitySystemSummer.Core.Validations;

namespace University.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly ILogger<StudentService> _logger;

        public StudentService(IStudentRepository repo, ILogger<StudentService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public StudentDto GetById(int Id)
        {
            _logger.LogInformation("Fetching student with Id: {Id}", Id);

            var student = _repo.GetById(Id);

            if (student == null)
            {
                _logger.LogWarning("Student with Id {Id} not found", Id);
                throw new NotFoundException($"Student with Id {Id} not found");
            }

            return new StudentDto { Id = student.Id, Name = student.Name };
        }

        public List<StudentDto> GetAll()
        {
            _logger.LogInformation("Fetching all students");

            var students = _repo.GetAll();

            return students
                .Select(s => new StudentDto { Id = s.Id, Name = s.Name })
                .ToList();
        }

        public void Add(CreateStudent Form)
        {
            _logger.LogInformation(
                "Attempting to create student with Name: {Name}, Email: {Email}",
                Form.Name, Form.Email);

            var isvalid = FormValidator.Validate(Form);
            if (!isvalid.IsValid)
            {
                _logger.LogError("Invalid student form for creation");
                throw new BusinessException("Form is not valid", isvalid.Errors);
            }

            var student = new Student
            {
                Name = Form.Name,
                Email = Form.Email
            };

            _repo.Add(student);

            _logger.LogInformation(
                "Student created successfully with Name: {Name}, Email: {Email}",
                Form.Name, Form.Email);
        }

        public void Update(int Id, UpdateStudent Form)
        {
            _logger.LogInformation(
                "Attempting to update student with Id: {Id}, Name: {Name}, Email: {Email}",
                Id, Form.Name, Form.Email);

            var student = _repo.GetById(Id);

            if (student == null)
            {
                _logger.LogWarning("Student with Id {Id} not found", Id);
                throw new NotFoundException($"Student with Id {Id} not found");
            }

            var isvalid = FormValidator.Validate(Form);
            if (!isvalid.IsValid)
            {
                _logger.LogError("Invalid student form for update (Id: {Id})", Id);
                throw new BusinessException("Form is not valid", isvalid.Errors);
            }

            if (Form.Name != null)
                student.Name = Form.Name;

            if (Form.Email != null)
                student.Email = Form.Email;

            _repo.Update(student);

            _logger.LogInformation("Student with Id {Id} updated successfully", Id);
        }

        public void Delete(int Id)
        {
            _logger.LogInformation("Attempting to delete student with Id: {Id}", Id);

            var student = _repo.GetById(Id);

            if (student == null)
            {
                _logger.LogWarning("Student with Id {Id} not found", Id);
                throw new NotFoundException($"Student with Id {Id} not found");
            }

            _repo.Delete(Id);

            _logger.LogInformation("Student with Id {Id} deleted successfully", Id);
        }
    }

    public interface IStudentService
    {
        StudentDto GetById(int Id);
        List<StudentDto> GetAll();
        void Add(CreateStudent Form);
        void Update(int id, UpdateStudent Form);
        void Delete(int id);
    }
}