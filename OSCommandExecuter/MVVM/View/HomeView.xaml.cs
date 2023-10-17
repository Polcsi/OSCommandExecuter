using OSCommandExecuter.MVVM.Model;
using OSCommandExecuter.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OSCommandExecuter.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
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
            // Get Entered command from 'TextBoxCommand' Input
            string command = _home.Command.Command;

            if(command == "")
            {
                MessageBox.Show("Please enter a command to execute");
                return;
            }
            // Execute command and get output
            TextBlockOutput.Text = Model.Commands.ExecuteCommandSync(command);
        }
    }
}
