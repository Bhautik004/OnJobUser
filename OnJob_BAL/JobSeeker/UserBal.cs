using OnJobEntity.JobSeeker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnJob_DAL;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;

namespace OnJob_BAL
{
    public class UserBal
    {
        SqlConnection con = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString));
        public int SaveUserregisrationBL(User objUserBL) // passing Bussiness object Here  
        {
            try
            {
                UserDL objUserdl = new UserDL(); // Creating object of Dataccess  
                return objUserdl.AddUserDetails(objUserBL); // calling Method of DataAccess  
            }
            catch
            {
                throw;
            }
        }




        public User UpdateUserBL(User objUserBL) // passing Bussiness object Here  
        {
			string spName = "[UpdateInfo]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.VarChar, objUserBL.id));
            sqlParameters.Add(DBClient.AddParameters("firstname", SqlDbType.VarChar, objUserBL.FirstName));
            sqlParameters.Add(DBClient.AddParameters("lastname", SqlDbType.VarChar, objUserBL.LastName));
            sqlParameters.Add(DBClient.AddParameters("email", SqlDbType.VarChar, objUserBL.Email));
            sqlParameters.Add(DBClient.AddParameters("phone", SqlDbType.VarChar, objUserBL.Mobile_no));
            sqlParameters.Add(DBClient.AddParameters("dob", SqlDbType.VarChar, objUserBL.Dob));
            sqlParameters.Add(DBClient.AddParameters("age", SqlDbType.VarChar, objUserBL.Age));
            sqlParameters.Add(DBClient.AddParameters("path", SqlDbType.VarChar, objUserBL.Profile_picture_path));
            sqlParameters.Add(DBClient.AddParameters("category", SqlDbType.VarChar, objUserBL.Category));
            sqlParameters.Add(DBClient.AddParameters("title", SqlDbType.VarChar, objUserBL.Job_title));
            sqlParameters.Add(DBClient.AddParameters("experience", SqlDbType.VarChar, objUserBL.Experience));
            sqlParameters.Add(DBClient.AddParameters("skills", SqlDbType.VarChar, objUserBL.Skills));
            sqlParameters.Add(DBClient.AddParameters("currentsalary", SqlDbType.VarChar, objUserBL.Current_salary));
            sqlParameters.Add(DBClient.AddParameters("expectedsalary", SqlDbType.VarChar, objUserBL.Expected_salary));
            sqlParameters.Add(DBClient.AddParameters("state", SqlDbType.VarChar, objUserBL.State));
            sqlParameters.Add(DBClient.AddParameters("city", SqlDbType.VarChar, objUserBL.City));
            sqlParameters.Add(DBClient.AddParameters("address", SqlDbType.VarChar, objUserBL.Address));
            User updateinfo = CommonDal.SelectObject<User>(spName, sqlParameters.ToArray());
            return updateinfo;

        }


        public User GetLoginDetails(User ObjUser)
        {
            string spName = "[login]";
			List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("Email", SqlDbType.VarChar,ObjUser.Email));
            sqlParameters.Add(DBClient.AddParameters("Password", SqlDbType.VarChar,ObjUser.Password));
            User jobData = CommonDal.SelectObject<User>(spName, sqlParameters.ToArray());
            return jobData;
        }

        public User GetForgotPassword(User ObjUser)
        {
			string spName = "[ForGotPassword]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("Email", SqlDbType.VarChar, ObjUser.Email));
            User jobData = CommonDal.SelectObject<User>(spName, sqlParameters.ToArray());
            return jobData;
        }

        public User GetData(int id)
        {
			string spName = "[GetData]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            User jobData = CommonDal.SelectObject<User>(spName, sqlParameters.ToArray());
            return jobData;
        }

        public User ChangePassword(string nPassword,int id)
        {
			string spName = "[ChnagePassword]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            sqlParameters.Add(DBClient.AddParameters("password", SqlDbType.VarChar,nPassword));
            User jobData = CommonDal.SelectObject<User>(spName, sqlParameters.ToArray());
            return jobData;
        }


        public void AddExperienceM(AddExperienceModel  ObjExperience,int id)
        {
			string spName = "[AddExperience]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("u_id", SqlDbType.Int,id));
            sqlParameters.Add(DBClient.AddParameters("job_title", SqlDbType.VarChar, ObjExperience.job_title));
            sqlParameters.Add(DBClient.AddParameters("company", SqlDbType.VarChar, ObjExperience.company));
            sqlParameters.Add(DBClient.AddParameters("starting_month", SqlDbType.VarChar, ObjExperience.starting_month));
            sqlParameters.Add(DBClient.AddParameters("starting_year", SqlDbType.VarChar, ObjExperience.starting_year));
            sqlParameters.Add(DBClient.AddParameters("ending_month", SqlDbType.VarChar, ObjExperience.ending_month));
            sqlParameters.Add(DBClient.AddParameters("ending_year", SqlDbType.VarChar, ObjExperience.ending_year));
            sqlParameters.Add(DBClient.AddParameters("description ", SqlDbType.VarChar, ObjExperience.description));
            sqlParameters.Add(DBClient.AddParameters("currently_working_here", SqlDbType.Bit, ObjExperience.currently_working_here));
             CommonDal.Crud(spName, sqlParameters.ToArray());
            
        }

        public void EditExperience(AddExperienceModel ObjExperience, int id)
        {
			string spName = "[EditExperience]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("e_id", SqlDbType.Int,ObjExperience.e_id));
            sqlParameters.Add(DBClient.AddParameters("u_id", SqlDbType.Int, id));
            sqlParameters.Add(DBClient.AddParameters("job_title", SqlDbType.VarChar, ObjExperience.job_title));
            sqlParameters.Add(DBClient.AddParameters("company", SqlDbType.VarChar, ObjExperience.company));
            sqlParameters.Add(DBClient.AddParameters("starting_month", SqlDbType.VarChar, ObjExperience.starting_month));
            sqlParameters.Add(DBClient.AddParameters("starting_year", SqlDbType.VarChar, ObjExperience.starting_year));
            sqlParameters.Add(DBClient.AddParameters("ending_month", SqlDbType.VarChar, ObjExperience.ending_month));
            sqlParameters.Add(DBClient.AddParameters("ending_year", SqlDbType.VarChar, ObjExperience.ending_year));
            sqlParameters.Add(DBClient.AddParameters("description ", SqlDbType.VarChar, ObjExperience.description));
            sqlParameters.Add(DBClient.AddParameters("currently_working_here", SqlDbType.Bit, ObjExperience.currently_working_here));
            CommonDal.Crud(spName, sqlParameters.ToArray());

        }

        public void DeleteExperience(int id)
        {
			string spName = "[DeleteExperience]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id)); 
            CommonDal.Crud(spName, sqlParameters.ToArray());

        }

        public List<Experience> FetchExperience(int id)
        {
			string spName = "[GetExperience]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            List<Experience> jobData = CommonDal.ExecuteProcedure<Experience>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }
       

        public AddExperienceModel GetExperience_Byid(int id)
        {
			string spName = "[GetExperience_by_id]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            AddExperienceModel jobData = CommonDal.SelectObject<AddExperienceModel>(spName, sqlParameters.ToArray());
            return jobData;
        }


        public void AddEducation(Education  ObjEducation, int id)
        {
			string spName = "[AddEduction]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("user_id", SqlDbType.Int, id));
            sqlParameters.Add(DBClient.AddParameters("Degree_Level", SqlDbType.VarChar, ObjEducation.Degree_Level));
            sqlParameters.Add(DBClient.AddParameters("Degree_Title", SqlDbType.VarChar, ObjEducation.Degree_Title));
            sqlParameters.Add(DBClient.AddParameters("Major_Subject", SqlDbType.VarChar, ObjEducation.Major_Subject));
            sqlParameters.Add(DBClient.AddParameters("Institution", SqlDbType.VarChar, ObjEducation.Institution));
            sqlParameters.Add(DBClient.AddParameters("Completion_Year", SqlDbType.VarChar, ObjEducation.Completion_Year));
           
            CommonDal.Crud(spName, sqlParameters.ToArray());

        }

        public List<Education> FetchEducation(int id)
        {
			string spName = "[GetEducation]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            List<Education> jobData = CommonDal.ExecuteProcedure<Education>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }

        public void DeleteEducation(int id)
        {
			string spName = "[DeleteEducation]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            CommonDal.Crud(spName, sqlParameters.ToArray());

        }

        public Education GetEducation_By_id(int id)
        {
			string spName = "[GetEducation_by_id]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            Education jobData = CommonDal.SelectObject<Education>(spName, sqlParameters.ToArray());
            return jobData;
        }

        public void EditEducation(Education  ObjEducation, int id)
        {
			string spName = "[EditEducation]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, ObjEducation.id));
            sqlParameters.Add(DBClient.AddParameters("user_id", SqlDbType.Int, id));
            sqlParameters.Add(DBClient.AddParameters("Degree_Level", SqlDbType.VarChar, ObjEducation.Degree_Level));
            sqlParameters.Add(DBClient.AddParameters("Degree_Title", SqlDbType.VarChar, ObjEducation.Degree_Title));
            sqlParameters.Add(DBClient.AddParameters("Major_Subject", SqlDbType.VarChar, ObjEducation.Major_Subject));
            sqlParameters.Add(DBClient.AddParameters("Institution", SqlDbType.VarChar, ObjEducation.Institution));
            sqlParameters.Add(DBClient.AddParameters("Completion_Year", SqlDbType.VarChar, ObjEducation.Completion_Year));
            CommonDal.Crud(spName, sqlParameters.ToArray());

        }

        public void AddLanguage(Language Objlanguage, int id)
        {
			string spName = "[AddLanguage]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("user_id", SqlDbType.Int, id));
            sqlParameters.Add(DBClient.AddParameters("language", SqlDbType.Int, Objlanguage.language));
            sqlParameters.Add(DBClient.AddParameters("proficiency", SqlDbType.Int, Objlanguage.proficiency));

            CommonDal.Crud(spName, sqlParameters.ToArray());

        }
       
        public void EditLanguage(Language  Objlanguage, int id)
        {
			string spName = "[EditLanguage]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, Objlanguage.id));
            sqlParameters.Add(DBClient.AddParameters("user_id", SqlDbType.Int, id));
            sqlParameters.Add(DBClient.AddParameters("language", SqlDbType.Int, Objlanguage.language));
            sqlParameters.Add(DBClient.AddParameters("proficiency", SqlDbType.Int, Objlanguage.proficiency));
            CommonDal.Crud(spName, sqlParameters.ToArray());

        }

        public List<Language> GetLanguages(int id)
        {
			string spName = "[GetLanguage]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.VarChar,Convert.ToInt32(id)));
            List<Language> jobData = CommonDal.ExecuteProcedure<Language>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }

        public void DeleteLanguage(int id)
        {
			string spName = "[DeleteLanguage]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            CommonDal.Crud(spName, sqlParameters.ToArray());

        }

        public Language GetLanguage_By_id(int id)
        {
			string spName = "[GetLanguage_by_id]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            Language jobData = CommonDal.SelectObject<Language>(spName, sqlParameters.ToArray());
            return jobData;
        }


        public void AddResume(User ObjUser)
        {
			string spName = "[UploadResume]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, ObjUser.id));
            sqlParameters.Add(DBClient.AddParameters("resume", SqlDbType.VarChar, ObjUser.Resume));
            sqlParameters.Add(DBClient.AddParameters("resume_path", SqlDbType.VarChar, ObjUser.resume_path));

            CommonDal.Crud(spName, sqlParameters.ToArray());

        }
        public List<JobPost> GetJobPost()
        {
			string spName = "[FetchJobPost]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<JobPost> jobData = CommonDal.ExecuteProcedure<JobPost>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }


        public List<Company> GetCompany()
        {
			string spName = "[FetchCompany]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<Company> jobData = CommonDal.ExecuteProcedure<Company>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }

        public JobPost GetJobPost_by_id(int id)
        {
			string spName = "[GetPostJobInfo_By_id]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            JobPost jobData = CommonDal.SelectObject<JobPost>(spName, sqlParameters.ToArray());
            return jobData;
        }

        public DataSet savedJob(int u_id,int job_id)
        {
			string spName = "[savedjob]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("u_id", SqlDbType.Int, u_id));
            sqlParameters.Add(DBClient.AddParameters("job_id", SqlDbType.Int, job_id));
            DataSet ds = CommonDal.ExecuteDataSet(spName, sqlParameters.ToArray());
            return ds;
        }


        public List<JobPost> GetSavedJob_byId(int id)
        {
			string spName = "[FerchSavedJob]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("u_id", SqlDbType.VarChar, Convert.ToInt32(id)));
            List<JobPost> jobData = CommonDal.ExecuteProcedure<JobPost>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }

        public void RemoveSavedJob(int id)
        {
			string spName = "[RemoveSaveJob]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            CommonDal.Crud(spName, sqlParameters.ToArray());

        }


        public List<Category> GetCategory()
        {
			string spName = "[FetchCategoriesId]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<Category> jobData = CommonDal.ExecuteProcedure<Category>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }

        public Company GetCompany_by_id(int id)
        {
			string spName = "[GetCompanyInfo_By_id]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            Company company= CommonDal.SelectObject<Company>(spName, sqlParameters.ToArray());
            return company;
        }

        public List<JobPost> GetJobCompany_by_id(int id)
        {
			string spName = "[GetJobByCompany]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            List<JobPost> jobData = CommonDal.ExecuteProcedure<JobPost>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }

        public List<JobPost> GetJobBy_CategoryId(int id)
        {
			string spName = "[FetchJobByCategoryId]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("cat_id", SqlDbType.Int, id));
            List<JobPost> jobData = CommonDal.ExecuteProcedure<JobPost>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }

        public List<Category> GetJobCountByCategory()
        {
			string spName = "[FetchCategoryCount]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<Category> jobData = CommonDal.ExecuteProcedure<Category>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }

        public List<Industry_Type> GetJobCountByIndustry()
        {
			string spName = "[FetchindustryCount]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<Industry_Type> jobData = CommonDal.ExecuteProcedure<Industry_Type>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }

        public List<JobPost> GetJobBy_IndustryId(int id)
        {
			string spName = "[FetchJobByIndustryId]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("industry_id", SqlDbType.Int, id));
            List<JobPost> jobData = CommonDal.ExecuteProcedure<JobPost>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }

        public List<State> GetJobCountByState()
        {
			string spName = "[FetchLocationCount]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<State> jobData = CommonDal.ExecuteProcedure<State>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }

        public List<JobPost> GetJobBy_LocationId(int id)
        {
			string spName = "[FetchJobByLocationId]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("s_id", SqlDbType.Int, id));
            List<JobPost> jobData = CommonDal.ExecuteProcedure<JobPost>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }
       
        public List<JobPost> GetJobBy_Search(int cat_id,int s_id)
        {
			string spName = "[FetchJobPostBySearch]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("cat_id", SqlDbType.Int, cat_id));
            sqlParameters.Add(DBClient.AddParameters("s_id", SqlDbType.Int, s_id));
            List<JobPost> jobData = CommonDal.ExecuteProcedure<JobPost>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
        }

        public DataSet AppliedJob(int u_id, int job_id,int c_id,string msg)
        {
			string spName = "[AppliedJob]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();	
            sqlParameters.Add(DBClient.AddParameters("u_id", SqlDbType.Int, u_id));
            sqlParameters.Add(DBClient.AddParameters("job_id", SqlDbType.Int, job_id));
            sqlParameters.Add(DBClient.AddParameters("c_id", SqlDbType.Int, c_id));
            sqlParameters.Add(DBClient.AddParameters("msg", SqlDbType.VarChar, msg));
            DataSet ds = CommonDal.ExecuteDataSet(spName, sqlParameters.ToArray());
            return ds;
        }

        public List<JobPost> GetAppliedJob_byId(int id)
        {
			string spName = "[FetchAppliedJob]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("u_id", SqlDbType.VarChar, Convert.ToInt32(id)));
            List<JobPost> jobData = CommonDal.ExecuteProcedure<JobPost>(spName, sqlParameters.ToArray()).ToList();
            return jobData;
			
        }
        public void RemoveAppliedJob(int id)
        {
			string spName = "[RemoveAppliedJob]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            CommonDal.Crud(spName, sqlParameters.ToArray());

        }
        public DataSet SendContact(string username,string email,string subject,string message)
        {
            string spName = "[SendContact]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("username", SqlDbType.VarChar, username));
            sqlParameters.Add(DBClient.AddParameters("email", SqlDbType.VarChar,email));
            sqlParameters.Add(DBClient.AddParameters("subject", SqlDbType.VarChar,subject));
            sqlParameters.Add(DBClient.AddParameters("message", SqlDbType.VarChar, message));
            DataSet ds = CommonDal.ExecuteDataSet(spName, sqlParameters.ToArray());
            return ds;
        }









        public List<Category> GetCategory(int id)
        {

            string spName = "[FetchCategories]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));
            IList<Category> roleList = CommonDal.ExecuteProcedure<Category>(spName, sqlParameters.ToArray());
            return roleList.ToList();


        }



        public List<State> GetState(int id)
        {
            string spName = "[FetchState]";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(DBClient.AddParameters("id", SqlDbType.Int, id));

            IList<State> roleList = CommonDal.ExecuteProcedure<State>(spName, sqlParameters.ToArray());
            return roleList.ToList();

        }


        public List<City> GetCity(int id)
        {
			 string spName = "[FetchCity]";
            string constring = ConfigurationManager.ConnectionStrings["Dbconnection"].ToString();
            con = new SqlConnection(constring);

            List<City> cities= new List<City>();

            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@s_id", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                cities.Add(
                    new City
                    {

                        id = Convert.ToInt32(dr["id"]),
                        c_name = Convert.ToString(dr["c_name"])

                    });
            }
            return cities;
        }

        public  IList<SelectListItem> GetAge()
        {
            IList<SelectListItem> _result = new List<SelectListItem>();
            _result.Add(new SelectListItem { Value = "0", Text = "Select Age" });
            for (int i = 18; i <= 65; i++)
            {
                _result.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            return _result;
        }

        public IList<SelectListItem> GetExperience()
        {
            IList<SelectListItem> _result = new List<SelectListItem>();
            _result.Add(new SelectListItem { Value = "0", Text = "Select Experience" });
            _result.Add(new SelectListItem { Value = "0-1", Text = "0 - 1 Years" });
            _result.Add(new SelectListItem { Value = "1-2", Text = "1 - 2 Years" });
            _result.Add(new SelectListItem { Value = "2-5", Text = "2 - 5 Years" });
            _result.Add(new SelectListItem { Value = "5-10", Text = "5 - 10 Years" });
            _result.Add(new SelectListItem { Value = "10-15", Text = "10 - 15 Years" });
            _result.Add(new SelectListItem { Value = "15+", Text = "15 + Years" });
            _result.Add(new SelectListItem { Value = "null", Text = "Fresher" });

            return _result;
        }

        public IList<SelectListItem> GetSalary()
        {
            IList<SelectListItem> _result = new List<SelectListItem>();
            _result.Add(new SelectListItem { Value = "0", Text = "Select Salary" });
            _result.Add(new SelectListItem { Value = "5000", Text = "5000" });
            _result.Add(new SelectListItem { Value = "10000", Text = "10000" });
            _result.Add(new SelectListItem { Value = "15000", Text = "15000" });
            _result.Add(new SelectListItem { Value = "20000", Text = "20000" });
            _result.Add(new SelectListItem { Value = "25000", Text = "25000" });
            _result.Add(new SelectListItem { Value = "30000", Text = "30000" });
            _result.Add(new SelectListItem { Value = "35000", Text = "35000" });
            _result.Add(new SelectListItem { Value = "40000", Text = "40000" });
            _result.Add(new SelectListItem { Value = "45000", Text = "45000" });
            _result.Add(new SelectListItem { Value = "50000", Text = "50000" });
            _result.Add(new SelectListItem { Value = "55000", Text = "55000" });
            _result.Add(new SelectListItem { Value = "60000", Text = "60000" });
            _result.Add(new SelectListItem { Value = "65000", Text = "65000" });
            _result.Add(new SelectListItem { Value = "70000", Text = "70000" });
            _result.Add(new SelectListItem { Value = "75000", Text = "75000" });
            _result.Add(new SelectListItem { Value = "80000", Text = "80000" });
            _result.Add(new SelectListItem { Value = "85000", Text = "85000" });
            _result.Add(new SelectListItem { Value = "90000", Text = "90000" });
            _result.Add(new SelectListItem { Value = "95000", Text = "95000" });

            return _result;
        }


        public IList<SelectListItem> GetMonth()
        {
            IList<SelectListItem> _result = new List<SelectListItem>();
            _result.Add(new SelectListItem { Value = "null", Text = "Select Month" });
            _result.Add(new SelectListItem { Value = "Jan", Text =  "Jan" });
            _result.Add(new SelectListItem { Value = "Fab", Text = "Fab" });
            _result.Add(new SelectListItem { Value = "Mar", Text = "Mar" });
            _result.Add(new SelectListItem { Value = "Apr", Text = "Apr" });
            _result.Add(new SelectListItem { Value = "May", Text = "May" });
            _result.Add(new SelectListItem { Value = "Jun", Text = "Jun" });
            _result.Add(new SelectListItem { Value = "Jul", Text = "Jul" });
            _result.Add(new SelectListItem { Value = "Aug", Text = "Aug" });
            _result.Add(new SelectListItem { Value = "Sep", Text = "Sep" });
            _result.Add(new SelectListItem { Value = "Oct", Text = "Oct" });
            _result.Add(new SelectListItem { Value = "Nov", Text = "Nov" });
            _result.Add(new SelectListItem { Value = "Dec", Text = "Dec" });
            

            return _result;
        }


        public IList<SelectListItem> GetYear()
        {
            IList<SelectListItem> _result = new List<SelectListItem>();
            _result.Add(new SelectListItem { Value = "null", Text = "Select Year" });
            _result.Add(new SelectListItem { Value = "2020", Text = "2020" });
            _result.Add(new SelectListItem { Value = "2019", Text = "2019" });
            _result.Add(new SelectListItem { Value = "2018", Text = "2018" });
            _result.Add(new SelectListItem { Value = "2017", Text = "2017" });
            _result.Add(new SelectListItem { Value = "2016", Text = "2016" });
            _result.Add(new SelectListItem { Value = "2015", Text = "2015" });
            _result.Add(new SelectListItem { Value = "2014", Text = "2014" });
            _result.Add(new SelectListItem { Value = "2013", Text = "2013" });
            _result.Add(new SelectListItem { Value = "2012", Text = "2012" });
         

            return _result;
        }


        public IList<SelectListItem> GetDegreeLevel()
        {
            IList<SelectListItem> _result = new List<SelectListItem>();
            _result.Add(new SelectListItem { Value = "0", Text = "Select Option" });
            _result.Add(new SelectListItem { Value = "1", Text = "Bachelor degree" });
            _result.Add(new SelectListItem { Value = "2", Text = "Diploma" });
            _result.Add(new SelectListItem { Value = "3", Text = "Doctorate" });
            _result.Add(new SelectListItem { Value = "4", Text = "Higher diploma" });
            _result.Add(new SelectListItem { Value = "4", Text = "High school or equivalent" });
            _result.Add(new SelectListItem { Value = "6", Text = "Master's degree" });


            return _result;
        }

        public IList<SelectListItem> GetLanguage()
        {
            IList<SelectListItem> _result = new List<SelectListItem>();
            _result.Add(new SelectListItem { Value = "0", Text = "Select Language" });
            _result.Add(new SelectListItem { Value = "1", Text = "Hindi" });
            _result.Add(new SelectListItem { Value = "2", Text = "English" });
            _result.Add(new SelectListItem { Value = "3", Text = "Gujrati" });
            return _result;
        }
        public IList<SelectListItem> GetProficiency()
        {
            IList<SelectListItem> _result = new List<SelectListItem>();
            _result.Add(new SelectListItem { Value = "0", Text = "Select Proficiency" });
            _result.Add(new SelectListItem { Value = "1", Text = "Beginner" });
            _result.Add(new SelectListItem { Value = "2", Text = "Intermediate" });
            _result.Add(new SelectListItem { Value = "3", Text = "Expert" });
            return _result;
        }
        

    }
}
