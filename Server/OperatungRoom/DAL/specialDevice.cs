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
    
    public partial class specialDevice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public specialDevice()
        {
            this.deviceForSurgery = new HashSet<deviceForSurgery>();
        }
    
        public int IdDevice { get; set; }
        public string deviceName { get; set; }
        public bool isAvailable { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<int> amount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deviceForSurgery> deviceForSurgery { get; set; }
    }
}
