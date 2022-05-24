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
    public class RoomController : ApiController
    {
        // clear room
        [Route("api/Room/GetClearRoom")]
        public List<RoomDTO> GetClearRoom()
        {
            List<RoomDTO> r = BL.RoomManager.GetClearRoom();
            return r;
        }

        // Emargency case
        [Route("api/Room/GetAllRoom")]
        public List<RoomDTO> GetAllRoom()
        {
            List<RoomDTO> r = BL.RoomManager.GetAllRoom();
            return r;
        }

        // POST: api/Room
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Room/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
        }
    }
}
