using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View("OurCompanyProducts");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult GetEmpNameById(int empid)
        {
            var employeelist = new[]
            {
                new {Id = 1, Name = "Scott", Email = "scott@scott.com"},
                new {Id = 2, Name = "John", Email = "john@john.com"},
                new {Id = 3, Name = "Sara", Email = "sara@sarah.com"}
            };

            var employee = employeelist.FirstOrDefault(e => e.Id == empid);
            if (employee == null)
            {
                return Content($"No Employee is FOUND With Specified ID => {empid}", "text/plain");

            }
            return Content($"The Employee name is {employee.Name} and email is :{employee.Email}", "text/plain");
        }


        public ActionResult GetMyCv()
        {
            //Fetch all files in the Folder (Directory).
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/cv/"));

            //Copy File names to Model collection.
            List<FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
        }

        public ActionResult DownloadFile(string filename)
        {
            //Build the File Path.
            string path = Server.MapPath("~/cv/") + filename;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", filename);
        }
    }
}



