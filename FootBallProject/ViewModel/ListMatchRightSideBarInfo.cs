using FootBallProject.Model;
using FootBallProject.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootBallProject.ViewModel
{
    class ListMatchRightSideBarInfo : BaseViewModel
    {
        private FootballMatchCard _currentCard;
        public FootballMatchCard CurrentCard
        {
            get { return _currentCard; }
            set
            {
                _currentCard = value;
                OnPropertyChanged();
            }
        }
        private FootballMatchCard _actualCard;
        public FootballMatchCard ActualCard
        {
            get { return _actualCard; }
            set { _actualCard = value; }
        }
        #region command
        private ICommand _confirmEditMatchInfo;
        private ICommand _cancelEditMatchInfo;
        public ICommand CancelEditMatchInfo { get => _cancelEditMatchInfo; set => _cancelEditMatchInfo = value; }
        public ICommand ConfirmEditMatchInfo { get => _confirmEditMatchInfo; set => _confirmEditMatchInfo = value; }
        #endregion

        public ListMatchRightSideBarInfo() { CurrentCard = null; }
        public ListMatchRightSideBarInfo(FootballMatchCard card, bool isCreateNew = false)
        {
            card.InitListTeam();
            CurrentCard = new FootballMatchCard(card.ID, card.DisplayName, card.DisplayPlace, card.DisplayDay, card.CurrentMatch);
            CurrentCard.InitListTeam();
            //CurrentCard.InitListTeam();
            ActualCard = card;
            InitCommand();
        }
        private void InitCommand()
        {

            ConfirmEditMatchInfo = new RelayCommand<object>((p) => { return true; }, (p) => { ConfirmFuntion(); /*MessageBox.Show("Vao command");*/ });
            CancelEditMatchInfo = new RelayCommand<object>((p) => { return true; }, (p) => { CancelFuntion(); });
        }
        private void CancelFuntion()
        {
            CurrentCard = ActualCard;
            //AdminSubjectClassRightSideBarViewModel adminSubjectClassRightSideBarViewModel = AdminSubjectClassRightSideBarViewModel.Instance;
            //adminSubjectClassRightSideBarViewModel.RightSideBarItemViewModel = new AdminSubjectClassRightSideBarItemViewModel(ActualCard);
            ListMatchRightBarViewModel ad = new ListMatchRightBarViewModel();
            ad.RightSideBarItemViewModel = new ListMatchRightSideBarInfo(CurrentCard);
        }
        private void ConfirmFuntion()
        {

            {
                CurrentCard.UpdateFootballMatch();


            }
        }
    }

}
