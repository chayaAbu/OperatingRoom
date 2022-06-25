using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SpecialDeviceManager
    {
        static DBConection db = new DBConection();
        public static SpecialDeviceDTO AddNewDevice(SpecialDeviceDTO AddDevice)
        {
            specialDevice newDevice = AddDevice.SpecialDeviceToTable();
            db.Execute<specialDevice>(newDevice, DBConection.ExecuteActions.Insert);
            //AddRoom.surgeryCode = newRoom.surgeryCode;
            return AddDevice;


        }
        public static List<SpecialDeviceDTO> GetAllSpecialDevice()
        {
            List<specialDevice> SpecialDeviceFromTable = db.GetDbSet<specialDevice>().ToList();
            List<SpecialDeviceDTO> CreateSpecialDeviceDtoList = SpecialDeviceDTO.CreateSpecialDeviceDtoList(SpecialDeviceFromTable);
            return CreateSpecialDeviceDtoList;

        }
        public static SpecialDeviceDTO GetAllSpecialDeviceAccordingName(string  name)
        {
           specialDevice SpecialDeviceFromTable = db.GetDbSet<specialDevice>().Where(sd=>sd.deviceName==name).Single();
            SpecialDeviceDTO CreateSpecialDeviceDtoList = new SpecialDeviceDTO(SpecialDeviceFromTable);
            return CreateSpecialDeviceDtoList;

        }
        public static SpecialDeviceDTO UpdateDevice(SpecialDeviceDTO UpDevice)
        {
            specialDevice updDevice = UpDevice.SpecialDeviceToTable();
            db.Execute<specialDevice>(updDevice, DBConection.ExecuteActions.Update);
            return UpDevice;

        }
    }
}
