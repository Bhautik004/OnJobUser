using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnJob_BAL;
using OnJob_DAL;
using OnJobEntity;
using OnJobEntity.JobSeeker;

namespace OnJob.Controllers
{
    public class UserController : Controller
    {

        UserBal _bal = new UserBal();
        // GET: User
        [Authorize]
        public ActionResult Profile(User ObjUser)
        {

            if (Session["Email"] != null || Session["Id"] != null)
            {
                int id = Convert.ToInt32(Session["Id"]);
                UserBal userBal1 = new UserBal();
                ObjUser= userBal1.GetData(id);
                ObjUser.lstexperiences = userBal1.FetchExperience(id);
                ObjUser.lstEducation= userBal1.FetchEducation(id);
                ObjUser.lstlanguage= userBal1.GetLanguages(id);
                
                // for()
                // string description = GetDescription((Degree_Level)Convert.ToInt32(education.Degree_Level));
                
                ObjUser.addexperienceModel = new AddExperienceModel();            
                ViewBag.Age= new SelectList(userBal1.GetAge(), dataValueField: "Value", dataTextField: "Text");
                ViewBag.Experience = new SelectList(userBal1.GetExperience(), dataValueField: "Value", dataTextField: "Text");
               
                ViewBag.Salary = new SelectList(userBal1.GetSalary(), dataValueField: "Value", dataTextField: "Text");
                
                ViewBag.Year = new SelectList(userBal1.GetYear(), dataValueField: "Value", dataTextField: "Text");
                ViewBag.Month= new SelectList(userBal1.GetMonth(), dataValueField: "Value", dataTextField: "Text");
                
                ViewBag.GetDegreeLevel= new SelectList(userBal1.GetDegreeLevel(), dataValueField: "Value", dataTextField: "Text");
               
                ViewBag.GetLanguage= new SelectList(userBal1.GetLanguage(), dataValueField: "Value", dataTextField: "Text");
                ViewBag.GetProficiency = new SelectList(userBal1.GetProficiency(), dataValueField: "Value", dataTextField: "Text");

                
                return View(ObjUser);
            }
            else
            {
                return RedirectToAction("Home/Login");
            }
           
        }

        [HttpPost]
        public JsonResult AjaxMethod(int id=0)
        {
            List<SelectListItem> category = new List<SelectListItem>();
            User entities = new User();
            UserBal user = new UserBal();
            entities.categories = user.GetCategory(id);
            
            for (int i = 0; i < entities.categories.Count; i++)
            {
                category.Add(new SelectListItem
                {
                    Value = entities.categories[i].id.ToString(),
                    Text = entities.categories[i].name,
                    Selected = entities.categories[i].id == id
                });
            }

            return Json(category);
        }


        [HttpPost]
        public JsonResult AjaxMethodState(int id = 0)
        {
            List<SelectListItem> state = new List<SelectListItem>();
            User entities = new User();
            UserBal user = new UserBal();
            entities.states= user.GetState(id);

            for (int i = 0; i < entities.states.Count; i++)
            {
                state.Add(new SelectListItem
                {
                    Value = entities.states[i].id.ToString(),
                    Text = entities.states[i].s_name,
                    Selected = entities.states[i].id == id
                });
            }

            return Json(state);
        }



        [HttpPost]
        public JsonResult AjaxMethodCity(int id)
        {
            List<SelectListItem> city = new List<SelectListItem>();
            User entities = new User();
            UserBal user = new UserBal();
            entities.cities = user.GetCity(id);

            for (int i = 0; i < entities.cities.Count; i++)
            {
                city.Add(new SelectListItem
                {
                    Value = entities.cities[i].id.ToString(),
                    Text = entities.cities[i].c_name,
                   
                });
            }

            return Json(city);
        }



        [Authorize]
        [HttpPost]
        public ActionResult UpdateInfo(User ObjUser, HttpPostedFileBase Profile_picture_path)
        {
           

            if (ModelState.IsValid)
            {

                var allowedExtensions = new[] {
                    ".Jpg", ".png", ".jpg", "jpeg"
                    };
                ObjUser.Profile_picture_path = Profile_picture_path.ToString();
                var fileName = Path.GetFileName(Profile_picture_path.FileName);
                var ext = Path.GetExtension(Profile_picture_path.FileName);
                if (allowedExtensions.Contains(ext))
                { //check what type of extension  
                    string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                    string myfile = name + "_" + ObjUser.FirstName + "_" + ObjUser.id + ext; //appending the name with id  
                                                                                             // store the file inside ~/project folder(Img)  
                    //string path = Path.Combine(myfile);
                    string path = Path.Combine(Server.MapPath("~/Content/img"), myfile);
                    ObjUser.Profile_picture_path = myfile;
                    Profile_picture_path.SaveAs(path);
                }


                UserBal userBal = new UserBal();
                ObjUser= userBal.UpdateUserBL(ObjUser);
                TempData["Message"] = "Update Successfully";
                Session["CHECK"] = "NULL";
                return RedirectToAction("Profile",ObjUser);

            }
            else
            {
                TempData["Message"] = "0";
                return RedirectToAction("Profile");
            }


            
        }

        [Authorize]
        public ActionResult AddExperience(User Objuser)
        {
            if(Objuser.addexperienceModel.flag == "1")
            {
                UserBal userBal1 = new UserBal();
                userBal1.EditExperience(Objuser.addexperienceModel, Objuser.id);
                return RedirectToAction("Profile");
            }
            else
            {
                if(Objuser.addexperienceModel.job_title != null ||
                    Objuser.addexperienceModel.company != null ||
                    Objuser.addexperienceModel.starting_month != null ||
                    Objuser.addexperienceModel.starting_year  != null ||
                    Objuser.addexperienceModel.ending_month != null ||
                    Objuser.addexperienceModel.ending_year != null ||
                    Objuser.addexperienceModel.description != null
                    )
                {
                    UserBal userBal1 = new UserBal();
                    userBal1.AddExperienceM(Objuser.addexperienceModel, Objuser.id);
                    TempData["Message"] = "4";
                    return RedirectToAction("Profile");
                }
                else
                {
                    TempData["Message"] = "2";
                    return RedirectToAction("Profile");
                }

         
            }
            
            

        }

        [Authorize]
        [HttpPost]
        public JsonResult DeleteExperience(int id)
        {
            UserBal userBal1 = new UserBal();
            userBal1.DeleteExperience(id);
            TempData["Message"] = "3";
            return Json("Delete Successfull!"); 


        }


        [HttpPost]
        [Authorize]
        public JsonResult GetExperience_By_id(int id)
        {
            UserBal bl = new UserBal();
            AddExperienceModel addExperienceModel= new AddExperienceModel();
            addExperienceModel = bl.GetExperience_Byid(id);
            if (addExperienceModel.job_title!= null)
            {
                TempData["Message"] = "Update Successfully";
                return Json(addExperienceModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(addExperienceModel);
            }
        }


        [Authorize]
        public ActionResult AddEducation(User Objuser)
        {
            if (Objuser.education.flag == "1")
            {
                UserBal userBal1 = new UserBal();
                userBal1.EditEducation(Objuser.education, Objuser.id);
                return RedirectToAction("Profile");
            }else
            {

                if(Objuser.education.Degree_Level != 0 ||
                   Objuser.education.Degree_Title != null ||
                   Objuser.education.Major_Subject != null ||
                   Objuser.education.Institution != null ||
                   Objuser.education.Completion_Year != null){

                    UserBal userBal1 = new UserBal();
                    userBal1.AddEducation(Objuser.education, Objuser.id);
                    TempData["Message"] = "4";
                    return RedirectToAction("Profile");
                }
                else
                {
                    TempData["Message"] = "2";
                    return RedirectToAction("Profile");
                }
               
            }
        }


        [Authorize]
        [HttpPost]
        public JsonResult DeleteEducation(int id)
        {
            UserBal userBal1 = new UserBal();
            userBal1.DeleteEducation(id);
            TempData["Message"] = "3";
            return Json("Delete Successfull!");

        }


        [HttpPost]
        [Authorize]
        public JsonResult GetEducation_By_id(int id)
        {
            UserBal bl = new UserBal();
            Education education= new Education();
            education = bl.GetEducation_By_id(id);
            if (education.Degree_Title != null)
            {
                TempData["Message"] = "Update Successfully";
                return Json(education, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(education);
            }
        }



        [Authorize]
        public ActionResult AddLanguage(User Objuser)
        {
            if (Objuser.language.flag == "1")
            {
                UserBal userBal1 = new UserBal();
                userBal1.EditLanguage(Objuser.language, Objuser.id);
                return RedirectToAction("Profile");
            }
            else
            {

                if(Objuser.language.language != 0 ||
                    Objuser.language.proficiency != 0) {

                    UserBal userBal1 = new UserBal();
                    userBal1.AddLanguage(Objuser.language, Objuser.id);
                    TempData["Message"] = "4";
                    return RedirectToAction("Profile");
                }
                else
                {
                    TempData["Message"] = "2";
                    return RedirectToAction("Profile");
                }
               
            }
        }

        [Authorize]
        [HttpPost]
        public JsonResult DeleteLanguage(int id)
        {
            UserBal userBal1 = new UserBal();
            userBal1.DeleteLanguage(id);
            TempData["Message"] = "3";
            return Json("Delete Successfull!");

        }

        [HttpPost]
        [Authorize]
        public JsonResult GetLanguage_By_id(int id)
        {
            UserBal bl = new UserBal();
            Language language = new Language();
            language = bl.GetLanguage_By_id(id);
            if (Convert.ToString(language.language) != null)
            {
                TempData["Message"] = "Update Successfully";
                return Json(language, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(language);
            }
        }


        [Authorize]
        [HttpPost]
        public ActionResult UploadFile(User ObjUser, HttpPostedFileBase Resume)
        {
            var allowedExtensions = new[] {
                    ".pdf"
                    };

            int id = Convert.ToInt32(Session["Id"]);
            string Name = Convert.ToString(Session["Name"]);
            ObjUser.Resume= Resume.ToString();
            var fileName = Path.GetFileName(Resume.FileName);
            var ext = Path.GetExtension(Resume.FileName);
            if (allowedExtensions.Contains(ext))
            { 
                //check what type of extension  
                
                string name = Path.GetFileNameWithoutExtension(fileName); //getting file name without extension  
                string myfile = name + "_" + Name + "_" + id+ ext; //appending the name with id  
                
                //string path = Path.Combine(myfile);
                
                string path = Path.Combine(Server.MapPath("~/Content/resume"), myfile);
                
                ObjUser.Resume = myfile;
                ObjUser.resume_path = path;
                ObjUser.id = id;
                
                Resume.SaveAs(path);
                UserBal bl = new UserBal();
                bl.AddResume(ObjUser);

                return RedirectToAction("Profile");
            }
            else
            {
                return RedirectToAction("Profile");
            }

        }


        [Authorize]

        public ActionResult ChangePassword()
        {
            User ObjUser = new User();
            int id = Convert.ToInt32(Session["Id"]);
            UserBal userBal1 = new UserBal();
            ObjUser = userBal1.GetData(id);
            return View("~/Views/User/ChnagePassword/ChnagePassword.cshtml",ObjUser);
        }
       

       [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(User ObjUser)
        {
            User user = new User();
            int id = Convert.ToInt32(Session["Id"]);
            UserBal userBal1 = new UserBal();
            user = userBal1.GetData(id);
            if (ObjUser.Password== user.Password)
            {
                string nPassword =  ObjUser.CPassword;
                userBal1.ChangePassword(nPassword, id);
                TempData["Message"] = "Update Successfully";
                return RedirectToAction("Profile");
            }
            else
            {
                TempData["Message"] = "8";
                return RedirectToAction("Profile");
            }
            
        }


       
        public ActionResult SavedJob(int id)
        {
            int user_id = Convert.ToInt32(Session["Id"]);
            if(user_id != 0)
            {

            
                 DataSet ds = new DataSet();
            
            
                ds = _bal.savedJob(user_id, id);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
                {
                    return Json("Already Saved!");
                }
                else
                {
                    return Json("Job Save Successfully!");
                }
            }
            else
            {
                return Json("Please login as JobSeeker");
            }



        }


        [Authorize]
        public ActionResult ShowSavedJob()
        {
            User ObjUser = new User();
            int id = Convert.ToInt32(Session["Id"]);
            ObjUser = _bal.GetData(id);
            ObjUser.lstjobpost = _bal.GetSavedJob_byId(id);
            return View("~/Views/User/SavedJob/SavedJob.cshtml", ObjUser);
        }


        [Authorize]
        [HttpPost]
        public JsonResult RemoveSavedJob(int id)
        {
            
            _bal.RemoveSavedJob(id);
            TempData["Message"] = "5";
            return Json("Remove Successfull!");
        }
       
        [Authorize]
        public ActionResult Myapplication()
        {
            User ObjUser = new User();
            int id = Convert.ToInt32(Session["Id"]);
            ObjUser = _bal.GetData(id);
            ObjUser.lstjobpost = _bal.GetAppliedJob_byId(id);
            return View("~/Views/User/MyApplication/MyApplication.cshtml", ObjUser);
        }

        [Authorize]
        [HttpPost]
        public JsonResult RemoveAppliedJob(int id)
        {

            _bal.RemoveAppliedJob(id);
            TempData["Message"] = "5";
            return Json("Remove Successfull!");
        }


    }
}
