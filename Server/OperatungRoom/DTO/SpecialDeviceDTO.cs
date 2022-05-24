using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SpecialDeviceDTO
    {
        public int IdDevice { get; set; }
        public string deviceName { get; set; }
        public bool isAvailable { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<int> amount { get; set; }


        public SpecialDeviceDTO()
        {

        }


        public SpecialDeviceDTO(specialDevice sd)
        {
            this.IdDevice = sd.IdDevice;
            this.deviceName = sd.deviceName;
            this.isAvailable = sd.isAvailable;
            this.date = sd.date;
            this.amount = sd.amount;
        }

        public static List<SpecialDeviceDTO> CreateSpecialDeviceDtoList(List<specialDevice> specialDeviceList)
        {
            List<SpecialDeviceDTO> dtoSpecialDeviceList = new List<SpecialDeviceDTO>();
            foreach (var sd in specialDeviceList)
            {
                SpecialDeviceDTO dtoSpecialDevice = new SpecialDeviceDTO(sd);
                dtoSpecialDeviceList.Add(dtoSpecialDevice);
            }
            return dtoSpecialDeviceList;
        }
        public specialDevice SpecialDeviceToTable()
        {
            specialDevice sd = new specialDevice();
            sd.IdDevice =IdDevice;
            sd.deviceName = deviceName;
            sd.isAvailable = isAvailable;
            sd.date = date;
            sd.amount = amount;
            return sd;
        }
    }
}
