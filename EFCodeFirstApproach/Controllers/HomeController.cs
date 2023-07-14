using EFCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        studentsDBContext db = new studentsDBContext();

        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student stu)
        {
          if(ModelState.IsValid == true)
            {
                db.Students.Add(stu);
                int s = db.SaveChanges();
                if (s > 0)
                {
                    //ViewBag.message = "<script>alert('Inserted Successfully |!!')</script>";
                    //TempData["message"] = "<script> alert('Inserted Successfully |!!') </script> ";
                    TempData["message"] = "Inserted Successfully !!";
                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
                else
                {
                    //ViewBag.message = "<script>alert('Data is not Inserted !!')</script>";
                    TempData["message"] = "<script>alert('Data is not Inserted !!')</script>";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var e = db.Students.Where(m => m.Id == id).FirstOrDefault();
            return View(e);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.UpdateMessage = "<script>alert('Update Messages Successfully !! ')</script>";
                    //TempData["UpdateMessage"] = "<script>alert('Update Messages Successfully !! ')</script>"; 
                    TempData["UpdateMessage"] = "Update Messages Successfully !!";
                    //ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data is not Updated !! ')</script>";
                }
            }
           
            return View();
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            if(id > 0)
            {
                var del = db.Students.Where(model => model.Id == id).FirstOrDefault();
                if(del != null)
                {
                    db.Entry(del).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if(a > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Deleted is successfully !!')</script>";
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Deleted is not successfully !!')</script>";
                    }
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        //[HttpPost]
        //public ActionResult Delete(Student s)
        //{
        //    db.Entry(s).State = EntityState.Deleted;
        //    int d = db.SaveChanges();
        //    if (d > 0)
        //    {
        //        //TempData["DeleteMessage"] = "<script>alert(Deleted is successful !!)</script>";
        //        TempData["DeleteMessage"] = "Deleted is successful";
        //    }
        //    else
        //    {
        //        TempData["DeleteMessage"] = "<script>alert(Deleted is not successful !!)</script>";
        //    }
        //    return RedirectToAction("Index");
        //}


        [HttpGet]
        public ActionResult Details(int id)
        {
            var det = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(det);
        }
    }
}