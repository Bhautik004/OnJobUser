using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace OnJobEntity.JobSeeker
{
    public class User
    {
        public int id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+))@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+))\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Select !")]
        public string Dob { get; set; }

        [Required(ErrorMessage = "Please Select Age!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        
        public string Profile_picture_path { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Mobile_no { get; set; }
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Please Select Category!")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Job Title is required !")]
        public string Job_title { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string Marital_status { get; set; }
        public string Country { get; set; } //India

        [Required(ErrorMessage = "Please Select State!")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Select City!")]
        public string City { get; set; } // 0
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Address is required!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Select Experience!")]
        public string Experience { get; set; }
        public string Education_level { get; set; }

        [Required(ErrorMessage = "Skills is required!")]
        public string Skills { get; set; }

        [Required(ErrorMessage = "Current Salary is required!")]
        public string Current_salary { get; set; }

        [Required(ErrorMessage = "Expected Salary is required!")]
        public string Expected_salary { get; set; }
        public string Resume { get; set; }
        public int Role { get; set; } //1
        public int Profile_completed { get; set; } //0
        public int Is_active { get; set; } //1
        public int Is_verify { get; set; } //0
        public int Is_admin { get; set; } //0
        public string Token { get; set; }
        public string Password_reset_code { get; set; }
        public string resume_path { get; set; } //0
        public DateTime Created_date { get; set; }
        public DateTime Updated_date { get; set; }

        [DataType(DataType.Password)]
       
        public string CPassword { get; set; }
    
        public List<Category> categories { get; set; }
        public List<Industry_Type> lstindustry_Types { get; set; }
    
        public List<State> states{ get; set; }
        public List<City> cities{ get; set; }
        public List<Age> ages { get; set; }
        public List<Experience> lstexperiences { get; set; }
        
        public AddExperienceModel addexperienceModel { get; set; }
        public Education education{ get; set; }
        public List<Education> lstEducation { get; set; }

        public Language language{ get; set; }
        public List<Language> lstlanguage { get; set; }
        public List<JobPost> lstjobpost{ get; set; }
        public JobPost jobPost{ get; set; }
        public List<Company> lstcompany{ get; set; }
        public Company company { get; set; }




    }
   
}
