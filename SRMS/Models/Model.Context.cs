﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SRMSEntities : DbContext
    {
        public SRMSEntities()
            : base("name=SRMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CLASS_INFO> CLASS_INFO { get; set; }
        public virtual DbSet<course_details> course_details { get; set; }
        public virtual DbSet<COURSE_TAKEN> COURSE_TAKEN { get; set; }
        public virtual DbSet<RESULT_TABLE_MST> RESULT_TABLE_MST { get; set; }
        public virtual DbSet<RESULT_TBL> RESULT_TBL { get; set; }
        public virtual DbSet<STUDENT_INFO> STUDENT_INFO { get; set; }
        public virtual DbSet<SUBJECT_INFO> SUBJECT_INFO { get; set; }
        public virtual DbSet<teachers_info> teachers_info { get; set; }
        public virtual DbSet<USER_INFO> USER_INFO { get; set; }
        public virtual DbSet<USER_LEVEL_INFO> USER_LEVEL_INFO { get; set; }
        public virtual DbSet<USER_PASS_CHANGE_HST> USER_PASS_CHANGE_HST { get; set; }
    }
}
