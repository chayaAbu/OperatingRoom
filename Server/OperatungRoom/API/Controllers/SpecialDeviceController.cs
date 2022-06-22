using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SpecialDeviceController : ApiController
    {
        OpreatingRoomEntities1 db = new OpreatingRoomEntities1();
        // get all  special device
        [Route("api/SpecialDevice/GetClearRoom")]
        public List<SpecialDeviceDTO> GetAllSpecialDevice()
        {
            List<SpecialDeviceDTO> s = BL.SpecialDeviceManager.GetAllSpecialDevice();
            return s;
        }

        // add device
        [Route("api/SpecialDevice/AddSpecialDevice")]
        [HttpPost]
        public string AddSpecialDevice(SpecialDeviceDTO newSpecialDevice)
        {
            SpecialDeviceDTO s = BL.SpecialDeviceManager.AddNewDevice(newSpecialDevice);
            return "succes"+s.deviceName;
        }
        // POST: api/SpecialDevice
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SpecialDevice/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SpecialDevice/5
        public void Delete(int id)
        {
        }
    }
}
