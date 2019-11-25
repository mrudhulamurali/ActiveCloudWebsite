using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeFinder.Models
{
    public class CollegeAPI
    {
    }
    public class Rootobject
    {
        public Metadata metadata { get; set; }
        public Result[] results { get; set; }
    }

    public class Metadata
    {
        public int total { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
    }

    public class Result
    {
        public School school { get; set; }
        public Latest latest { get; set; }
        public int id { get; set; }
    }

    public class School
    {
        public string school_url { get; set; }
        public string name { get; set; }
        public string accreditor { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }

    public class Latest
    {
        public Admissions admissions { get; set; }
    }

    public class Admissions
    {
        public Sat_Scores sat_scores { get; set; }
        public Admission_Rate admission_rate { get; set; }
    }

    public class Sat_Scores
    {
        public Average average { get; set; }
    }

    public class Average
    {
        public float? overall { get; set; }
    }

    public class Admission_Rate
    {
        public float overall { get; set; }
    }

}
