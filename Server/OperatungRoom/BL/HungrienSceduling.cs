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
       
      int[][] surgeryMatrix;
        int countSurgery;
        int countRoom;
        int i = 0;
        
        
        public int CalculateScore(List<surgery> listOfSurgery, List<room> listOfRoom)
        {
            countSurgery = listOfSurgery.Count;
            countRoom = listOfRoom.Count;
            //surgeryMatrix=[countSurgery][countRoom];
            //התאמה של מכשירים בחדר 1 
           //איך מחשבים רמת התאמה
            foreach(var ls in listOfSurgery)
            {
                while (i < countSurgery)
                {
                    //Random randNumber=new Random(1-4);
                    //return randNumber;
                }
                
            }



            return 0;
        }


    
    }
}
