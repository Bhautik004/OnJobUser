using OnJob_BAL;
using OnJobEntity.JobSeeker;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnJob.Controllers
{
    public class JobController : Controller
    {
        UserBal _bal = new UserBal();
        // GET: Job
        public ActionResult Search_Jobs()
        {
            User user = new User();
            user.lstjobpost = _bal.GetJobPost();
            return View(user);
        }

        public ActionResult Job_by_category()
        {
            User user = new User();
            user.categories = _bal.GetJobCountByCategory();
            return View(user);
        }

        public ActionResult Job_by_industry()
        {
            User user = new User();
            user.lstindustry_Types = _bal.GetJobCountByIndustry();
            return View(user);
        }

        public ActionResult Job_by_location()
        {
            User user = new User();
            user.states = _bal.GetJobCountByState();
            return View(user);
        }



        
        public ActionResult JobDetails(int id)
        {
            
            JobPost jobPost = new JobPost();
            jobPost= _bal.GetJobPost_by_id(id);
            return View(jobPost);
        }

        public ActionResult CategoryByJobListing(int id)
        {
            User user = new User();
            user.lstjobpost = _bal.GetJobBy_CategoryId(id);
            return View(user);
        }

        public ActionResult IndustryByJobListing(int id)
        {
            User user= new User();
            user.lstjobpost = _bal.GetJobBy_IndustryId(id);
            return View(user);
        }

        public ActionResult LocationByJobListing(int id)
        {
            User user = new User();
            user.lstjobpost = _bal.GetJobBy_LocationId(id);
            return View(user);
        }



        public ActionResult Searchjob(int category,int state)
        {
            User user = new User();
            user.lstjobpost = _bal.GetJobBy_Search(category, state);
            return View(user);
        }


        [Authorize]
        public ActionResult AppliedJob(int user_id, int job_id, int c_id, string cover_letter)
        {
            DataSet ds = new DataSet();
            ds = _bal.AppliedJob(user_id,job_id,c_id,cover_letter);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                TempData["Message"] = 0;
                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["Message"] = 1;
                return RedirectToAction("Index", "Home");
            }
        }
            
        
    }
}