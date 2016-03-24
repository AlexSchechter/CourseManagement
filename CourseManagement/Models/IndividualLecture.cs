using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagement.Models
{
    public class IndividualLecture
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public int DurationMin { get; set; }
        public string Room { get; set; }

        public virtual Course Course { get; set; }
    }
}