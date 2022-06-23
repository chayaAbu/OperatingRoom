using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RoomManager
    {
        static DBConection db = new DBConection();
        public static List<RoomDTO> GetClearRoom()
        {
            List<room> roomsFromTable = db.GetDbSet<room>().Where(R => R.isFull == false).ToList();
            List<RoomDTO> CreateRoomDtoList = RoomDTO.CreateRoomDtoList(roomsFromTable);
            return CreateRoomDtoList;

        }
        public static List<RoomDTO> GetAllRoom()
        {
            List<room> roomsFromTable = db.GetDbSet<room>().Where(R => R.date !=DateTime.Today).ToList();
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
        public static RoomDTO UpdateRoom(RoomDTO UPRoom)
        {
            room updRoom = UPRoom.RoomToTable();
            db.Execute<room>(updRoom, DBConection.ExecuteActions.Update);
            //AddRoom.surgeryCode = newRoom.surgeryCode;
            return UPRoom;


        }
    }
}
