using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class SchedulingController : ApiController
    {
        // GET: api/Scheduling
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Scheduling/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Scheduling
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Scheduling/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Scheduling/5
        public void Delete(int id)
        {
        }
    }
}
