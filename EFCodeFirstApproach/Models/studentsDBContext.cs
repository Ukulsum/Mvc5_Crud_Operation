using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFCodeFirstApproach.Models
{
    public class studentsDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}