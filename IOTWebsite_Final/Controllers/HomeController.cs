using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing; 

namespace IOTWebsite_Final.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(empDetail u)
        { 
            if(ModelState.IsValid) //Check This Out - Jenurius Mark
            {
                using (IOTEmployeeEntities dc = new IOTEmployeeEntities())
                { 
                    var v = dc.empDetails.Where(m => m.userName.Equals(u.userName) && m.password.Equals(u.password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["UserName"] = v.userName.ToString();
                        return RedirectToAction("AfterLogin", new RouteValueDictionary(
                            new {controller = "Temperature", action = "AfterLogin"}));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Username or Password.");
                    }
                }
            }
            return View(u);
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(empDetail u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (IOTEmployeeEntities dc = new IOTEmployeeEntities())
                    {
                        dc.empDetails.Add(u);
                        dc.SaveChanges();
                        ModelState.Clear();
                        u = null;
                    }
                    TempData["throwMessage_Register"] = "Registration Successfull";
                }
                return View("Registration");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                Exception raise = e;
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;  
            }
                return View("LogIn");
        }
    }
}