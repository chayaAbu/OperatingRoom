using BL.Models;
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
        public static UserDTO LoginUser(UserDetails userDetails)
        {
            user userFromTable = db.GetDbSet<user>().Where(U => U.userName==userDetails.userName &&U.password==userDetails.password).FirstOrDefault();
            if (userFromTable == null)
                return null;
            else
                return new UserDTO(userFromTable);
            
        }
    }
}
