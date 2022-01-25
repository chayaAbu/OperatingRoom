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
    
    public partial class surgery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public surgery()
        {
            this.deviceForSurgery = new HashSet<deviceForSurgery>();
            this.scheduling = new HashSet<scheduling>();
        }
    
        public int surgeryCode { get; set; }
        public int idClass { get; set; }
        public int priorityLevel { get; set; }
        public int dangerLevel { get; set; }
        public int idDoctor { get; set; }
        public System.DateTime surgeryDate { get; set; }
    
        public virtual classes classes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deviceForSurgery> deviceForSurgery { get; set; }
        public virtual doctor doctor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<scheduling> scheduling { get; set; }
    }
}
