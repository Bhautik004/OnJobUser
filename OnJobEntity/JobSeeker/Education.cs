using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnJobEntity.JobSeeker
{
    public class Education
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int Degree_Level { get; set; }
        public string Country { get; set; }
        public string Degree_Title{ get; set; }
        public string Major_Subject { get; set; }
        public string Institution { get; set; }
        public string Completion_Year{ get; set; }
        public string flag{ get; set; }
        public string Description { get; set; }


    }
}
