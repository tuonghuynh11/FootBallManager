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
    
    public partial class USER
    {
        public int ID { get; set; }
        public Nullable<int> IDUSERROLE { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string DISPLAYNAME { get; set; }
        public string EMAIL { get; set; }
        public Nullable<int> IDOTP { get; set; }
        public Nullable<int> IDAVATAR { get; set; }
    
        public virtual OTP OTP { get; set; }
        public virtual USERROLE USERROLE { get; set; }
    }
}