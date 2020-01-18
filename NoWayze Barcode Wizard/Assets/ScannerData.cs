using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NoWayze_Barcode_Wizard
{
	public class ScannerData 
	{
		private ObservableCollection<Barcode> barcodes;
		public ObservableCollection<Barcode> BarcodeList { get { return this.barcodes; } } 
		public ScannerData()
		{
			barcodes = new ObservableCollection<Barcode>();
		}

		public bool TryAddBarcode(string barcode)
		{
			Barcode barcodeObject = new Barcode(barcode);
			if (barcodes.Contains(barcodeObject))
			{
				return false;
			}
			else
			{
				barcodes.Add(barcodeObject);
				return true;
			}
		}
		public bool RemoveBarcode(Barcode barcodeObject)
		{
			if (barcodes.Contains(barcodeObject))
			{
				barcodes.Remove(barcodeObject);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}