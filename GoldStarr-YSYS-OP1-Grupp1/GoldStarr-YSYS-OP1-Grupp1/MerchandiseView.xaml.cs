using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GoldStarr_YSYS_OP1_Grupp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MerchandiseView : Page
    {

        private ObservableCollection<Merchandise> merchListView;
        //private ObservableCollection<Merchandise> bajsMerchView;
        public MerchandiseView()
        {
            this.InitializeComponent();
            merchListView = App._merchandiseManager.merchlist;





        }
        //Gör produktrutan clickable
        private void MerchClick(object sender, ItemClickEventArgs e)
        {

        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string clickChoice = e.AddedItems[0].ToString();

            switch (clickChoice)
            {
                case "Alfabetiskt Stigande":
                     SortListByName();
                    break;

                case "Alfabetiskt Fallande":
                    SortListNameDescending();
                    break;

                case "Leverantör Stigande":
                    SortListBySupplier();
                    break;

                case "Leverantör Fallande":
                    SortListBySupplierDescending();
                    break;

            }

        }

        private void SortListByName()
        {
           
            var sortResult = merchListView.OrderBy(a => a.Name);
            ProductView.ItemsSource = sortResult;
            
        }
         
        private void SortListNameDescending()
        {
            var sortResult = merchListView.OrderByDescending(a => a.Name);
            ProductView.ItemsSource = sortResult;
        }

        private void SortListBySupplier()
        {
            //merchListView = (ObservableCollection<Merchandise>)merchListView.OrderBy(o => o.Supplier);
            var sortResult = merchListView.OrderBy(b => b.Supplier);
            ProductView.ItemsSource = sortResult;
        }

        private void SortListBySupplierDescending()
        {
            var sortResult = merchListView.OrderByDescending(b => b.Supplier);
            ProductView.ItemsSource = sortResult;
        }


    }
}
