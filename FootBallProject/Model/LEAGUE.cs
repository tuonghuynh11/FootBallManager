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
    
    public partial class LEAGUE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LEAGUE()
        {
            this.ROUNDs = new HashSet<ROUND>();
            this.TEAMOFLEAGUEs = new HashSet<TEAMOFLEAGUE>();
            this.THONGTINGIAIDAUs = new HashSet<THONGTINGIAIDAU>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> NGAYBATDAU { get; set; }
        public Nullable<System.DateTime> NGAYKETTHUC { get; set; }
        public string TENGIAIDAU { get; set; }
        public Nullable<int> IDQUOCGIA { get; set; }
        public byte[] HINHANH { get; set; }
    
        public virtual QUOCTICH QUOCTICH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROUND> ROUNDs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEAMOFLEAGUE> TEAMOFLEAGUEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THONGTINGIAIDAU> THONGTINGIAIDAUs { get; set; }
    }
}
