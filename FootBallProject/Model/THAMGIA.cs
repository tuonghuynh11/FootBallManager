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
    
    public partial class THAMGIA
    {
        public int IDTRAN { get; set; }
        public int IDCAUTHU { get; set; }
        public Nullable<int> SOBANTHANG { get; set; }
    
        public virtual CAUTHU CAUTHU { get; set; }
        public virtual TRANDAU TRANDAU { get; set; }
    }
}