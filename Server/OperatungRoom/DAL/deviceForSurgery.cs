//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class deviceForSurgery
    {
        public int idDFS { get; set; }
        public int idDevice { get; set; }
        public int surgeryCode { get; set; }
    
        public virtual specialDevice specialDevice { get; set; }
        public virtual surgery surgery { get; set; }
    }
}
