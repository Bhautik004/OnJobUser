using OnJob_BAL;
using OnJobEntity.JobSeeker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnJob.Controllers
{
    public class CompanyController : Controller
    {
        UserBal _bal = new UserBal();
        // GET: Company
        public ActionResult Company()
        {
            User user = new User();

            user.lstcompany = _bal.GetCompany();
            return View(user);
            
        }

        public ActionResult CompanyDetails(int id)
        {
            Company company= new Company();
            company = _bal.GetCompany_by_id(id);
            company.lstjobpost = _bal.GetJobCompany_by_id(id);
            return View(company);
        }
    }
}