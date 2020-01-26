using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.PointOfService;
using Windows.Storage.Streams;
//https://docs.microsoft.com/de-de/windows/uwp/devices-sensors/pos-get-started
namespace NoWayze_Barcode_Wizard
{
    class POSScanner
    {
        BarcodeScanner barcodeScanner;
        ClaimedBarcodeScanner claimedBarcodeScanner;
        ScannerData scannerData;
        public POSScanner(ScannerData scannerData)
        {
            this.scannerData = scannerData;
            GetScanner();
        }

        

        void claimedBarcodeScanner_ReleaseDeviceRequested(object sender, ClaimedBarcodeScanner e)
        {
            e.RetainDevice();  // Retain exclusive access to the device
        }
        void claimedBarcodeScanner_DataReceived(ClaimedBarcodeScanner sender, BarcodeScannerDataReceivedEventArgs args)
        {
            string symbologyName = BarcodeSymbologies.GetName(args.Report.ScanDataType);
            var scanDataLabelReader = DataReader.FromBuffer(args.Report.ScanDataLabel);
            string barcode = scanDataLabelReader.ReadString(args.Report.ScanDataLabel.Length);
            
            scannerData.TryAddBarcode(barcode);
        }

        private async void GetScanner()
        {
            // only finds the first POS device connected to the pc, ok if only one POS device is connected
            barcodeScanner = await BarcodeScanner.GetDefaultAsync();

            // for later to find a specific device
            //string selector = BarcodeScanner.GetDeviceSelector();
            //DeviceInformationCollection deviceCollection = await DeviceInformation.FindAllAsync(selector);

            //foreach (DeviceInformation devInfo in deviceCollection)
            //{
            //    Debug.WriteLine("{0} {1}", devInfo.Name, devInfo.Id);
            //    if (devInfo.Name.Contains("1202"))
            //    {
            //        Debug.WriteLine("Found one");
            //    }
            //}


            //claim device
            if(barcodeScanner != null)
            {
                try
                {
                    claimedBarcodeScanner = await barcodeScanner.ClaimScannerAsync();
                    
                    if (claimedBarcodeScanner != null)
                    {
                        // keep device claimed no matter what
                        claimedBarcodeScanner.ReleaseDeviceRequested += claimedBarcodeScanner_ReleaseDeviceRequested;
                        // enable decoding properties
                        claimedBarcodeScanner.DataReceived += claimedBarcodeScanner_DataReceived;
                        claimedBarcodeScanner.IsDecodeDataEnabled = true;
                        await claimedBarcodeScanner.EnableAsync();
                    }
                    Debug.WriteLine("ToString | ClaimedBarcodeObject: " + claimedBarcodeScanner.ToString());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("EX: ClaimScannerAsync() - " + ex.Message);
                }
            }
            else
            {
                Debug.WriteLine("No POS-Barcode Scanner found.");
            }


            //unclaim a device
            //if (claimedBarcodeScanner != null)
            //{
            //    claimedBarcodeScanner.Dispose();
            //    claimedBarcodeScanner = null;
            //}
        }
    }
}
