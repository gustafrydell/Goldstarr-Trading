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


// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GoldStarr_YSYS_OP1_Grupp1
{
    
    public sealed partial class OrderDetailDialog : ContentDialog
    {
        
        private ObservableCollection<ProductBought> selectedProductBoughtList;
            
        public OrderDetailDialog()
        {
            this.InitializeComponent();
            selectedProductBoughtList = new ObservableCollection<ProductBought>();
            foreach (var item in App.customerOrders)
            {
                if (App.selectedCustomerOrder.Customer.Name == item.Customer.Name && App.selectedCustomerOrder.DateTime == item.DateTime)
                {
                    selectedProductBoughtList = item.ProductsBoughtList;
                }

            }
            
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        
    }
}
