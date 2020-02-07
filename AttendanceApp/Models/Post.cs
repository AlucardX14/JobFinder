﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
	public class Post
	{
		public int ID { get; set; }

		[Display(Name = "Category")]
		public string Category { get; set; }
		
		[Display(Name = "Location")]
		public string Location { get; set; }

		[Display(Name = "Position")]
		public string Position { get; set; }

		[Display(Name = "Company")]
		public string Company { get; set; }

		[Display(Name = "Title")]
		public string Title { get; set; }

		[Display(Name = "Description")]
		public string Description { get; set; }


	}
}