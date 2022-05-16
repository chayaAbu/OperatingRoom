using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class SchedulingDTO
    {
        public int schedulingCode { get; set; }
        public System.DateTime schedulingDate { get; set; }
        public System.TimeSpan schedulingHour { get; set; }
        public int idRoom { get; set; }
        public int surgeryCode { get; set; }

        public SchedulingDTO()
        {
                
        }

        public SchedulingDTO(scheduling s)
        {
            this.schedulingCode = s.schedulingCode;
            this.schedulingDate = s.schedulingDate;
            this.schedulingHour = s.schedulingHour;
            this.surgeryCode = s.surgeryCode;
            this.idRoom = s.idRoom;
        }

        public static List<SchedulingDTO> CreateSchedulingDtoList(List<scheduling> schedulingList)
        {
            List<SchedulingDTO> dtoSchedulindList = new List<SchedulingDTO>();
            foreach (var s in schedulingList)
            {
                SchedulingDTO dtoScheduling = new SchedulingDTO(s);
                dtoSchedulindList.Add(dtoScheduling);
            }
            return dtoSchedulindList;
        }
        public scheduling SchedulingToTable()
        {
            scheduling s = new scheduling();
            s.schedulingCode = schedulingCode;
            s.schedulingDate = schedulingDate;
            s.schedulingHour = schedulingHour;
            s.surgeryCode = surgeryCode;
            s.idRoom = idRoom;
            return s;
        }
    }
}
