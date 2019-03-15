using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class EmployeeRosterContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public EmployeeRosterContext() : base("name=EmployeeRosterContext")
        {
        }

        public System.Data.Entity.DbSet<Project.Models.EmployeeRoster> EmployeeRosters { get; set; }

        public System.Data.Entity.DbSet<Project.Models.Employee> Employees { get; set; }
    }
}
