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
    
    public partial class RESULT_TABLE_MST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESULT_TABLE_MST()
        {
            this.RESULT_TBL = new HashSet<RESULT_TBL>();
        }
    
        public long RESULT_ID { get; set; }
        public Nullable<long> TEACHER_ID { get; set; }
        public Nullable<long> SUB_ID { get; set; }
        public string EXAM_TYPE { get; set; }
        public long ACTION_BY { get; set; }
        public System.DateTime ACTION_DATE { get; set; }
        public Nullable<long> UPDATE_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
        public string STATUS { get; set; }
        public Nullable<System.DateTime> ACADEMIC_YEAR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESULT_TBL> RESULT_TBL { get; set; }
    }
}
