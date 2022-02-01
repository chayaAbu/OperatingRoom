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
        [HttpPost]
        public UserDTO LoginUser(string name,int password)
        {
            UserDTO u = BL.UserManager.LoginUser(name,password);
           return u;
        }


        // register user
        [Route("api/User/RegisterUser")]
        [HttpPost]
        public string RegisterUser(UserDTO newUser)
        {
            user u = newUser.UserToTable();
            db.user.Add(u);
            db.SaveChanges();
            return "succes";
        }

        // update user
        [Route("api/User/UpdateUser")]
        [HttpPost]
        public string UpdateUser(UserDTO updateUser)
        {
            user u = updateUser.UserToTable();
            //db.user.Update(u);
            db.SaveChanges();
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
