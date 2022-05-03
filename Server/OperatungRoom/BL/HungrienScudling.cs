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
        public double [,] FillMatrix(List<SurgeryDTO> listOfSurgery, List<RoomDTO> listOfRoom, List<DeviceForSurgeryDTO> D, List<SpecialDeviceDTO> S)
        {
            PreHungrien preMat = new PreHungrien();
            double[,] gradeMat = preMat.CalculateScore(listOfSurgery, listOfRoom, D, S);
            return  gradeMat;
        }

        
    }
}
