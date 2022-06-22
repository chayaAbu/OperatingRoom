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
    public class RoomController : ApiController
    {
        OpreatingRoomEntities1 db = new OpreatingRoomEntities1();
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

        // add room
        [Route("api/Room/AddRoom")]
        [HttpPost]
        public string AddRoom(RoomDTO newRoom)
        {
            RoomDTO r = BL.RoomManager.AddNewRoom(newRoom);
            return "succes" + "" + r.idRoom;
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
