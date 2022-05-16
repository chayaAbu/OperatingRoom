using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ClassController : ApiController
    {
        // GET: api/Class
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Class/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Class
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Class/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Class/5
        public void Delete(int id)
        {
        }
    }
}
