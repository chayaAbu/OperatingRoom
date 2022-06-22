using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
   public class SchedulingDetails:DTO.SchedulingDTO
    {


        public int schedulingCode { get; set; }
        public System.DateTime schedulingDate { get; set; }
        public System.TimeSpan schedulingHour { get; set; }
        public int idRoom { get; set; }
        public int surgeryCode { get; set; }
        public System.TimeSpan duringSurg { get; set; }

        
        public SchedulingDetails()
        {
            this.schedulingCode = 0;
            this.schedulingDate =DateTime.Today;
            this.schedulingHour = TimeSpan.FromHours(24);
            this.surgeryCode = 0;
            this.idRoom = 0;
            this.duringSurg = TimeSpan.FromHours(0);

        }
    }
}
