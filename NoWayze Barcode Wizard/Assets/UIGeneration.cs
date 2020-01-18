using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace NoWayze_Barcode_Wizard
{
	public class UIGeneration
	{
		public ListView barcodeList;
		public UIGeneration()
		{
		}
		private void GenerateListPanel()
		{

		}
		public void GenerateListUI(StackPanel barcodeDisplayPanel)
		{
			barcodeList = new ListView();
			// Add the ListView to a parent container in the visual tree (that you created in the corresponding XAML file).
			//BarcodeDisplayPanel.Children.Add(barcodeList);
		}
	}
}