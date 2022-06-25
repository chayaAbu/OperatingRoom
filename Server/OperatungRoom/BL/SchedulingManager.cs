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
        public static SchedulingDTO DeleteScheduling(SchedulingDTO DeleteScheduling)
        {
            scheduling execScheduling = DeleteScheduling.SchedulingToTable();
            db.Execute<scheduling>(execScheduling, DBConection.ExecuteActions.Delete);
            return DeleteScheduling;


        }
        public static List<SchedulingDTO> GetAllSched()
        {
            List<scheduling> schedFromTable = db.GetDbSet<scheduling>().ToList();
            List<SchedulingDTO> CreateSchedulingDtoList = SchedulingDTO.CreateSchedulingDtoList(schedFromTable);
            return CreateSchedulingDtoList;

        }
    
        public static SchedulingDTO GetLast(int ToSched)
        {
            List<scheduling> schedFromTable = db.GetDbSet<scheduling>().ToList();
            if (schedFromTable.Count > 0 && schedFromTable.Last().idRoom == ToSched)
            {
                return SchedulingDTO.CreateSchedulingDtoList(schedFromTable).Where(S => S.idRoom == ToSched).Last();
            }
            else
            {
                SchedulingDTO schedulingDTO = new SchedulingDTO();
                schedulingDTO.idRoom = 0;
                schedulingDTO.surgeryCode = 0;
                schedulingDTO.duringSurg = TimeSpan.FromHours(0);
                schedulingDTO.schedulingHour = TimeSpan.FromHours(0);
                schedulingDTO.schedulingDate = DateTime.Today;
                return schedulingDTO;

            }

        }
        public static void EmergencyCase()
        {
            List<scheduling> schedFromTable = db.GetDbSet<scheduling>().Where(S => S.schedulingDate != DateTime.Today|| (S.schedulingDate != DateTime.Today && S.schedulingHour.Hours <= DateTime.Now.Hour)).ToList();
            List<SchedulingDTO> CreateSchedulingDtoList = SchedulingDTO.CreateSchedulingDtoList(schedFromTable);
            foreach (var s in CreateSchedulingDtoList)
            {
                SurgeryDTO SurgeryEmergency = SurgeryManager.GetSurgeryAccordingCode(s.surgeryCode);
                SurgeryEmergency.hasSches = false;
                SurgeryManager.UpdateSurgery(SurgeryEmergency);
                List<DeviceForSurgeryDTO> FreeDevice = DeviceForSurgeryManager.GetAllSpecialDeviceAccordingCode(s.surgeryCode);
                foreach(var D in FreeDevice)
                {
                    SpecialDeviceDTO toChange = SpecialDeviceManager.GetAllSpecialDeviceAccordingName(D.deviceName);
                    if (toChange.isAvailable == true)
                        toChange.isAvailable = false;
                    toChange.amount += D.amount;
                    SpecialDeviceManager.UpdateDevice(toChange);
             

                }
                DeleteScheduling(s);
            }

        }
    }


}
