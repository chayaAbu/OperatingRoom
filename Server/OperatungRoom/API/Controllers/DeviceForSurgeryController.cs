using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DeviceForSurgeryController : ApiController
    {
        // GET: api/DeviceForSurgery
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DeviceForSurgery/5
        public string Get(int id)
        {
            return "value";
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
