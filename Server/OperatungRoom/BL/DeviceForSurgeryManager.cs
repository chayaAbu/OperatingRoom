using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class DeviceForSurgeryManager
    {
     static DBConection db = new DBConection();

        public void requestDevice(DeviceForSurgeryDTO setNewRequestForDevice ) {
            deviceForSurgery newRequest=setNewRequestForDevice.DeviceToTable();
            db.Execute<deviceForSurgery>(newRequest, DBConection.ExecuteActions.Insert);
        }
        
        
        

    }
}
