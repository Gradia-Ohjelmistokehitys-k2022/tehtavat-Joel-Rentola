using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAssignment.ViewModel
{
    public class BaseViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler ? PropertyChanged;

        protected void INotifyPropertyChanged(string propertyName)
        {
            PropertyChanged ?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
