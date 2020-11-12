using System;
using System.Collections.Generic;
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
    public sealed partial class Orderlist : Page
    {
        //private ObservableCollection<Customer> customersList;
        public MerchandiseManager merchandiseManager;
        public ObservableCollection<CustomerOrder> customerOrders { get; set; }
        private CustomerOrder selectedCustomerOrder;

        public Orderlist()
        {
            this.InitializeComponent();
            //customersList = CustomerManager.Customers;
            merchandiseManager = App._merchandiseManager;
            customerOrders = App.customerOrders;

            if (customerOrders.Count == 0)
            {
                SortOrderListButton.IsEnabled = false;
            }
            else
            {
                SortOrderListButton.IsEnabled = true;
            }
        }

        //private void orderDetailButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private async void orderDetailButton_Click(object sender, RoutedEventArgs e)
        {
            var orderdetail = (Button)sender;
            selectedCustomerOrder = (CustomerOrder)orderdetail.DataContext;
            App.selectedCustomerOrder = selectedCustomerOrder;
            OrderDetailDialog orderDetailDialog = new OrderDetailDialog();
            await orderDetailDialog.ShowAsync();

            //Debug.WriteLine(selectedCustomerOrder.Customer.Name);
        }

        private void SortingOrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            
            string clickChoice = e.AddedItems[0].ToString();

            switch (clickChoice)
            {

                case "Namn Alfabetiskt Stigande":
                    SortListByName();
                    break;
                case "Namn Alfabetiskt Fallande":
                    SortListByNameDescending();
                    break;
                case "Datum Stigande":
                    SortListByDate();
                    break;
                case "Datum Fallande":
                    SortListByDateDescending();
                    break;


            }
        }

        private void SortListByName()
        {
            var sortingResult = customerOrders.OrderBy(b => b.Customer.Name);
            OrderListHistoryView.ItemsSource = sortingResult;

        }

        private void SortListByNameDescending()
        {
            var sortingResult = customerOrders.OrderByDescending(b => b.Customer.Name);
            OrderListHistoryView.ItemsSource = sortingResult;
        }

        private void SortListByDate()
        {
            var sortingResult = customerOrders.OrderBy(b => b.DateTime);
            OrderListHistoryView.ItemsSource = sortingResult;
        }

        private void SortListByDateDescending()
        {
            var sortingResult = customerOrders.OrderByDescending(b => b.DateTime);
            OrderListHistoryView.ItemsSource = sortingResult;
        }

    }

}
