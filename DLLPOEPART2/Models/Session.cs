using System;
using System.Collections.Generic;

#nullable disable

namespace DLLPOEPART2.Models
{
    public partial class Session
    {
        public string SessionId { get; set; }
        public string ModuleId { get; set; }
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }

        public virtual Module Module { get; set; }


        public int CurrWeek = 1;
    }
}
