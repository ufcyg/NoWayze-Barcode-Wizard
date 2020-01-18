using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoWayze_Barcode_Wizard
{
    public class Barcode //Recording
    {
        string barcodeString;
        public string Value { get { return barcodeString; } }
        // 
        public Barcode(string barcodeString)
        {
            this.barcodeString = barcodeString;
        }

    }
}
