using cvManagement.DataAccessLayer;
using cvManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cvManagement.Controllers
{
    public class EmailTemplateController : Controller
    {
        #region ShowAllTemplates
        /// <summary>
        /// Hien thi toan bo Template
        /// </summary>
        /// <returns value="ActionResult">View()</returns>
        [HttpGet]
        public ActionResult ShowAllTemplates()
        {
            emailTemplate objTemplate = new emailTemplate();
            EmailTemplateLayer emailTemplateLayer = new EmailTemplateLayer();
            objTemplate.listTemplate = emailTemplateLayer.Selectalldata();

            return View(objTemplate);
        }
        #endregion ShowAllTemplates

        #region Delete
        /// <summary>
        /// Chuc nang xoa template
        /// </summary>
        /// <param name="id" value="string"></param>
        /// <returns value="ActionResult"></returns>
        [HttpGet]
        public ActionResult Delete(string id)
        {
            EmailTemplateLayer emailTemplateLayer = new EmailTemplateLayer();
            int result = emailTemplateLayer.DeleteData(id);
            TempData["DeleteResult"] = result;
            ModelState.Clear();

            return RedirectToAction("ShowAllTemplates");
        }
        #endregion Delete

        #region createEditTemplate
        /// <summary>
        /// hien thi man hinh them sua blog
        /// </summary>
        /// <param name="id" value="string"></param>
        /// <returns>hien thi man hinh them,sua blog</returns>
        [HttpGet]
        public ActionResult createEditTemplate(string id)
        {
            if (id != null)
            {
                EmailTemplateLayer emailTemplateLayer = new EmailTemplateLayer();

                return View(emailTemplateLayer.SelectDataById(id));
            }
            else
            {
                emailTemplate emailtemplate = new emailTemplate();
                emailtemplate.Id = 0;

                return View(emailtemplate);
            }
        }
        #endregion createEditBlog

        #region createEditBlog
        /// <summary>
        ///     chuc nang them hoac sua blog dua tren id
        /// </summary>
        /// <param name="blobj" value="blobj"></param>
        /// <returns>Quay ve man hinh hien thi toan bo blog</returns>
        [HttpPost]
        public ActionResult createEditTemplate(emailTemplate emailtemplate)
        {
            if (emailtemplate.Id > 0)
            {
                if (ModelState.IsValid)
                {
                    EmailTemplateLayer emailTemplateLayer = new EmailTemplateLayer();
                    string result = emailTemplateLayer.Updatedata(emailtemplate);
                    TempData["UpdateResult"] = result;
                    ModelState.Clear();

                    return RedirectToAction("ShowAllTemplates");
                }
                else
                {
                    ModelState.AddModelError("", "Error in updating data");

                    return View();
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    EmailTemplateLayer emailTemplateLayer = new EmailTemplateLayer();
                    string result = emailTemplateLayer.Insertdata(emailtemplate);
                    TempData["InsertResult"] = result;
                    ModelState.Clear();

                    return RedirectToAction("ShowAllTemplates");
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data to table");

                    return View();
                }
            }
            #endregion createEditBlog

        }
    }
}