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
          surgeryMatrix=new double [listOfSurgery.Count, listOfRoom.Count];
            IDictionary<double, SurgeryDTO> surgeryWithPriority =CalculatePriority(listOfSurgery);
            foreach (var item in surgeryWithPriority)
            {
                int i = 0;
                for(int j=0; j < listOfRoom.Count();j++)
                {
                    double squereGrade=Grade(item, listOfRoom[j], D, S);
                    surgeryMatrix[i,j] = squereGrade;
                    i++;

                }
            }

            return surgeryMatrix;
        }
        public IDictionary<double,SurgeryDTO> CalculatePriority(List<SurgeryDTO> listOfSurgery)
        {
            IDictionary<double,SurgeryDTO> priorityList=new Dictionary<double,SurgeryDTO>();
            foreach (var ls in listOfSurgery)
            {
                priorityScore = (ls.dangerLevel * 0.85) + (ls.priorityLevel * 0.15);
                priorityList.Add(priorityScore, ls);
            }
            priorityList.OrderBy(p => p.Key);
         
            return priorityList;
        }

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
                    if ((x.deviceName == y.deviceName) &&( y.isAvailable == false) && (y.amount>x.amount))
                    {
                        y.date = surg.surgeryDate;
                        y.isAvailable = true;
                        y.amount -= x.amount;
                        sumMatchDavice += 2;
                    }
                }
            }
            return sumMatchDavice;
        }

        public double Grade(KeyValuePair<double, SurgeryDTO >surgery, RoomDTO Room, List<DeviceForSurgeryDTO> D, List<SpecialDeviceDTO> S)
        {
            double grade;
            grade = surgery.Key + MatchRoom(surgery.Value, Room)+MatchDevice(D,S,surgery.Value);
            return int.MaxValue -  grade;
        }
    
    }
}
