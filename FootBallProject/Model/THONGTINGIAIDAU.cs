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
    
    public partial class THONGTINGIAIDAU
    {
        public int IDGIAIDAU { get; set; }
        public string IDDOIBONG { get; set; }
        public Nullable<int> WIN { get; set; }
        public Nullable<int> DRAW { get; set; }
        public Nullable<int> LOSE { get; set; }
        public Nullable<int> GA { get; set; }
        public Nullable<int> GD { get; set; }
        public Nullable<int> POINTS { get; set; }
        public string TENDOIBONG
        {
            get
            {
                var qg = DataProvider.ins.DB.DOIBONGs.Find(IDDOIBONG);

                return qg == null ? " " : qg.TEN;
            }
            set { }
        }
        public byte[] HINHANHDOIBONG
        {
            get
            {
                var qg = DataProvider.ins.DB.DOIBONGs.Find(IDDOIBONG);

                return qg == null ? null : qg.HINHANH;
            }
            set { }
        }
        public virtual DOIBONG DOIBONG { get; set; }
        public virtual LEAGUE LEAGUE { get; set; }
    }
}
