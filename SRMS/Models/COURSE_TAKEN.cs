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
    
    public partial class COURSE_TAKEN
    {
        public long ID { get; set; }
        public long STD_ID { get; set; }
        public long SUB_ID { get; set; }
        public string COURSE_TYPE { get; set; }
        public long ACTION_BY { get; set; }
        public System.DateTime ACTION_DATE { get; set; }
        public Nullable<long> UPDATE_BY { get; set; }
        public Nullable<System.DateTime> UPDATE_DATE { get; set; }
    
        public virtual STUDENT_INFO STUDENT_INFO { get; set; }
        public virtual SUBJECT_INFO SUBJECT_INFO { get; set; }
    }
}
