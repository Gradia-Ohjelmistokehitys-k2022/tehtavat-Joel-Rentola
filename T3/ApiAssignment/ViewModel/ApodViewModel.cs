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
        private int _fontSize;
        private List<int> _fontSizes;
        private DateTime _dateToday;
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
        public int FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                INotifyPropertyChanged(nameof(FontSize));
            }
        }
        public List<int> FontSizes
        {
            get => _fontSizes;
            set
            {
                _fontSizes = value;
                INotifyPropertyChanged(nameof(FontSizes));
            }
        }
        public DateTime DateToday
        {
            get => _dateToday;
            set
            {
                _dateToday = value;
                INotifyPropertyChanged(nameof(DateToday));
            }
        }

        private string _mediaSource;
        public string MediaSource
        {
            get => _mediaSource;
            set
            {
                _mediaSource = value;
                INotifyPropertyChanged(nameof(MediaSource));
            }
        }


        public ApodViewModel ()
        {
            FetchData = new TestCommand(func);
            ImgSource = new BitmapImage(new Uri("https://static.wikia.nocookie.net/freestylerp/images/5/5f/Placeholder.jpg/revision/latest?cb=20240111110709"));
            FontSizes = Enumerable.Range(12, 15).ToList();
            FontSize = 20;
            DtpValue = DateTime.Now;
        }
        async Task func()
        {
            //MessageBox.Show($"apod?api_key=DEMO_KEY&date={DtpValue.ToString("yyyy-MM-dd")}");
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
                ImgSource = new BitmapImage(new Uri(resultData.url));
                MediaSource = resultData.url;
                Explanation = resultData.explanation;
            }
        }
    }
}
