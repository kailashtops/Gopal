using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(StudentInfo studentInfo)
        {
            TempData["StudentInfo"] = studentInfo;
            return RedirectToAction("StudentList");
            
        }
        public ActionResult StudentList()
        {
            var studentInfo = TempData["StudentInfo"] as StudentInfo;
            List<StudentInfo> studentList = new List<StudentInfo>();
            if (studentInfo != null)
            {
                studentList.Add(studentInfo);
            }
            return View(studentList);
        }
        public ActionResult StudentDetail(int id) {

            var studentInfo = TempData["StudentInfo"] as StudentInfo;
            List<StudentInfo> studentList = new List<StudentInfo>();
           
            if (studentInfo != null)
            {
                studentList.Add(studentInfo);
            }
            StudentInfo studentDetail = studentList.FirstOrDefault();
            return View(studentDetail);
        }
    }
}