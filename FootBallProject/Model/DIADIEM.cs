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
    
    public partial class DIADIEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIADIEM()
        {
            this.DOIBONGs = new HashSet<DOIBONG>();

            this.TRANDAUs = new HashSet<TRANDAU>();
            this.FOOTBALLMATCHes = new HashSet<FOOTBALLMATCH>();

        }
    
        public int ID { get; set; }
        public string TENDIADIEM { get; set; }
        public Nullable<int> IDQUOCGIA { get; set; }
    
        public virtual QUOCTICH QUOCTICH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOIBONG> DOIBONGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<TRANDAU> TRANDAUs { get; set; }

        public virtual ICollection<FOOTBALLMATCH> FOOTBALLMATCHes { get; set; }

    }
}
