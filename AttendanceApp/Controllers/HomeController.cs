using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttendanceApp.DAL;
using AttendanceApp.Models;
using Newtonsoft.Json;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Entity;

namespace AttendanceApp.Controllers
{
	public class HomeController : Controller
	{
		private EmployeeDBContext db = new EmployeeDBContext();
		[Authorize]
		public ActionResult Index()
		{
			return View();
		}
	}
}