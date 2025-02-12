using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAssignment.Model
{
    public class ResultData
    {
        public string copyright {  get; set; }
        public DateTime date { get; set; }
        public string explanation { get; set; }
        public string hdurl { get; set; }
        public string media_type { get; set; }
        public string service_version { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        
        //private string _imageURL;
        //private string _title;
        //private string _explanation;
        //private string copyright;
        //private DateTime _date;

        //public string imageURL { 
        //    get { return _imageURL; } 
        //    set { _imageURL = value; } 
        //}
    }
}
