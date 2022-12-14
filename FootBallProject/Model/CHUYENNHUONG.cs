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
    
    public partial class CHUYENNHUONG
    {
        public int ID { get; set; }
        public Nullable<int> IDCAUTHU { get; set; }
        public string IDDOIMUA { get; set; }

        public string TENCAUTHU
        {
            get
            {
                var qg = DataProvider.ins.DB.CAUTHUs.Find(IDCAUTHU);

                return qg == null ? " " : qg.HOTEN;
            }
            set { }
        }
        public string TENDOIBAN
        {
            get
            {
                var db = DataProvider.ins.DB.CAUTHUs.Find(IDCAUTHU);
                var qg = DataProvider.ins.DB.DOIBONGs.Find(db.IDDOIBONG);

                return qg == null ? " " : qg.TEN;
            }
            set { }
        }
        public byte[] HINHANHDOIBAN
        {
            get
            {
                var db = DataProvider.ins.DB.CAUTHUs.Find(IDCAUTHU);
                var qg = DataProvider.ins.DB.DOIBONGs.Find(db.IDDOIBONG);

                return qg == null ? null : qg.HINHANH;
            }
            set { }
        }
        public string TENDOIMUA
        {
            get
            {
                var qg = DataProvider.ins.DB.DOIBONGs.Find(IDDOIMUA);

                return qg == null ? " " : qg.TEN;
            }
            set { }
        }
        public byte[] HINHANHDOIMUA
        {
            get
            {
                var qg = DataProvider.ins.DB.DOIBONGs.Find(IDDOIMUA);

                return qg == null ? null : qg.HINHANH;
            }
            set { }
        }
        public Nullable<long> GIATRICAUTHU
        {
            get
            {
                var qg = DataProvider.ins.DB.CAUTHUs.Find(IDCAUTHU);

                return qg == null ? 0 : qg.GIATRICAUTHU;
            }
            set { }
        }
        public string IDDOIBAN
        {
            get
            {
                var qg = DataProvider.ins.DB.CAUTHUs.Find(IDCAUTHU);

                return qg == null ? " " : qg.IDDOIBONG;
            }
            set { }
        }
        public virtual CAUTHU CAUTHU { get; set; }
        public virtual DOIBONG DOIBONG { get; set; }
    }
}
