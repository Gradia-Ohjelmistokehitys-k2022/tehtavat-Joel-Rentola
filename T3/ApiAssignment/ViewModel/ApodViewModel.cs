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
using System.Drawing;
using static System.Net.WebRequestMethods;
using System.Drawing.Text;
using System.Windows.Controls;

namespace ApiAssignment.ViewModel
{
    public class ApodViewModel : BaseViewModel
    {
        public ICommand FetchData {  get; }
        public ICommand PreviousBtnCommand { get; }
        public ICommand NextBtnCommand { get; }
        private ImageSource _imgSource;
        private string _explanation;
        private DateTime _dtpValue;
        private int _fontSize;
        private List<int> _fontSizes;
        private string _selectedFont;
        private List<string> _selectableFonts = new List<string>();
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
        public string SelectedFont
        {
            get => _selectedFont;
            set
            {
                _selectedFont = value;
                INotifyPropertyChanged(nameof(SelectedFont));
            }
        }
        public List<string> SelectableFonts
        {
            get => _selectableFonts;
            set
            {
                _selectableFonts = value;
                INotifyPropertyChanged(nameof(SelectableFonts));
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
        private Cursor _cur;
        public Cursor Cur
        {
            get => _cur;
            set
            {
                _cur = value;
                INotifyPropertyChanged(nameof(Cur));
            }
        }


        public ApodViewModel ()
        {
            FetchData = new RelayCommand(GetDataFromAPI);
            PreviousBtnCommand = new RelayCommand(PreviousDay);
            NextBtnCommand = new RelayCommand(NextDay);
            ImgSource = new BitmapImage(new Uri("https://static.wikia.nocookie.net/freestylerp/images/5/5f/Placeholder.jpg/revision/latest?cb=20240111110709"));
            FontSizes = Enumerable.Range(12, 15).ToList();
            SelectedFont = "Segoe UI";
            AddFonts();
            FontSize = 20;
            DtpValue = DateTime.Now;
            DateToday = DateTime.Now;
            Cur = new Cursor("C:\\Windows\\Cursors\\aero_arrow.cur", true);
        }
        async Task GetDataFromAPI()
        {
            Cur = new Cursor("C:\\Windows\\Cursors\\aero_working.ani", true);
            await APIconnection.FetchData($"apod?api_key=DEMO_KEY&date={DtpValue.ToString("yyyy-MM-dd")}");
            UpdateThings();
        }

        private async Task UpdateThings()
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
                Cur = new Cursor("C:\\Windows\\Cursors\\aero_arrow.cur", true);
            }
        }

        private void AddFonts()
        {
            using InstalledFontCollection col = new();
            foreach (System.Drawing.FontFamily fa in col.Families)
            {
                SelectableFonts.Add(fa.Name);
            }

        }

        async Task PreviousDay()
        {
            if (DtpValue.Day == 16 && DtpValue.Month == 6 && DtpValue.Year == 1995)
            {
                return;
            }
            else
            {
                DtpValue = DtpValue.AddDays(-1);
            }
        }
        async Task NextDay()
        {
            if (DtpValue.Day == DateToday.Day && DtpValue.Month == DateToday.Month && DtpValue.Year == DateToday.Year)
            {
                return;
            }
            else
            {
                DtpValue = DtpValue.AddDays(1);
            }
        }
    }
}
