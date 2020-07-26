using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using TempCRUDOperations.DatabaseContext;
using TempCRUDOperations.Models;

namespace TempCRUDOperations.Controllers
{
    public class StudentController : Controller
    {
        public DataContext _context;
        // GET: Student
        public StudentController()
        {
            _context = new DataContext();
        }
   
        public ActionResult Index()
        {
            var studentList = _context.students.ToList();
          
            return View(studentList);
        }
        
        
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public RedirectToRouteResult Save(Student student,HttpPostedFileBase file)
        {
            
                if (file != null)
                {
                file.SaveAs(HttpContext.Server.MapPath("~/Image/" + file.FileName));
                student.ImagePath = file.FileName;

                    
                }
                _context.students.Add(student);
                _context.SaveChanges();

                
            
            return RedirectToAction("Index");



        }

        public ActionResult Edit(int id)
        {
            var studentRecord = _context.students.Where(std => std.Id == id).FirstOrDefault();
            return View(studentRecord);
        }
        public RedirectToRouteResult Editing(Student student,HttpPostedFileBase file)
        {
            var id = student.Id;
            var studentInDatabase = _context.students.Where(std => std.Id == id).FirstOrDefault();
            foreach(var proper in studentInDatabase.GetType().GetProperties())
            {
                if(proper.Name.Equals("ImagePath"))
                {
                    if(file!=null)
                    {
                        var deletingStoredImage = studentInDatabase.ImagePath;
                        var physicalAddressOfFolder = Server.MapPath("~/Image/");

                        System.IO.File.Delete(physicalAddressOfFolder + deletingStoredImage);

                        studentInDatabase.ImagePath = file.FileName;
                        file.SaveAs(HttpContext.Server.MapPath("~/Image/"+ file.FileName));

                    }

                }
                else
                {
                    proper.SetValue(studentInDatabase, proper.GetValue(student));
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Details(int id)
        {
            var studentDetails = _context.students.Where(std => std.Id == id).FirstOrDefault();
            return View(studentDetails);
        }
        public RedirectToRouteResult Delete(int id)
        {
            var studentRecord = _context.students.Where(std => std.Id == id).FirstOrDefault();
            var fileName =studentRecord.ImagePath;
            System.IO.File.Delete(Server.MapPath("~/Image/")+fileName);
            _context.students.Remove(studentRecord);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}