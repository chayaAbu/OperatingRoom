using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class SurgeryDTO
    {
        public int surgeryCode { get; set; }
        public int idClass { get; set; }
        public int priorityLevel { get; set; }
        public int dangerLevel { get; set; }
        public int idDoctor { get; set; }
        public DateTime surgeryDate { get; set; }
        public System.TimeSpan duringSurg { get; set; }
        public bool hasSches { get; set; }

        public SurgeryDTO()
        {
                
        }

        public SurgeryDTO(surgery s)
        {
            this.surgeryCode = s.surgeryCode;
            this.idClass = s.idClass;
            this.priorityLevel = s.priorityLevel;
            this.dangerLevel = s.dangerLevel;
            this.idDoctor = s.idDoctor;
            this.surgeryDate = s.surgeryDate;
            this.duringSurg = s.duringSurg;
            this.hasSches = s.hasSches;

        }
        public static List<SurgeryDTO> CreateSurgeryDtoList(List<surgery> surgeryList)
         {
            List<SurgeryDTO> dtoSurgeryList = new List<SurgeryDTO>();
            foreach (var s in surgeryList)
            {
                SurgeryDTO dtoSurgery = new SurgeryDTO(s);
                dtoSurgeryList.Add(dtoSurgery);
            }
            return dtoSurgeryList;
        }
        public surgery SurgeryToTable()
        {
            surgery s = new surgery();
            s.surgeryCode =surgeryCode;
            s.idClass = idClass;
            s.priorityLevel = priorityLevel;
            s.dangerLevel = dangerLevel;
            s.idDoctor = idDoctor;
            s.surgeryDate = surgeryDate;
            s.duringSurg = duringSurg;
            s.hasSches = hasSches;
            return s;
        }

    }
    
 
}