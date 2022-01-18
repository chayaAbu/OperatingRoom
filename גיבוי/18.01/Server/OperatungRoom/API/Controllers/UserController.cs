using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class UserController : ApiController
    {
        OperatingRoomEntities db = new OperatingRoomEntities();
        // get users
        //[Route("api/Surgery/GetSurgeryFromCurrentDate")]
        //public List<SurgeryDTO> GetSurgeryFromCurrentDate()
        //{
        //    List<SurgeryDTO> s = BL.SurgeryManager.GetSurgeryFromCurrentDate();
        //    return s;
        //}


        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
