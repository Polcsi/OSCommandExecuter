using OSCommandExecuter.MVVM.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace OSCommandExecuter.MVVM.View
{
    public partial class HomeView : UserControl
    {
        HomeViewModel _home = new HomeViewModel();
        public HomeView()
        {
            InitializeComponent();
            DataContext = _home;
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            string command = _home.Command.Command;

            if(command == "")
            {
                MessageBox.Show("Please enter a command to execute");
                return;
            }
            // Execute command and get output
            TextBlockOutput.Text = Model.Commands.ExecuteCommandSync(command, (Model.Drive)DrivesComboBox.SelectedItem);
        }

        private void DrivesComboBox_Initialized(object sender, EventArgs e)
        {
            DrivesComboBox.ItemsSource = _home.Drives;
        }
    }
}
