

namespace ConsoleApp1.Models
{
    public class Syllabus
    {
        public int Id { get; set; }

        public string Description { get; set; }
        
        public Course? Course { get; set; }
    }
}