﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GoldStarr_YSYS_OP1_Grupp1
{
    public sealed partial class AddCustomerDialog : ContentDialog
    {
        public AddCustomerDialog()
        {
            this.InitializeComponent();
            
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (StoreCustomerRadioButton.IsChecked == true || OnlineCustomerRadioButton.IsChecked == true)
            {
            CustomerViewList.AddNewUser(NameText.Text, AddressText.Text, PhonenumberText.Text);

            }
            else
            {
                var anotherDialog = new MessageDialog("Du har inte valt kundtyp");
                var y = anotherDialog.ShowAsync().GetAwaiter();
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void OnlineCustomer_IsChecked(object sender, RoutedEventArgs e)
        {
            DeliveryAddressText.Visibility = Visibility.Visible;
            CreditCardText.Visibility = Visibility.Visible;

        }

        private void StoreCustomer_IsChecked(object sender, RoutedEventArgs e)
        {
            DeliveryAddressText.Visibility = Visibility.Collapsed;
            CreditCardText.Visibility = Visibility.Collapsed;
        }
    }
}
