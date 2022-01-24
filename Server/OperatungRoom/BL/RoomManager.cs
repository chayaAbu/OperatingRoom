using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class RoomManager
    {
        static DBConection db = new DBConection();
        public static List<RoomDTO> GetClearRoom (int numClass)
        {
            List<room> roomsFromTable = db.GetDbSet<room>().Where(R => R.isFull == false&&R.idClass==numClass).ToList();
            List<RoomDTO> CreateRoomDtoList = RoomDTO.CreateRoomDtoList(roomsFromTable);
            return CreateRoomDtoList;

        }
        public static RoomDTO AddNewRoom(RoomDTO AddRoom)
        {
            room newRoom = AddRoom.RoomToTable();
            db.Execute<room>(newRoom, DBConection.ExecuteActions.Insert);
            //AddRoom.surgeryCode = newRoom.surgeryCode;
            return AddRoom;


        }
    }
}
