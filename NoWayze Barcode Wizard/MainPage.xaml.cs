using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.Devices.PointOfService;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NoWayze_Barcode_Wizard
{
    public class Customer
    {
        public string Name { get; set; }
    }
    /// <summary>
    /// The UI for the NoWayze Barcode Wizard
    /// Functionality:
    /// - Print all currently scanned Barcodes (dummy)
    /// - clear ALL scanned barcodes
    /// - removal of specific items from the list
    /// - save/load of list contents (planned)
    /// - substract currently scanned list from saved list, copy difference to clipboard ready for labbase (planned)
    /// - copy currently scanned list to clipboard ready for labbase (planned)
    /// Temporary testing funtionality:
    /// - generation of random barcode
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<ScannerData> observableScannerData { get; } = new ObservableCollection<ScannerData>();
        private ScannerData currentScanData;
        public MainPage()
        {
            this.InitializeComponent();
            currentScanData = new ScannerData();
        }

        private async void PrintButton(object sender, RoutedEventArgs e)
        {
            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync("printing . . .");
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
        private void TestClicker(object sender, RoutedEventArgs e)
        {
            Random rng = new Random();
            string rngBarcode = "ULE-" + rng.Next(0, 10) + rng.Next(0, 10) + rng.Next(0, 10) + rng.Next(0, 10) + rng.Next(0, 10) + rng.Next(0, 10) + rng.Next(0, 10) + rng.Next(0, 10) + rng.Next(0, 10) + rng.Next(0, 10) + "-" + rng.Next(0, 10) + rng.Next(0, 10);
            currentScanData.TryAddBarcode(rngBarcode);
        }

        private object selectedElement = null;
        private void ListView_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ListView listView = (ListView)sender;
            allBarcodesMenuFlyout.ShowAt(listView, e.GetPosition(listView));
            selectedElement = ((FrameworkElement)e.OriginalSource).DataContext;
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            currentScanData.RemoveBarcode((Barcode)selectedElement);
        }

        private void ClearList(object sender, RoutedEventArgs e)
        {
            currentScanData.BarcodeList.Clear();
        }
    }
}
