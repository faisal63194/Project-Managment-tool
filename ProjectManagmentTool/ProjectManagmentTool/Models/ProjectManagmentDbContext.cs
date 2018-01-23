using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectManagmentTool.Models
{
    public class ProjectManagmentDbContext:DbContext
    {
        public ProjectManagmentDbContext():base("DefaultConnection")
        { }
        public DbSet<UserModel> Users { get; set; }
    }
}