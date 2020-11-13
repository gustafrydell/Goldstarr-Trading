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
    public sealed partial class CustomerView : Page
    {
        ObservableCollection<Customer> Customers;
        public CustomerView()
        {
            this.InitializeComponent();
            Customers = CustomerManager.Customers;
        }

        private async void AddNewUser(object sender, RoutedEventArgs e)
        {
            AddCustomerDialog ad = new AddCustomerDialog();
            await ad.ShowAsync();
        }

        private void RemoveUser(object sender, RoutedEventArgs e)
        {
            Customer selectedCustomer = (Customer)CustomerListView.SelectedItem;
            Customers.Remove(selectedCustomer);
        }

    }
}
