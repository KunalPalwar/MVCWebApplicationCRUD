using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TempCRUDOperations.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string FatherName { get; set; }
        public string  MotherName { get; set; }
        [DisplayName("Profile Picture")]
        public string ImagePath { get; set; }
   //     public HttpPostedFileBase ImageFile { get; set; }

    }
}