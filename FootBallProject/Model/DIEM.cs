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
    
    public partial class DIEM
    {
        public string IDDOIBONG { get; set; }
        public int IDGIAIDAU { get; set; }
        public Nullable<int> SODIEM { get; set; }
    
        public virtual DOIBONG DOIBONG { get; set; }
        public virtual GIAIDAU GIAIDAU { get; set; }
    }
}
