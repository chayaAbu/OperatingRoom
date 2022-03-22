﻿using DAL;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class HungrienSceduling
    {
        static DBConection db = new DBConection();

        int[,] surgeryMatrix;
       double priorityScore;
      
        
        
        public int CalculateScore(List<SurgeryDTO> listOfSurgery, List<RoomDTO> listOfRoom)
        {
          surgeryMatrix=new int [listOfSurgery.Count, listOfRoom.Count];
            Dictionary<double, SurgeryDTO> surgeryWithPriority =CalculatePriority(listOfSurgery);
            for(int i=0; i<surgeryWithPriority.Count(); i++)
            {
                for(int j=0; j < listOfRoom.Count();j++)
                {
                  //surgeryMatrix[i,j]=surgeryWithPriority.ContainsKey+MatchRoom(surgeryWithPriority[i].Value,listOfRoom[j])+MatchDevice()
                }
            }

            return 0;
        }
        public Dictionary<double,SurgeryDTO> CalculatePriority(List<SurgeryDTO> listOfSurgery)
        {
            Dictionary<double,SurgeryDTO> priorityList=new Dictionary<double,SurgeryDTO>();
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
                    if (x.idDevice == y.IdDevice && y.isAvailable == false)
                    {
                        y.date = surg.surgeryDate;
                        sumMatchDavice += 2;
                    }
                }
            }
            return sumMatchDavice;
        }
    
    }
}
