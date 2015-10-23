using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOTWebsite_Final.Controllers
{
    public class TemperatureController : Controller
    {
        public ActionResult AfterLogin()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }

        }
        public ActionResult Preference()
        {
            if (Session["UserName"] != null)
            {
                if (ModelState.IsValid)
                {
                    using (IOTEmployeeEntities dc = new IOTEmployeeEntities())
                    {
                        string userName = Session["UserName"].ToString();
                        var check = (from c in dc.employeePreferences
                                     where c.userName == userName
                                     select c).SingleOrDefault();
                        if (check != null)
                        {
                            var prefTemp = (from c in dc.employeePreferences
                                            where c.userName == userName
                                            select c.preferredTemperature);
                            int prefTempe = prefTemp.FirstOrDefault().Value;
                            Session["PreferredTemperature"] = prefTempe;
                        }
                    }
                }
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }
        [HttpPost]
        public ActionResult Preference(employeePreference u)
        {
            if (ModelState.IsValid)
            {
                using (IOTEmployeeEntities dc = new IOTEmployeeEntities())
                {
                    string userName = Session["UserName"].ToString();
                    var prefTemp = (from c in dc.employeePreferences
                                        where c.userName == userName
                                        select c.preferredTemperature);
                    var check = (from c in dc.employeePreferences
                                 where c.userName == userName
                                 select c).SingleOrDefault();
                    if (check != null)
                    {
                        int prefTempe = prefTemp.FirstOrDefault().Value;
                        Session["PreferredTemperature"] = prefTempe;
                        dc.employeePreferences.Remove(dc.employeePreferences.SingleOrDefault(model => model.userName == userName));
                        dc.employeePreferences.Remove(dc.employeePreferences.SingleOrDefault(model => model.preferredTemperature ==  prefTempe));
                    }
                    dc.employeePreferences.Add(new employeePreference
                    {
                        userName = Session["UserName"].ToString(),
                        preferredTemperature = u.preferredTemperature
                     });
                    dc.SaveChanges();
                    TempData["throwMessage"] = "Successfully Updated";
                    return RedirectToAction("Preference");
                }
            }
            return View();
        }
        public ActionResult Contact()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        public ActionResult Help()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else 
            {
                return RedirectToAction("LogIn");
            }
        }
	}
}