using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAssignment.ViewModel
{
    public class MainViewModel
    {
        public BaseViewModel currentModel { get; }

        public MainViewModel()
        {
            currentModel = new ApodViewModel();
        }
    }
}
