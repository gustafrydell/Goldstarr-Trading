﻿using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GoldStarr_YSYS_OP1_Grupp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerOrderView : Page
    {
       //private string customerName = "hkjfdhkdf";
        private List<Customer> customersList;

        private CustomerOrder customerOrder;

        private List<Merchandise> merchListView;

        public CustomerOrderView()
        {
          
            this.InitializeComponent();
            customersList = CustomerViewList.GetCustomers();
            merchListView = MerchandiseManager.GetMerchList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            customerOrder = new CustomerOrder();
            this.customerListView.Visibility = Visibility.Visible;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            customerOrder.Customer = (Customer)e.ClickedItem;
            //this.text.Text = customerOrder.Customer.Name;
            this.merchViewList.Visibility = Visibility.Visible;




        }
    }
}
