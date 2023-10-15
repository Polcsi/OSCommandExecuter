using OSCommandExecuter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCommandExecuter.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand HistoryViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public HistoryViewModel HistoryVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        { 
            HomeVM = new HomeViewModel();
            HistoryVM = new HistoryViewModel();
            SettingsVM = new SettingsViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            HistoryViewCommand = new RelayCommand(o =>
            {
                CurrentView = HistoryVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });
        }
    }
}
