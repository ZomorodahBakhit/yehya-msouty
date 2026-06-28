
using System;

namespace ConsoleApp1.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        public Course Course { get; set; }

        public string AssignmentTitle { get; set; }

        public string? Description { get; set; }

        public float Weight { get; set; }

        public int MaxGrade { get; set; }

        public DateTime DueDate { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Grade> Grades { get; set; }
    }
}
