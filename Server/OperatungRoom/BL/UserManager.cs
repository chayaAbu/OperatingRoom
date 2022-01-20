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
    public class UserManager
    {
        static DBConection db = new DBConection();
        public static UserDTO LoginUser(string name,int password)
        {
            user userFromTable = db.GetDbSet<user>().FirstOrDefault(U => U.userName==name &&U.password==password);
            if (userFromTable == null)
                return null;
            else
                return new UserDTO(userFromTable);
            
        }

        public static UserDTO RegisterUser(UserDTO AddUser)
        {
            user newLogin = AddUser.UserToTable();
            db.Execute<user>(newLogin, DBConection.ExecuteActions.Insert);
            AddUser.idUser = newLogin.idUser;
            return AddUser;


        }
    }
}
