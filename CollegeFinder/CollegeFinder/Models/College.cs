using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeFinder.Models
{
    public class College
    {
        public int id { get; set; }
        public string collegeName { get; set; }
    }
}
