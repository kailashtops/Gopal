using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using MVCApp.DAL;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class StudentDataController : Controller
    {
        // GET: StudentData
        DBOperation dbOperation = new DBOperation();
        public ActionResult Index()
        {
            if(Session["UserName"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.UserName = Session["UserName"].ToString();
                List<StData> studentList = dbOperation.GetStudentList();
                return View(studentList);
            }
            
        }
        public ActionResult Create() { 
          return View();
        }
        [HttpPost]
        public ActionResult Create(StData stData)
        {
            dbOperation.AddStudent(stData);
            return View();
        }
        public ActionResult Delete(int id)
        {
            dbOperation.DeleteStudent(id);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id) { 
          StData stData = dbOperation.GetById(id);
          return View(stData);
        }
        [HttpPost]
        public ActionResult Edit(StData stData)
        {
            dbOperation.UpdateStudent(stData);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id) { 
          StData stData = dbOperation.GetById(id);
          return View(stData);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserRegistration userRegistration)
        {
            dbOperation.Register(userRegistration);
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUserPassword() {
            HttpCookie httpCookie = Request.Cookies["UserCookieTemp1"];
            if (httpCookie != null)
            {
                var uname = httpCookie.Values["Username"].ToString();
                var pass = httpCookie.Values["Password"].ToString();
                return Json(new { success = true, password = pass }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
       
        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            bool isValidUser = dbOperation.Login(userLogin);
            if (isValidUser)
            {
               
                Session["UserName"] = userLogin.UserName;
                Session.Timeout= 30; // Set session timeout to 30 minutes
                //create a cookie to store the username
                HttpCookie cookie = new HttpCookie("UserCookieTemp1");
                cookie["Username"] = userLogin.UserName;
                cookie["Password"]=userLogin.Password;
                //cookie.Expires = DateTime.Now.AddDays(30); 
               // cookie.HttpOnly = true; 
                //cookie.Secure = Request.IsSecureConnection; 
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "StudentData");
            }
            else
            {
                // Show an error message
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }
    }
}