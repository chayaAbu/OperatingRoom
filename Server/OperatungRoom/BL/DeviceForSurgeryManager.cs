using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DeviceForSurgeryManager
    {
        static DBConection db = new DBConection();

        public static DeviceForSurgeryDTO AddDeviceRequest(DeviceForSurgeryDTO setNewRequestForDevice)
        {
            deviceForSurgery newRequest = setNewRequestForDevice.DeviceToTable();
            db.Execute<deviceForSurgery>(newRequest, DBConection.ExecuteActions.Insert);
            return setNewRequestForDevice;
        }

        public static List<DeviceForSurgeryDTO> GetAllRequest()
        {
            List<deviceForSurgery> deviceFromTable = db.GetDbSet<deviceForSurgery>().ToList();
            List<DeviceForSurgeryDTO> CreateDeviceForSurgeryDtoList = DeviceForSurgeryDTO.CreateDeviceForSurgeryDtoList(deviceFromTable);
            return CreateDeviceForSurgeryDtoList;

        }
        public static List<DeviceForSurgeryDTO> GetAllSpecialDeviceAccordingCode(int code)
        {
            List<deviceForSurgery> deviceFromTable = db.GetDbSet<deviceForSurgery>().Where(sd=>sd.surgeryCode==code).ToList();
            List<DeviceForSurgeryDTO> CreateDeviceForSurgeryDtoList = DeviceForSurgeryDTO.CreateDeviceForSurgeryDtoList(deviceFromTable);
            return CreateDeviceForSurgeryDtoList;

        }

    }
}
