using cvManagement.DataAccess;
using cvManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cvManagement.Controllers
{
    public class userProfileController : Controller
    {
        /// <summary>
        /// Hien thi man hinh insert Profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult InsertUserProfile()
        {
            return View();
        }

        /// <summary>
        /// Insert Profile
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InsertUserProfile(userProfile pro)
        {
            if (ModelState.IsValid)
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(pro);
                TempData["result1"] = result;
                ModelState.Clear();

                return RedirectToAction("ListUserProfile");
            }

            else
            {
                ModelState.AddModelError("", "Error in saving data");

                return View();
            }
        }

        /// <summary>
        /// Hien thi man hinh List Profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListUserProfile()
        {
            userProfile pro = new userProfile();
            DataAccessLayer objDB = new DataAccessLayer();
            pro.ListProfile = objDB.Selectalldata();

            return View(pro);
        }

        /// <summary>
        /// Search Profile by Name
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SearchProfileByName(string ID)
        {
            DataAccessLayer dal = new DataAccessLayer();
            userProfile pro = new userProfile
            {
                ListProfile = dal.SearchProfileByName(ID)
            };

            return View(pro);
        }
    }
}
