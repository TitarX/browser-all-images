using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrowserAllImages
{
    public class DataForWorkerThread
    {
        public MainForm MainForm { get; set; }
        public SearchForm SearchForm { get; set; }

        public bool IsAllFormats { get; set; }
        public bool IsJpegFormat { get; set; }
        public bool IsGifFormats { get; set; }
        public bool IsPngFormats { get; set; }
        public bool IsBmpFormats { get; set; }
        public bool IsTiffFormats { get; set; }
        public bool IsAllCreateDate { get; set; }
        public bool IsAllSize { get; set; }
        public bool IsNowPause { get; set; }

        public String RooSearchFolder { get; set; }

        public DateTime CreateDateFrom { get; set; }
        public DateTime CreateDateTo { get; set; }

        public int ImageWidthFrom { get; set; }
        public int ImageWidthTo { get; set; }
        public int ImageHeightFrom { get; set; }
        public int ImageHeightTo { get; set; }
    }
}
