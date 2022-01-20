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
        public UserDetails(string name,int pass)
        {
            this.userName =name;
            this.password =pass;
        }

        
    }
}
