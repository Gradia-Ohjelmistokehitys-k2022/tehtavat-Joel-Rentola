using ApiAssignment.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ApiAssignment.ViewModel
{
    public class ApodViewModel:BaseViewModel
    {
        public ICommand FetchData {  get; }

        public ApodViewModel ()
        {
            FetchData = new TestCommand(func);
        }
        async Task func()
        {
            MessageBox.Show("sakjkdfjalksjfl");
        }
    }
}
