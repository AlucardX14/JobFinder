using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
    public class GlobalParams
    {
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Main Page Items List Cap")]
        public int MainItemsCap { get; set; } = 10;

        [Required]
        [Display(Name = "Category Items per Page")]
        public int CategoryPagingSize { get; set; } = 20;

        public GlobalParams()
        {
            MainItemsCap = 10;
            CategoryPagingSize = 20;
        }
    }
}