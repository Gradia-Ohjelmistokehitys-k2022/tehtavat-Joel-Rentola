using ApiAssignment.Commands;
using ApiAssignment.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Net.WebRequestMethods;

namespace ApiAssignment.ViewModel
{
    public class ApodViewModel : BaseViewModel
    {
        public ICommand FetchData {  get; }
        private ImageSource _imgSource;
        private string _explanation;
        private DateTime _dtpValue;
        public ImageSource ImgSource { 
            get => _imgSource;
            set
            {
                _imgSource = value;
                INotifyPropertyChanged(nameof(ImgSource));
            }
        }
        public string Explanation
        {
            get => _explanation;
            set
            {
                _explanation = value;
                INotifyPropertyChanged(nameof(Explanation));
            }
        }
        public DateTime DtpValue
        {
            get => _dtpValue;
            set
            {
                _dtpValue = value;
                INotifyPropertyChanged(nameof(DtpValue));
            }
        }
        public ApodViewModel ()
        {
            FetchData = new TestCommand(func);
            ImgSource = new BitmapImage(new Uri("https://img.goodfon.com/wallpaper/big/3/9c/space-planet-landscape-wallpapers-1920-x-1080.webp"));
        }
        async Task func()
        {
            await APIconnection.FetchData($"apod?api_key=DEMO_KEY&date={DtpValue.ToString("yyyy-MM-dd")}");
            UpdateThings();
        }

        private void UpdateThings()
        {
            if (APIconnection.resData == null)
            {
                ImgSource = new BitmapImage(new Uri("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmWru8q17zpOzzzT1s475ZS_8fOL1GS0teSw&s"));
            }
            else
            {
                ResultData resultData = APIconnection.GetData();
                ImgSource = new BitmapImage(new Uri(resultData.hdurl));
                Explanation = resultData.explanation;
            }
        }
    }
}
