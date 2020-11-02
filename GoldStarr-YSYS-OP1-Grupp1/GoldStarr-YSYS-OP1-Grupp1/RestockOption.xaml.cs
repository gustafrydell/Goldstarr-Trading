using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GoldStarr_YSYS_OP1_Grupp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RestockOption : Page
    {
        //public Merchandise _merchandise;
        public MerchandiseManager _merchandiseManager;

        public RestockOption()
        {
            this.InitializeComponent();
            // _merchandise = new Merchandise();
            _merchandiseManager = App._merchandiseManager;

            
            
          
        }

        //public event PropertyChangedEventHandler PropertyChanged;


        //public void AddToStock(int amount, string itemName)
        //{
        //    foreach (var item in _merchandiseManager.merchlist)
        //    {
        //        if(item.Name == itemName)
        //        {
        //            item.Stock += amount;
        //        }
        //    }

        //}

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            
            //AddToStock();
            Button button = (Button)sender;
            StackPanel parent = VisualTreeHelper.GetParent(button) as StackPanel;
            TextBox textBox = (TextBox)parent.FindName("AmountBox");


            TextBlock stockTextBlock = (TextBlock)parent.FindName("UpdatedStock");
            int addToStock = 0;
            // int.Parse()
            //try
            //{
            //    addToStock = int.Parse(textBox.Text);
            //}
            //catch (Exception ex)
            //{
            //    var dialog = new MessageDialog("Gör om, gör rätt");
            //    var t = dialog.ShowAsync().GetAwaiter();
            //}

            if (int.TryParse(textBox.Text, out addToStock))
            {
                // allt är ok
                // addToStock är uppdaterad
                var nameOfMerch = ((TextBlock)parent.FindName("NameTextBlock")).Text;
                var merch = _merchandiseManager.merchlist.FirstOrDefault(m => m.Name == nameOfMerch);
                merch.Stock += addToStock;
                stockTextBlock.Text = merch.Stock.ToString();
                

            }
            else
            {
                var dialog = new MessageDialog("Gör om, gör rätt");
                var t = dialog.ShowAsync().GetAwaiter();
            }
            //ctrl + k + c för kommentar
            //ctrl + k + u för avkommentar
        }
    }
}
