using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class UserManager
    {
        static DBConection db = new DBConection();
        public static List<UserDTO> LoginUser(user u)
        {
            List<user> userFromTable = db.GetDbSet<user>().Where(U => U.idUser==u.idUser ).ToList();
            List<UserDTO> CreateUserDtoList = UserDTO.CreateUserDtoList(userFromTable);
           return CreateUserDtoList;
            

        }
    }
}
