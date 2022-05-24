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
    }
}
