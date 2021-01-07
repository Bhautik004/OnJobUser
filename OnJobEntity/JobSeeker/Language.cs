using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnJobEntity.JobSeeker
{
    public class Language
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int language{ get; set; }
        public int proficiency { get; set; }
        public string language_value { get; set; }
        public string proficiency_value { get; set; }
        public string flag{ get; set; }
    }
}
