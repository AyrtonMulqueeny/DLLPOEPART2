using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

#nullable disable

namespace DLLPOEPART2.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Modules = new HashSet<Module>();
        }

        public string SemesterId { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfWeeks { get; set; }

        [NotMapped]
        public int CurrWeek = 0; //+1

        public virtual ICollection<Module> Modules { get; set; }
        public void addSession(Session sess)
        {
            foreach (var m in Modules)
            {
                if (m.ModuleId == sess.ModuleId)
                {
                    m.Sessions.Add(sess);
                    return;
                }
            }
        }

        //method that  returns a list of modules with a certain name
        public List<Module> searchName(string name)
        {
            var mod = from m in Modules
                      where m.Name == name
                      select m;
            return mod.ToList<Module>();
        }

        //for self study
        public void setSelf()
        {
            foreach (Module module in Modules)
            {
                if (module.SelfStudyHours == 0)
                {
                    module.setselfStudy(NumberOfWeeks);
                    module.setremainingHours();
                }
            }
        }



       //list of modules
        public List<string> getNames()
        {
            var names = (from n in Modules
                         select n.Name);
            return names.ToList<string>();
        }


       //list of codes
        public List<string> getCodes()
        {
            var codes = (from n in Modules.ToList()
                         select n.Code);
            return codes.ToList<string>();
        }


        

        
        public void setWeekInfo(DateTime d)
        {

            foreach (Module module in Modules)
            {

                module.remainingh(d);

            }

        }


        //current week 
        public DateTime getWeekDate()
        {
            DateTime d = StartDate.AddDays(7 * (CurrWeek +1));//-1
            return d;
        }





    
}
}
