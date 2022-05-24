﻿using DAL;
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
    public class DeviceForSurgeryController : ApiController
    {
        OpreatingRoomEntities db = new OpreatingRoomEntities();
        // get all device request
        [Route("api/DeviceForSurgery/GetAllRequest")]
        public List<DeviceForSurgeryDTO> GetAllRequest()
        {
            List<DeviceForSurgeryDTO> d = BL.DeviceForSurgeryManager.GetAllRequest();
            return d;
        }

        // add request
        [Route("api/DeviceForSurgery/AddRequest")]
        [HttpPost]
        public string AddRequest (DeviceForSurgeryDTO newdeviceForSurgery)
        {
            deviceForSurgery d = newdeviceForSurgery.DeviceToTable();
            db.deviceForSurgery.Add(d);
            db.SaveChanges();
            return "succes";
        }

        // POST: api/DeviceForSurgery
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DeviceForSurgery/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DeviceForSurgery/5
        public void Delete(int id)
        {
        }
    }
}
