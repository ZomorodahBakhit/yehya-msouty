
namespace ConsoleApp1.Models 
{
	public class Course
	{
		public int Id { get; set; }

		public string CourseName { get; set; }

		public int? TeacherId { get; set; }

		public int SyllabusId { get; set; }

		public Syllabus Syllabus { get; set; }

		public ICollection<Assignment> Assignments { get; set; }

	}
}
