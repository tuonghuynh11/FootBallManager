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
    
    public partial class TRANDAU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRANDAU()
        {
            this.THAMGIAs = new HashSet<THAMGIA>();
        }
    
        public int ID { get; set; }
        public string LOAI { get; set; }
        public string IDDOI1 { get; set; }
        public string IDDOI2 { get; set; }
        public Nullable<int> IDDIADIEM { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }
        public Nullable<System.TimeSpan> GIO { get; set; }
        public Nullable<int> IDGIAIDAU { get; set; }

        public string TENDOIBONG1
        {
            get
            {
                var qg = DataProvider.ins.DB.DOIBONGs.Find(IDDOI1);

                return qg == null ? " " : qg.TEN;
            }
            set { }
        }
        public byte[] HINHANHDOIBONG1
        {
            get
            {
                var qg = DataProvider.ins.DB.DOIBONGs.Find(IDDOI1);

                return qg == null ? null : qg.HINHANH;
            }
            set { }
        }

        public string TENDOIBONG2
        {
            get
            {
                var qg = DataProvider.ins.DB.DOIBONGs.Find(IDDOI2);

                return qg == null ? " " : qg.TEN;
            }
            set { }
        }
        public byte[] HINHANHDOIBONG2
        {
            get
            {
                var qg = DataProvider.ins.DB.DOIBONGs.Find(IDDOI2);

                return qg == null ? null : qg.HINHANH;
            }
            set { }
        }


        public string TENDIADIEM
        {
            get
            {
                var qg = DataProvider.ins.DB.DIADIEMs.Find(IDDIADIEM);

                return qg == null ? " " : qg.TENDIADIEM;
            }
            set { }
        }
        public virtual DIADIEM DIADIEM { get; set; }
        public virtual DOIBONG DOIBONG { get; set; }
        public virtual DOIBONG DOIBONG1 { get; set; }
        public virtual GIAIDAU GIAIDAU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THAMGIA> THAMGIAs { get; set; }
    }
}