using University.Data.Repositories;
using University.Data.Entities;
using University.Core.Forms;
namespace University.Core
{
    public class StudentService: IStudentService {

        private readonly IStudentRepository _repo;
        public StudentService(IStudentRepository repo) {
            _repo = repo;
        }

        public StudentDTO GetById(int Id)
        {
            var student = _repo.GetById(Id);
            if (student == null)
            {
                throw new Exception("Student not found");
            }
            return new StudentDTO { Id = student.Id, Name = student.Name };
        }

        public List<StudentDTO> GetAll()
        {
            var students = _repo.GetAll();

            var studentDtos = students
                .Select(s => new StudentDTO { Id = s.Id, Name = s.Name })
                .ToList();
            return studentDtos;

        }
        public void Add (CreateForm Form)
        {
            var student = new Student { Name = Form.Name, Email = Form.Email };
            _repo.Add(student);
        }
        public void Update(int Id, UpdateForm Form)
        {
            var student = _repo.GetById(Id);
            if (student != null)
            {
                if (Form.Name != null)
                {
                    student.Name = Form.Name;
                }
                if (Form.Email != null)
                {
                    student.Email = Form.Email;
                }
                _repo.Update(student);
            }
            else
            {
                throw new Exception("Student Not Found");
            }
        }
        public void Delete(int Id)
        {
             _repo.Delete(Id);
        }
    }

    public interface IStudentService
    {
        StudentDTO GetById(int Id);

        List<StudentDTO> GetAll();

        void Add(CreateForm Form );
        
        void Update(int id, UpdateForm Form);
        void Delete(int id);
    }
    
}
