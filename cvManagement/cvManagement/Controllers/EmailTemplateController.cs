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
            EmailTemplateAccessLayer emailTemplateLayer = new EmailTemplateAccessLayer();
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
            EmailTemplateAccessLayer emailTemplateLayer = new EmailTemplateAccessLayer();
            int result = emailTemplateLayer.DeleteData(id);
            TempData["DeleteResult"] = result;
            ModelState.Clear();

            return RedirectToAction("ShowAllTemplates");
        }
        #endregion Delete

        #region createEditTemplate
        /// <summary>
        /// hien thi man hinh them sua template
        /// </summary>
        /// <param name="id" value="string"></param>
        /// <returns>hien thi man hinh them,sua template</returns>
        [HttpGet]
        public ActionResult createEditTemplate(string id)
        {
            if (id != null)
            {
                EmailTemplateAccessLayer emailTemplateLayer = new EmailTemplateAccessLayer();

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
        ///     chuc nang them hoac sua template dua tren id
        /// </summary>
        /// <param name="emailtemplate" value="emailTemplate"></param>
        /// <returns>Quay ve man hinh hien thi toan bo template</returns>
        [HttpPost]
        public ActionResult createEditTemplate(emailTemplate emailtemplate)
        {
            if (emailtemplate.Id > 0)
            {
                if (ModelState.IsValid)
                {
                    EmailTemplateAccessLayer emailTemplateLayer = new EmailTemplateAccessLayer();
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
                    EmailTemplateAccessLayer emailTemplateLayer = new EmailTemplateAccessLayer();
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