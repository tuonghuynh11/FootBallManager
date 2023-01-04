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
    using System.Windows.Media;
    public partial class CAUTHU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAUTHU()
        {
            this.CHUYENNHUONGs = new HashSet<CHUYENNHUONG>();
            this.ITEMs = new HashSet<ITEM>();
            this.THAMGIAs = new HashSet<THAMGIA>();
        }
    
        public int ID { get; set; }
        public string IDDOIBONG { get; set; }
        public Nullable<int> IDQUOCTICH { get; set; }
        public string HOTEN { get; set; }
        public Nullable<int> TUOI { get; set; }
        public Nullable<int> SOGIAI { get; set; }
        public Nullable<int> SOBANTHANG { get; set; }
        public byte[] HINHANH { get; set; }
        public string CHANTHUAN { get; set; }
        public string THETRANG { get; set; }
        public string VITRI { get; set; }
        public Nullable<int> SOAO { get; set; }
        public string CHIEUCAO { get; set; }
        public string CANNANG { get; set; }
        public string QUOCGIA
        {
            get
            {
                var qg = DataProvider.ins.DB.QUOCTICHes.Find(IDQUOCTICH);

                return qg == null ? " " : qg.TENQUOCGIA;
            }
            set { }
        }

        public string VAITRO
        {
            get
            {
                var qg = DataProvider.ins.DB.DOIHINHCHINHs.Find(IDDOIBONG, ID);

                return qg == null ? " " : qg.VAITRO;
            }
            set { }
        }

        public int STT { get; set; }
        public string VITRIAO { get; set; }

        public string _VAITROAO { get; set; }
        public string VAITROAO
        {
            get
            {

                return _VAITROAO;

            }
            set
            {

                _VAITROAO = value;
            }
        }
        public System.Windows.Media.Brush brush
        {
            get
            {
                Random r = new Random();

                SolidColorBrush brush = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
                return brush;
            }

            set
            {
            }
        }

        public string TENDOIBONG
        {
            get
            {
                var qg = DataProvider.ins.DB.DOIBONGs.Find(IDDOIBONG);

                return qg == null ? " " : qg.TEN;
            }
            set { }
        }
        public Nullable<long> GIATRICAUTHU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHUYENNHUONG> CHUYENNHUONGs { get; set; }
        public virtual DOIBONG DOIBONG { get; set; }
        public virtual QUOCTICH QUOCTICH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEM> ITEMs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THAMGIA> THAMGIAs { get; set; }
    }
}
