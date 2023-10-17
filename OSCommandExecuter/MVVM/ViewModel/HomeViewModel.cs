using OSCommandExecuter.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCommandExecuter.MVVM.ViewModel
{
    public class HomeViewModel
    {
        public Commands Command { get; set; }
        public HomeViewModel() 
        {
            Command = new Commands();    
        }
    }
}
