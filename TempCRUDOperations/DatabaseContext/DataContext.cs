using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TempCRUDOperations.Models;

namespace TempCRUDOperations.DatabaseContext
{
    public class DataContext:DbContext
    {
        public DataContext():base("MyDefault")
        {
            
        }
        public DbSet<Student> students { get; set; }

    }
}