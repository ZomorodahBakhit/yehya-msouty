using System;

namespace ConsoleApp1.Models 
{
    public class Comment
    {
        public int Id { get; set; }

        public int AssignmentId { get; set; }

        public Assignment Assignment { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CommentContent { get; set; }

    }
}
