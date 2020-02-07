using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttendanceApp.Models
{
	public class IndexPostViewModel
	{
		public int ID { get; set; }

		[Display(Name = "Global Settings")]
		public GlobalParams GlobalParams { get; set; }

		[Display(Name = "Post")]
		public List<Post> Posts { get; set; }
		
	}
}