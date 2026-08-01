using System;
using System.Collections.Generic;
using System.Linq;
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
            List<StData> studentList = dbOperation.GetStudentList();
            return View(studentList);
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
    }
}