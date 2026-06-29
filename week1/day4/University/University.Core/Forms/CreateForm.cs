using System;
using System.ComponentModel.DataAnnotations;
namespace University.Core.Forms
{
    public class CreateForm 
    {

        [Required]
        public string Name { get; set; }= null!;
        [EmailAddress]
        public string Email { get; set; }= null!;
    }
}
