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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GoldStarr_YSYS_OP1_Grupp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Frame AppFrame => frame;
        public MainPage()
        {
            this.InitializeComponent();
        }

        public readonly string CustomerListLabel = "Customers";
        public readonly string CustomerOrderListLabel = "Customer Orders";
        public readonly string MerchandiseListLabel = "Merchandise";
        public readonly string ReStockOptionLabel = "Restock";

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            NavView.IsPaneOpen = false;
            frame.Navigate(typeof(CustomerView));
            CustomerListMenyItem.IsSelected = true;
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var label = args.InvokedItem as string;
            var pageType =
                label == CustomerListLabel ? typeof(CustomerView) :
                label == CustomerOrderListLabel ? typeof(CustomerOrderView) :
                label == MerchandiseListLabel ? typeof(MerchandiseView) :
                label == ReStockOptionLabel ? typeof(RestockOption) : null;
            if (pageType != null && pageType != AppFrame.CurrentSourcePageType)
            {
                AppFrame.Navigate(pageType);
            }
        }
        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (AppFrame.CanGoBack)
            {
                AppFrame.GoBack();
            }
        }
        private void frame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                if (e.SourcePageType == typeof(CustomerView))
                {
                    NavView.SelectedItem = CustomerListMenyItem;
                }
                else if (e.SourcePageType == typeof(CustomerOrderView))
                {
                    NavView.SelectedItem = CustomerOrdersListMeny;
                }
                else if (e.SourcePageType == typeof(MerchandiseView))
                {
                    NavView.SelectedItem = MerchandiseListMeny;
                }
                else if(e.SourcePageType == typeof(RestockOption))
                {
                    NavView.SelectedItem = RestockOption;
                }
            }
        }
    }
}
