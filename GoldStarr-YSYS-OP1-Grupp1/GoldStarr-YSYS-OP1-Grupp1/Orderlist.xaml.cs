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
        public ObservableCollection<CustomerOrder> customerOrders;
        private CustomerOrder selectedCustomerOrder;

        public Orderlist()
        {
            this.InitializeComponent();
            //customersList = CustomerViewList.Customers;
            merchandiseManager = App._merchandiseManager;
            customerOrders = App.customerOrders;
        }

        private void orderDetailButton_Click(object sender, RoutedEventArgs e)
        {
            var orderdetail = (Button)sender;
            selectedCustomerOrder = (CustomerOrder)orderdetail.DataContext;
            //Debug.WriteLine(selectedCustomerOrder.Customer.Name);
        }

    }

}
