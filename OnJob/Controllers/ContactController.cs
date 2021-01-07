using OnJob_BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnJob.Controllers
{
    public class ContactController : Controller
    {
        UserBal _bal = new UserBal();
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }

        
        public ActionResult SendMsg(string username,string email,string subject,string message) 
        {
            if (Session["Email"] != null || Session["Id"] != null)
            {
                DataSet ds = new DataSet();
                ds = _bal.SendContact(username, email, subject, message);
                TempData["Message"] = 0;
                return RedirectToAction("Contact");
            }
            else
            {
                TempData["Message"] = 1;
                return RedirectToAction("Contact");
            }
               
        }
    }
}