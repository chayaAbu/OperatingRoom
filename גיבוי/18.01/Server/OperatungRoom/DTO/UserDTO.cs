using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int idUser { get; set; }
        public string userName { get; set; }
        public int password { get; set; }
        public bool changeAvailable { get; set; }

        public UserDTO()
        {

        }

        public UserDTO(user u)
        {
            this.idUser = u.idUser;
            this.userName = u.userName;
            this.password = u.password;
            this.changeAvailable = u.changeAvailable;
        }

        public static List<UserDTO> CreateUserDtoList(List<user> userList)
        {
            List<UserDTO> dtoUserList = new List<UserDTO>();
            foreach (var u in userList)
            {
                UserDTO dtoUser = new UserDTO(u);
                dtoUserList.Add(dtoUser);
            }
            return dtoUserList;
        }
    }
}
