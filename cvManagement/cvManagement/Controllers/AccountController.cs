using cvManagement.DataAccessLayer;
using cvManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cvManagement.Controllers
{
    public class AccountController : Controller
    {
        #region ShowAllAccounts
        /// <summary>
        /// Hien thi toan bo account
        /// </summary>
        /// <returns value="ActionResult">View()</returns>
        [HttpGet]
        public ActionResult ShowAllAccounts()
        {
            Account account = new Account();
            AccountAccessLayer accountAccessLayer = new AccountAccessLayer();
            account.listAccount = accountAccessLayer.Selectalldata();

            return View(account);
        }
        #endregion ShowAllAccounts

        #region Delete
        /// <summary>
        /// Chuc nang xoa account
        /// </summary>
        /// <param name="id" value="string"></param>
        /// <returns value="ActionResult"></returns>
        [HttpGet]
        public ActionResult Delete(string id)
        {
            AccountAccessLayer accountAccessLayer = new AccountAccessLayer();
            int result = accountAccessLayer.DeleteData(id);
            TempData["DeleteResult"] = result;
            ModelState.Clear();

            return RedirectToAction("ShowAllAccounts");
        }
        #endregion Delete

        #region createEditAccount
        /// <summary>
        /// hien thi man hinh them sua Account
        /// </summary>
        /// <param name="id" value="string"></param>
        /// <returns>hien thi man hinh them,sua account</returns>
        [HttpGet]
        public ActionResult createEditAccount(string id)
        {
            if (id != null)
            {
                AccountAccessLayer accountAccessLayer = new AccountAccessLayer();

                return View(accountAccessLayer.SelectDataById(id));
            }
            else
            {
                Account account = new Account();
                account.Id = 0;

                return View(account);
            }
        }
        #endregion createEditAccount

        #region createEditAccount
        /// <summary>
        ///     chuc nang them hoac sua account dua tren id
        /// </summary>
        /// <param name="" value="Account"></param>
        /// <returns>Quay ve man hinh hien thi toan bo account</returns>
        [HttpPost]
        public ActionResult createEditAccount(Account account, FormCollection form)
        {
            if (account.Id > 0)
            {
                if (ModelState.IsValid)
                {
                    AccountAccessLayer accountAccessLayer = new AccountAccessLayer();
                    string oldpassword = form["oldpassword"];
                    string newpasswordAgain = form["newpasswordagain"];
                    string newpassword = form["newpassword"];
                    if (newpasswordAgain == newpassword && !accountAccessLayer.CheckPasswordAndId(oldpassword, account.Id))
                    {
                        Account updatedAccount = new Account();
                        updatedAccount.Id = account.Id;
                        updatedAccount.Name = account.Name;
                        updatedAccount.PassWord = newpassword;
                        updatedAccount.Role = account.Role;
                        string result = accountAccessLayer.Updatedata(updatedAccount);
                        TempData["UpdateResult"] = result;
                        ModelState.Clear();

                        return RedirectToAction("ShowAllAccounts");
                    }
                    else return View();
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
                    AccountAccessLayer accountAccessLayer = new AccountAccessLayer();
                    string password = form["password"];
                    string passwordAgain = form["passwordAgain"];
                    if (password == passwordAgain)
                    {
                        Account insertedAccount = new Account();
                        insertedAccount.Name = account.Name;
                        insertedAccount.PassWord = password;
                        insertedAccount.Role = account.Role;
                        string result = accountAccessLayer.Insertdata(insertedAccount);
                        TempData["InsertResult"] = result;
                        ModelState.Clear();

                        return RedirectToAction("ShowAllAccounts");
                    }
                    else return View();

                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data to table");

                    return View();
                }
            }
            #endregion createEditAccount
        }
    }
}