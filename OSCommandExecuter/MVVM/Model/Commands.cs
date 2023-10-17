using OSCommandExecuter.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        static public string ExecuteCommandSync(object command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

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
                // Log the exception
                return objException.ToString();
            }
        }
        //static public void ExecuteCommandAsync(string command)
        //{
        //    try
        //    {
        //        //Asynchronously start the Thread to process the Execute command request.
        //        Thread objThread = new Thread(new ParameterizedThreadStart(ExecuteCommandSync));
        //        //Make the thread as background thread.
        //        objThread.IsBackground = true;
        //        //Set the Priority of the thread.
        //        objThread.Priority = ThreadPriority.AboveNormal;
        //        //Start the thread.
        //        objThread.Start(command);
        //    }
        //    catch (ThreadStartException objException)
        //    {
        //        // Log the exception
        //    }
        //    catch (ThreadAbortException objException)
        //    {
        //        // Log the exception
        //    }
        //    catch (Exception objException)
        //    {
        //        // Log the exception
        //    }
        //}
    }
}
