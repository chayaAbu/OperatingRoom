using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    class UserDetails
    {
        public string userName { get; set; }
        public int password { get; set; }

        public UserDetails()
        {
                
        }
        public UserDetails(UserDetails ud)
        {
            this.userName = ud.userName;
            this.password = ud.password;
        }

        
    }
}
