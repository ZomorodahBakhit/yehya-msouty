
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}
