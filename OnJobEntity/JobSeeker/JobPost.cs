using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnJobEntity.JobSeeker
{
    public class JobPost
    {
        public int id { get; set; } = 0;
        public int saveid { get; set; } 
        public int jobid { get; set; } 
        public int post_job_id { get; set; }
        
        //job title
        [Required(ErrorMessage = "Job Title is required.")]
        public string Title { get; set; }
        //job_type
        [Required(ErrorMessage = "Job Type is required.")]
        public int Job_type { get; set; }

        //Category
        [Required(ErrorMessage = "Category is required.")]
        public int Category { get; set; }

        //indus type
        [Required(ErrorMessage = "Industry Type is required.")]
        public int Job_industry { get; set; }
        //Total_position
        [Required(ErrorMessage = "Position is Requires required.")]
        public int Total_postion { get; set; }
        //Working Experience
        [Required(ErrorMessage = "Working Experience is Requires required.")]
        public int Working_experience { get; set; }
        //Salary_min
        [Required(ErrorMessage = "Minimum Salary is Requires required.")]
        public int Salary_min { get; set; }
        //Salary_max
        [Required(ErrorMessage = "Maxmim Salary is Requires required.")]
        public int Salary_max { get; set; }
        //Salary_period
        [Required(ErrorMessage = "Salary Peroid is Requires required.")]
        public string Salary_peroid { get; set; }
        public string sp { get; set; }
        //Skills
        [Required(ErrorMessage = "Skills is Requires required.")]
        public string Skill { get; set; }
        //Job_desc
        [Required(ErrorMessage = "Job Description is Requires required.")]
        public string Job_desc{ get; set; }
        //Emp_type
        [Required(ErrorMessage = "Emplyee Type is Requires required.")]
        public int Emp_type { get; set; }
        //Education
        [Required(ErrorMessage = "Education is Requires required.")]
        public int Education_type { get; set; }
        //Expire Date
        [Required(ErrorMessage = "Expiry Date is required.")]
        public DateTime Expiry_date { get; set; }
        public DateTime Created_date { get; set; }


        //State
        [Required(ErrorMessage = "State is required.")]
        public int State { get; set; }

        //City
        [Required(ErrorMessage = "City is required.")]
        public int City { get; set; }

        public DateTime createdOn = DateTime.Now;

        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime Date = DateTime.Now.Date;

        public List<Education> lsteducations { get; set; }
        public List<Category> categories { get; set; }
        public List<State> states { get; set; }
        public List<City> cities { get; set; }
        public List<Job_type> job_Types { get; set; }
        public List<Industry_Type> lstindustry_Types { get; set; }
        public List<Position> positions { get; set; }
        public List<EmploymentType> employmentTypes { get; set; }

        public string name { get; set; }
        public string s_name { get; set; }
        public string c_name { get; set; }
        public string inds_type { get; set; }
        public string jobtype { get; set; }
        public string positionavailable { get; set; }
        public string employmenttype { get; set; }
        public string Description { get; set; }
        public string Company_name { get; set; }
        public int c_id { get; set; }
       





    }
}
