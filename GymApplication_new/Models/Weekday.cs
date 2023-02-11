using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymApplication_new.Models
{
    public class Weekday
    {
        [Key]
        public int WeekdayId { get; set; }
        public string WeekdayName { get; set; }
    }
    public class WeekdayDto
    {
        public int WeekdayId { get; set; }
        public string WeekdayName { get; set; }

    }
}