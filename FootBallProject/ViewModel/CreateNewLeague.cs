using FootBallProject.Model;
using FootBallProject.Object;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FootBallProject.ViewModel
{
    public class CreateNewLeague:BaseViewModel, INotifyDataErrorInfo
    {
        #region error
        public bool HasErrors => _errorBaseViewModel.HasErrors;
        private readonly ErrorBaseViewModel _errorBaseViewModel;
        private void ErrorBaseViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorBaseViewModel.GetErrors(propertyName);
        }
        private bool IsValid(string propertyName)
        {
            return !string.IsNullOrEmpty(propertyName) && !string.IsNullOrWhiteSpace(propertyName);
        }
        #endregion
        private string _displayName;
        private DateTime _startTime;
        private DateTime _endTime;
        private string _soDoi;
        private LEAGUE league;
        private static CreateNewLeague _instance;
        public static CreateNewLeague Instance
        {
            get { if (_instance == null) _instance = new CreateNewLeague(); return _instance; }
            set { _instance = value; }
        }
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value;
                _errorBaseViewModel.ClearErrors();
                if (!IsValid(DisplayName))
                {
                    _errorBaseViewModel.AddError(nameof(DisplayName), "Vui lòng nhập tên giải đấu!");
                }

                OnPropertyChanged(); }
        }
        public LEAGUE League
        {
            get { return league; }
            set { league = value;
                OnPropertyChanged(); }
        }
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value;
                _errorBaseViewModel.ClearErrors();
                if (StartTime == null)
                {
                    _errorBaseViewModel.AddError(nameof(StartTime), "Vui lòng chọn thời gian bắt đầu!");
                }

                OnPropertyChanged(); }
        }
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value;
                _errorBaseViewModel.ClearErrors();
                if (EndTime == null)
                {
                    _errorBaseViewModel.AddError(nameof(EndTime), "Vui lòng chọn thời gian kết thúc!");
                }

                OnPropertyChanged(); }
        }
        public string SoDoi
        {
            get { return _soDoi; }
            set { _soDoi = value;
                _errorBaseViewModel.ClearErrors();
                if (!IsValid(SoDoi))
                {
                    _errorBaseViewModel.AddError(nameof(SoDoi), "Vui lòng chọn số đội!");
                }

                OnPropertyChanged(); }
        }
        private QUOCTICH quocTich;
        public QUOCTICH QuocTich
        {
            get { return quocTich; }
            set { quocTich = value;
                OnPropertyChanged(); }
        }
        private DIADIEM diadiem;
        public DIADIEM Diadiem
        {
            get { return diadiem; }
            set { diadiem = value; OnPropertyChanged(); }
        }
        public ObservableCollection<string> soluongdois = new ObservableCollection<string>() { "4", "8", "16", "32", "64" };
        private string selectedSoluong;
        public string SelectedSoluong
        {
            get { return selectedSoluong; }
            set { selectedSoluong = value; OnPropertyChanged(); }
        }
        private ObservableCollection<DIADIEM> diadiemlist = new ObservableCollection<DIADIEM>();
        public ObservableCollection<DIADIEM> DiaDiemList
        {
            get { return diadiemlist; }
            set { diadiemlist = value;}
        }
        private ObservableCollection<QUOCTICH> quocgialist = new ObservableCollection<QUOCTICH>();
        public ObservableCollection<QUOCTICH> QuocGiaList
        {
            get { return quocgialist; }
            set {   quocgialist = value; }
        }

        public ICommand Next { get; set; }
        public ICommand Return { get; set; }
        public CreateNewLeague()
        {
            selectedSoluong= "4";
            Instance= this;
            _errorBaseViewModel = new ErrorBaseViewModel();
            _errorBaseViewModel.ErrorsChanged += ErrorBaseViewModel_ErrorsChanged;

            var list = DataProvider.ins.DB.DIADIEMs.ToList();
            foreach(var item in list)
            {
                diadiemlist.Add(item);
            }
            DiaDiemList = diadiemlist;
            var list1 = DataProvider.ins.DB.QUOCTICHes.ToList();
            foreach (var item in list1)
            {
                quocgialist.Add(item);
            }
            Enable = false;
            QuocGiaList = quocgialist;
            Next = new RelayCommand<object>((p) => { return true; }, (p) => { GoNext(); ListofLeagueViewModel.Instance.GoNext(); });
            Return = new RelayCommand<object>((p) => { return true; }, (p) => { ListofLeagueViewModel.Instance.Return(); });
        }
        private bool enable;
        public bool Enable
        {
            get { return enable; }
            set { enable = value; OnPropertyChanged(); }
        }
        public void CanGoNext()
        {
            if (DisplayName != null && StartTime != null && EndTime != null && QuocTich != null) Enable= true;
        }
        public void GoNext()
        {
            Instance = this;
            League = new LEAGUE()
            {
                TENGIAIDAU = DisplayName,
                NGAYBATDAU = StartTime,
                NGAYKETTHUC = EndTime,
                IDQUOCGIA = QuocTich.ID,
            };
            DataProvider.ins.DB.LEAGUEs.Add(League);
            DataProvider.ins.DB.SaveChanges();
        }
    }
}
