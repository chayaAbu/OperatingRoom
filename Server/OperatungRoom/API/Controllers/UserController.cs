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
    public class UserController : ApiController
    {
        OpreatingRoomEntities1 db = new OpreatingRoomEntities1();
        // login users
        [Route("api/User/LoginUser")]
        [HttpPost]
        public UserDTO LoginUser(UserDTO check)
        {
            UserDTO u = BL.UserManager.LoginUser(check);
           return u;
        }


        // register user
        [Route("api/User/RegisterUser")]
        [HttpPost]
        public string RegisterUser(UserDTO newUser)
        {
            UserDTO u = BL.UserManager.RegisterUser(newUser);
          
            return "succes"+""+u.userName;
        }

        // update user
        [Route("api/User/UpdateUser")]
        [HttpPost]
        public string UpdateUser(UserDTO updateUser)
        {
            UserDTO u = BL.UserManager.UpdateUser(updateUser);
          
            return "succes";
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
