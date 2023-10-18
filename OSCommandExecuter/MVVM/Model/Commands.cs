using OSCommandExecuter.Core;
using System;
using System.Windows;

namespace OSCommandExecuter.MVVM.Model
{
    public class Commands : ObservableObject
    {
        private string _command;

        public string Command
        {
            get { return _command; }
            set
            {
                _command = value;
                OnPropertyChanged("Command");
            }
        }
        public Commands()
        {
            _command = "git --version";
        }
        static public string ExecuteCommandSync(object command, Drive drive)
        {
            try
            {
                string commandPrefix = $"cd / & {drive.VolumeLabel}: &";
                string fullCommand = $"{commandPrefix} {command}";
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + fullCommand);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                return result;
            }
            catch (Exception objException)
            {
                // Show error message box
                MessageBox.Show(objException.ToString());
                return objException.ToString();
            }
        }
    }
}
