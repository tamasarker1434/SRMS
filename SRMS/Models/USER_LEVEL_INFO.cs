//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SRMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER_LEVEL_INFO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER_LEVEL_INFO()
        {
            this.teachers_info = new HashSet<teachers_info>();
            this.USER_INFO = new HashSet<USER_INFO>();
        }
    
        public long LEVEL_ID { get; set; }
        public string LEVEL_NAME { get; set; }
        public System.DateTime ACTION_DT { get; set; }
        public Nullable<System.DateTime> UPDATE_DT { get; set; }
        public string REMARKS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teachers_info> teachers_info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_INFO> USER_INFO { get; set; }
    }
}
