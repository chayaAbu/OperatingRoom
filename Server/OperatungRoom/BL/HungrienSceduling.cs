using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class HungrienSceduling
    {
       
      int[,] surgeryMatrix;
        int countSurgery;
        int countRoom;
       double priorityScore;
        double maxPS = 0;
        int surgeryHighScore = 0;
        
        
        public int CalculateScore(List<surgery> listOfSurgery, List<room> listOfRoom)
        {
            countSurgery = listOfSurgery.Count;
            countRoom = listOfRoom.Count;
            surgeryMatrix=new int [countSurgery, countRoom];
        
            foreach(var ls in listOfSurgery)
            {
              foreach(var lr in listOfRoom)
                {
                    priorityScore = (ls.dangerLevel*0.85) + (ls.priorityLevel*0.15);
                    if (priorityScore > maxPS)
                    {
                        maxPS = priorityScore;
                        surgeryHighScore = ls.surgeryCode;
                        
                    }
                        

                }
                
            }



            return 0;
        }


    
    }
}
