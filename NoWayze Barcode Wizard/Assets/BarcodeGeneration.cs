using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using System.Drawing;

/// <summary>
/// 
/// </summary>
namespace NoWayze_Barcode_Wizard
{
    class BarcodeGeneration
    {
        private BarcodeFormat usedFormat;
        public BarcodeGeneration(BarcodeFormat barcodeFormat)
        {
            usedFormat = barcodeFormat;
        }

        public void EncodeBarcode(Barcode barcode)
        {
            BarcodeWriter writer = new BarcodeWriter() { Format = usedFormat };
            barcode.Image = writer.Write(barcode.Value);
            
        }

        public void DecodeBarcode()
        {
            
            //BarcodeReader reader = new BarcodeReader();
            //var result = reader.Decode((Bitmap)pic.Image);
            //if(result != null)
            //{
            //    txtDecode.Text = result.Text;
            //}
        }
    }
}
