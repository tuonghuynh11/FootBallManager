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
    using System.Data.SqlClient;
    using System.Linq;

    public partial class FOOTBALLMATCH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FOOTBALLMATCH()
        {
            this.THAMGIAs = new HashSet<THAMGIA>();
            this.THONGTINTRANDAUs = new HashSet<THONGTINTRANDAU>();
        }
    
        public int ID { get; set; }
        public string TENTRANDAU { get; set; }
        public Nullable<int> VONGBANG { get; set; }
        public Nullable<int> IDVONG { get; set; }
        public Nullable<int> DIADIEM { get; set; }
        public Nullable<System.DateTime> THOIGIAN { get; set; }
        public string IDDOI1
        {
            get
            {

                THONGTINTRANDAU td = DataProvider.ins.DB.Database.SqlQuery<THONGTINTRANDAU>("SELECT TOP(1) * FROM THONGTINTRANDAU WHERE IDTRANDAU = @ID ORDER BY ID DESC", new SqlParameter("@ID", ID)).FirstOrDefault<THONGTINTRANDAU>();
                return td == null ? " " : td.IDDOIBONG;
            }
            set { }
        }
        public string IDDOI2
        {
            get
            {
                THONGTINTRANDAU td = DataProvider.ins.DB.Database.SqlQuery<THONGTINTRANDAU>("SELECT TOP(1) * FROM THONGTINTRANDAU WHERE IDTRANDAU = @ID ORDER BY ID ASC", new SqlParameter("@ID", ID)).FirstOrDefault<THONGTINTRANDAU>();
                return td == null ? " " : td.IDDOIBONG;
            }
            set { }
        }
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
                var qg = DataProvider.ins.DB.DIADIEMs.Find(DIADIEM);

                return qg == null ? " " : qg.TENDIADIEM;
            }
            set { }
        }
        public virtual DIADIEM DIADIEM1 { get; set; }
        public virtual ROUND ROUND { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THAMGIA> THAMGIAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THONGTINTRANDAU> THONGTINTRANDAUs { get; set; }
    }
}
