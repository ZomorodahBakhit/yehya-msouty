using System;
using System.ComponentModel.DataAnnotations;
namespace University.Core.Forms
{
    public class CreateCourse
    {

        [Required]
        [MinLength(2)]
        public string Name { get; set; } = null!;
        [Range (0,100)]
        public int Weight { get; set; }
    }
}
