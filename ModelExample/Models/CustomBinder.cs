using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelExample.Models
{
    public class CustomBinder:IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //as controller context contains all controller properties like Session,Request,Reqsponse etc so.
            string studentId = controllerContext.HttpContext.Request.Form["StudentId"];
            string studentName = controllerContext.HttpContext.Request.Form["StudentName"];
            string dno = controllerContext.HttpContext.Request.Form["Dno"];
            string street = controllerContext.HttpContext.Request.Form["Street"];
            string landmark = controllerContext.HttpContext.Request.Form["Landmark"];
            string city = controllerContext.HttpContext.Request.Form["City"];

            //must must must return new customized data
            return new Student()
            {
                StudentId = Convert.ToInt32(studentId),
                StudentName = studentName,
                StudentAddress = String.Format($"{dno} , {street}, {landmark} , {city}")
            };
        }
    }
}