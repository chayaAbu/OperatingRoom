using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SchedulingManager
    {
        static DBConection db = new DBConection();
        public static SchedulingDTO AddScheduling(SchedulingDTO addScheduling)
        {
            scheduling newScheduling = addScheduling.SchedulingToTable();
            db.Execute<scheduling>(newScheduling, DBConection.ExecuteActions.Insert);
            return addScheduling;


        }
        public static List<SchedulingDTO> GetAllSched()
        {
            List<scheduling> schedFromTable = db.GetDbSet<scheduling>().ToList();
            List<SchedulingDTO> CreateSchedulingDtoList = SchedulingDTO.CreateSchedulingDtoList(schedFromTable);
            return CreateSchedulingDtoList;

        }
    }
}
