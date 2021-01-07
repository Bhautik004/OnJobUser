using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnJobEntity.JobSeeker
{
    public class Company
    {
        public int id { get; set; }

        //First Name  
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string FirstName { get; set; }

        //Last Name
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string LastName { get; set; }

        //Emial
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+))@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+))\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        //Password
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        //Company Name
        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Company_name { get; set; }

        //Organization Type
        [Required(ErrorMessage = "Organization Type is required.")]
        public int Org_type { get; set; }

        //Address
        [Required(ErrorMessage = "Address name is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Address { get; set; }

        //Phone Number
        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Mobile_no { get; set; }

        //Web site
        [Required(ErrorMessage = "Web site is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Web_site { get; set; }

        //Company Desc
        [Required(ErrorMessage = "Company Description is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public String Compnay_desc { get; set; }
        
        //Company Logo
        [Required(ErrorMessage = "Company Logo is required.")]
        public String Compnay_logo { get; set; }

        //Number of Employee
        [Required(ErrorMessage = "No of  Employees is required.")]
        public int No_of_Emp { get; set; }
        
        //Founded Date
        [Required(ErrorMessage = "Founded Date is required.")]
        public DateTime Founded_date { get; set; }

        //Designation
        [Required(ErrorMessage = "Designation is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Designation { get; set; }

        //Profile picture path
        public string Profile_picture_path { get; set; }

        //Category
        [Required(ErrorMessage = "Category is required.")]
        public int Category { get; set; }

        //State
        [Required(ErrorMessage = "State is required.")]
        public int State { get; set; }

        //City
        [Required(ErrorMessage = "City is required.")]
        public int City { get; set; }

        public int Count { get; set; }

        

       



        public string name { get; set; }
        public List<Category> categories { get; set; }
        public List<State> states { get; set; }
        public List<City> cities { get; set; }
        public List<Organization> organization { get; set; }
        public List<No_of_Emp> No_Of_Emps{ get; set; }
        public List<JobPost> lstjobpost{ get; set; }

        public JobPost jobPost { get; set; }

        public string s_name { get; set; }
        public string c_name { get; set; }
        public string inds_type { get; set; }
        public string jobtype { get; set; }
        public string positionavailable { get; set; }
        public string employmenttype { get; set; }
        public string Description { get; set; }

    }
}
