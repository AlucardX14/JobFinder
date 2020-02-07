using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AttendanceApp.Models;

namespace AttendanceApp.DAL
{
	public class EmployeeDBContext:DbContext
	{

		public EmployeeDBContext() : base("DefaultConnection")
		{

		}

		public DbSet<Employee> Employee { get; set; }

		public System.Data.Entity.DbSet<AttendanceApp.Models.Post> Posts { get; set; }

		public System.Data.Entity.DbSet<AttendanceApp.Models.Category> Categories { get; set; }

		public System.Data.Entity.DbSet<AttendanceApp.Models.GlobalParams> GlobalParams { get; set; }
	}
}