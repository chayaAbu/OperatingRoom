using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DeviceForSurgeryDTO
    {
        public int idDFS { get; set; }
        public int idDevice { get; set; }
        public int surgeryCode { get; set; }

        public DeviceForSurgeryDTO()
        {

        }
        public DeviceForSurgeryDTO(deviceForSurgery dfs)
        {
            this.idDFS = dfs.idDFS;
            this.idDevice = dfs.idDevice;
            this.surgeryCode = dfs.surgeryCode;

        }

        public static List<DeviceForSurgeryDTO> CreateDeviceForSurgeryDtoList(List<deviceForSurgery> deviceForSurgeryList)
        {
            List<DeviceForSurgeryDTO> dtoDeviceForSurgeryList = new List<DeviceForSurgeryDTO>();
            foreach (var c in deviceForSurgeryList)
            {
                DeviceForSurgeryDTO dtoDeviceForSurgery = new DeviceForSurgeryDTO(c);
                dtoDeviceForSurgeryList.Add(dtoDeviceForSurgery);
            }
            return dtoDeviceForSurgeryList;
        }
        public deviceForSurgery SurgeryToTable()
        {
            deviceForSurgery dfs = new deviceForSurgery();
            dfs.idDFS = idDFS;
            dfs.idDevice = idDevice;
            dfs.surgeryCode = surgeryCode;
            return dfs;
        }
    }
}
