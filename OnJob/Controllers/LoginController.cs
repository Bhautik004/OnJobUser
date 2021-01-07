    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnJobEntity.JobSeeker;
using OnJob_DAL;
using System.Net.Mail;
using System.Text;
using System.Net;
using System.Data;
using OnJob_BAL;
using System.Web.Security;

namespace OnJob.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public String Fname, Lname, Email;
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User ObjUser)
        {
            UserBal bl = new UserBal();
            User user = new User();
            user= bl.GetLoginDetails(ObjUser);
            if (user.FirstName != null)
            {
                Session["Email"] = user.Email;
                Session["Name"] = user.FirstName;
                Session["Id"] = user.id;
                Session["category"] = user.Category;
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Profile","User",user);
            }
            else
            {
                TempData["Message"] = "Invalid Email and Password";
                ModelState.Clear();
                return View();
            } 
        }
        
        [HttpPost]
        public ActionResult ChangePassword(User ObjUser)
        {
            if(Session["id"] != null)
            {


            }else{

            }
            return View();

        }

        public ActionResult Forgotpassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Forgotpassword(User ObjUser)
        {
            if(ObjUser.Email != null)
            {
                UserBal bl = new UserBal();
                User user = new User();
                user = bl.GetForgotPassword(ObjUser);
                if(user.Password != null)
                {
                    SendMail(user.FirstName, user.LastName, user.Email, user.Password);
                    TempData["Message"] = "5";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["Message"] = "3";
                    return RedirectToAction("Login");
                }   
            }
            else
            {

                TempData["Message"] = "2";
                return View();
            }
            
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            TempData["Message"] = "Logout Successfully";
            return RedirectToAction("Index","Home");
        }

        public ActionResult JobSeekerRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult JobSeekerRegistration(User ObjUser)
        {

            if (!string.IsNullOrEmpty(ObjUser.FirstName) && !string.IsNullOrEmpty(ObjUser.LastName) && !string.IsNullOrEmpty(ObjUser.Email) && !string.IsNullOrEmpty(ObjUser.Password))
            {
                UserDL userDL = new UserDL();
                int result;
                result = userDL.AddUserDetails(ObjUser);
                if (result == 1)
                {
                    //  SendMail(ObjUser.FirstName, ObjUser.LastName, ObjUser.Email);
                    TempData["Message"] = "Registraion Successfull!!";
                    ModelState.Clear();
                    //TempData["msg"] = "Your Account has been made, please verify it by clicking the activation link that has been send to your email.";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["Message"] = "Already Email Registraion!!";
                    ModelState.Clear();
                    return View();
                }
            }
            
            return View();
        }

        private void SendMail(String Fname,String Lname,String Email,String Password )
        {
            User ObjUser = new User();
            string filename = Server.MapPath("~/EmailView.html");
            string mailbody = System.IO.File.ReadAllText(filename);
            mailbody = mailbody.Replace("##NAME##", Fname);
            mailbody = mailbody.Replace("##FirstName##", Fname);
            mailbody = mailbody.Replace("##LastName##", Lname);
            mailbody = mailbody.Replace("##Password##", Password);
            string to = Email;
            string from = "2000bhautikpatel@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Thank you for signing up with us";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("2000bhautikpatel@gmail.com", "Bhautik@123");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(message);
               
            }
            catch
            {
                throw;
            }
        }

        public ActionResult CompanyRegistration()
        {
            return View();
        }

        
    }
}