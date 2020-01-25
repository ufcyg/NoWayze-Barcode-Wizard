using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace NoWayze_Barcode_Wizard
{
    public class Barcode //Recording
    {
        string barcodeString;
        
        public string Value { get { return barcodeString; } }

        WriteableBitmap barcodeImage;
        public WriteableBitmap Image
        {
            get { return barcodeImage; }
            set { barcodeImage = value; }
        }
        // 
        public Barcode(string barcodeString)
        {
            this.barcodeString = barcodeString;
        }

    }
}
