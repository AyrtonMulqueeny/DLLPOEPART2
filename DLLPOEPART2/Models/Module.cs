using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#nullable disable

namespace DLLPOEPART2.Models
{
    public partial class Module
    {
        public Module()
        {
            Sessions = new HashSet<Session>();
        }

        public string ModuleId { get; set; }
        public string SemesterId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double HoursPerWeek { get; set; }
        public int Credit { get; set; }
        public double SelfStudyHours { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public double RemainingHours { get; set; }
        
        [NotMapped]
        public int CurrHours { get; set; }
        public void setremainingHours()
        {


          // RemainingHours = (SelfStudyHours - CurrHours) =< 0 ? 0 : SelfStudyHours - CurrHours;

        }

        public void remainingh(DateTime d)
        {
            RemainingHours = 0;
            /*DateTime end = d.AddDays(7);
            var rem = SelfStudyHours - Sessions.Where(s => s.Date >= d && s.Date < end).Sum(s => s.Hours);
            RemainingHours = (rem < 0) ? 0 : rem;*/
        }

        public void setselfStudy(int num)
        {
            SelfStudyHours = ((Credit * 10) / num) - HoursPerWeek;
            RemainingHours = SelfStudyHours;
        }

        public double getselfStudy()
        {
            return SelfStudyHours;
        }

        public double getRemainingHours()
        {
            return RemainingHours;
        }
    }
}
