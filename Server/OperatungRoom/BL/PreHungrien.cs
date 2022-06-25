using DAL;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class PreHungrien
    {
        static DBConection db = new DBConection();

      double [,] surgeryMatrix;
       double priorityScore;
      
        
        
        public double [,] CalculateScore(List<SurgeryDTO> listOfSurgery, List<RoomDTO> listOfRoom, List<DeviceForSurgeryDTO> D, List<SpecialDeviceDTO>S )
        {
            int i = 0;

          surgeryMatrix=new double [listOfSurgery.Count, listOfRoom.Count];
            IDictionary< SurgeryDTO,double> surgeryWithPriority =CalculatePriority(listOfSurgery);
            foreach (var item in surgeryWithPriority)
            {
               
                for(int j=0; j < listOfRoom.Count();j++)
                {
                    double squereGrade = Grade(item, listOfRoom[j], D, S);
                    if (squereGrade == 0)
                        break;
                    surgeryMatrix[i,j] = squereGrade;
                  

                }
                i++;

            }

            return surgeryMatrix;
        }
        //לשנות עדיפות שתתקדם אם לא שובץ
        public IDictionary<SurgeryDTO, double> CalculatePriority(List<SurgeryDTO> listOfSurgery)
        {
            IDictionary<SurgeryDTO,double> priorityList=new Dictionary<SurgeryDTO, double>();
            foreach (var ls in listOfSurgery)
            {
                priorityScore = (ls.dangerLevel * 0.85) + (ls.priorityLevel * 0.15);
                //שינוי שניתוח יהיה מפתח
                priorityList.Add(ls, priorityScore);
            }
            priorityList.OrderBy(p => p.Key);
         
            return priorityList;
        }
        //לשנות פה
        public double MatchRoom(SurgeryDTO S, RoomDTO R)
        {
            if (S.idClass == R.idClass)
                return 0.2;
            return 0;
        }

        public double MatchDevice(List<DeviceForSurgeryDTO> D, List<SpecialDeviceDTO>S,SurgeryDTO surg)
        {
            double sumMatchDavice = 0;
            List<DeviceForSurgeryDTO> surgeryDevices = D.Where(sd => sd.surgeryCode == surg.surgeryCode).ToList();
            foreach(var x in surgeryDevices)
            {
                foreach(var y in S)
                {
                    if ((x.deviceName == y.deviceName) && (y.isAvailable == false) && (y.amount > x.amount))
                    {
                        y.date = surg.surgeryDate;
                        y.amount -= x.amount;
                        if (y.amount == 0)
                            y.isAvailable = true;
                        SpecialDeviceManager.UpdateDevice(y);
                        sumMatchDavice += 2;
                    }
                    else;
                    return 0;
                }
            }
            return sumMatchDavice;
        }

        public double Grade(KeyValuePair<SurgeryDTO, double >surgery, RoomDTO Room, List<DeviceForSurgeryDTO> D, List<SpecialDeviceDTO> S)
        {
            double grade;
            grade = surgery.Value + MatchRoom(surgery.Key, Room) ;
            if (MatchDevice(D, S, surgery.Key) == 0)
                return 0;
            else
                grade += MatchDevice(D, S, surgery.Key);

            return int.MaxValue -  grade;
        }
    
    }
}
