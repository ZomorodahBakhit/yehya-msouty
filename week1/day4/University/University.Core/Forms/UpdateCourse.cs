using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace University.Core.Forms
{
    public class UpdateCourse
    {
        public string? Name { get; set; } = null!;
       
        public int? Weight { get; set; } = null!;
    }
}

