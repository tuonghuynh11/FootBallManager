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
    
    public partial class HUANLUYENVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HUANLUYENVIEN()
        {
            this.Notifications = new HashSet<Notification>();
            this.TAPLUYENs = new HashSet<TAPLUYEN>();
        }
    
        public int ID { get; set; }
        public string IDDOIBONG { get; set; }
        public Nullable<int> IDQUOCTICH { get; set; }
        public string HOTEN { get; set; }
        public Nullable<int> TUOI { get; set; }
        public string GMAIL { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public string CHUCVU { get; set; }
        public byte[] HINHANH { get; set; }
    
        public virtual DOIBONG DOIBONG { get; set; }
        public virtual QUOCTICH QUOCTICH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notifications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAPLUYEN> TAPLUYENs { get; set; }
    }
}
