//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootBallProject.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TAPLUYEN
    {
        public int ID { get; set; }
        public Nullable<int> IDNGUOIQUANLY { get; set; }
        public string IDDOIBONG { get; set; }
        public string TRANGTHAI { get; set; }
        public Nullable<System.DateTime> THOIGIANBATDAU { get; set; }
        public Nullable<System.DateTime> THOIGIANKETTHUC { get; set; }
        public string HOATDONG { get; set; }
        public string GHICHU { get; set; }
    
        public virtual DOIBONG DOIBONG { get; set; }
        public virtual HUANLUYENVIEN HUANLUYENVIEN { get; set; }
    }
}
