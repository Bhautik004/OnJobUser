using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnJobEntity.JobSeeker
{
    public class AddExperienceModel
    {
        public int e_id { get; set; }
        public int user_id { get; set; }

        [Required(ErrorMessage = "Job Title Required!")]
        public string job_title { get; set; }

        [Required(ErrorMessage = "Company Name Required!")]
        public string company { get; set; }
        public string country { get; set; }

        [Required(ErrorMessage = "Please Select Month!")]
        public string starting_month { get; set; }

        [Required(ErrorMessage = "Please Select Year!")]
        public string starting_year { get; set; }


        public string ending_month { get; set; }


        public string ending_year { get; set; }


        public bool currently_working_here { get; set; }

        [Required(ErrorMessage = "Description Required!")]
        public string description { get; set; }
        public string flag { get; set; }
    }
}
