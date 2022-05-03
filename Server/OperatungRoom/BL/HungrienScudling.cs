using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class HungrienScudling
    {
       public  double FillMatrix(List<SurgeryDTO> listOfSurgery, List<RoomDTO> listOfRoom, List<DeviceForSurgeryDTO> D, List<SpecialDeviceDTO> S)
        {
            double [][] GradeMatrix =PreHungrien.CalculateScore(listOfSurgery, listOfRoom, D, S);
            return 0;
        }
        
    }
}
