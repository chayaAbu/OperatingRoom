using DAL;
using DTO;
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
        // login users
        [Route("api/User/LoginUser")]
        public UserDTO LoginUser()
        {
            UserDTO  u = BL.UserManager.LoginUser();
           return u;
        }


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
