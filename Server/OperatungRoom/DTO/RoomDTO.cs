using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RoomDTO
    {
        public int idRoom { get; set; }
        public bool isFull { get; set; }
        public System.DateTime date { get; set; }
        public int idClass { get; set; }
        public int counts { get; set; }

        public RoomDTO()
        {

        }

        public RoomDTO(room r)
        {
            this.idRoom = r.idRoom;
            this.idClass = r.idClass;
            this.isFull = r.isFull;
            this.date = r.date;
            this.counts = r.counts;
            
        }
        public static List<RoomDTO> CreateRoomDtoList(List<room> roomList)
        {
            List<RoomDTO> dtoRoomList = new List<RoomDTO>();
            foreach (var r in roomList)
            {
                RoomDTO dtoRoom = new RoomDTO(r);
                dtoRoomList.Add(dtoRoom);
            }
            return dtoRoomList;
        }
        public room RoomToTable()
        {
            room r = new room();
            r.idRoom = idRoom;
            r.idClass = idClass;
            r.isFull = isFull;
            r.date = date;
            r.counts = counts;
            return r;
        }
    }
}
