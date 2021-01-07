using OnJob_BAL;
using OnJobEntity.JobSeeker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnJob.Controllers
{
    public class HomeController : Controller
    {
        UserBal _bal = new UserBal();
        public ActionResult Index()
        {
            User user = new User();
            user.lstjobpost = _bal.GetJobPost();
            user.lstcompany = _bal.GetCompany();
            user.categories = _bal.GetCategory();
            
            return View(user);
        }

        


        

      



       



       









    }
}