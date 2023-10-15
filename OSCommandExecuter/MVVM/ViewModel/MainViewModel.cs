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
        public RelayCommand CommandsViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand HelpViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public HistoryViewModel HistoryVM { get; set; }
        public CommandsViewModel CommandsVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public HelpViewModel HelpVM { get; set; }

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
            CommandsVM = new CommandsViewModel();
            SettingsVM = new SettingsViewModel();
            HelpVM = new HelpViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            HistoryViewCommand = new RelayCommand(o =>
            {
                CurrentView = HistoryVM;
            });

            CommandsViewCommand = new RelayCommand(o =>
            {
                CurrentView = CommandsVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });

            HelpViewCommand = new RelayCommand(o =>
            {
                CurrentView = HelpVM;
            });
        }
    }
}
