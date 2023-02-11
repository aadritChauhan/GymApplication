using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GymApplication_new.Models
{
    public class MuscleGroup
    {
        [Key]
        public int MuscleGroupId { get; set; }
        public string MuscleGroupName { get; set; }
        public string Exercises { get; set; }
        
        // a muscle group can have many weekdays
        [ForeignKey("Weekday")]
        public int WeekdayId { get; set; }

        public virtual Weekday Weekday { get; set; }
    }
}