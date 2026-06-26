
namespace ConsoleApp1.Models
{
    public class Grade
    {
        public int Id { get; set; }

        public int AssignmentId { get; set; }

        public Assignment Assignment { get; set; }

        public int StudentId { get; set; }

        public User Student{ get; set; }

        public int StudentGrade { get; set; }


    }
}