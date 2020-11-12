using System;
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

        private void ContentDialog_OKButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

            if (string.IsNullOrEmpty(NameText.Text) || string.IsNullOrEmpty(AddressText.Text) || string.IsNullOrEmpty(PhonenumberText.Text))
            {
                var dialog = new MessageDialog("Du har inte fyllt i alla rutor");
                var t = dialog.ShowAsync().GetAwaiter();
            }
            else
            {
                if (StoreCustomerRadioButton.IsChecked == true)
                {
                    if (StringToLong(PhonenumberText.Text))
                    {
                    CustomerViewList.AddNewStoreUser(NameText.Text, AddressText.Text, PhonenumberText.Text,CustomerType.Butikskund);

                    }
                    else
                    {
                        var dialog = new MessageDialog("Du har fyllt rutorna med fel format");
                        var t = dialog.ShowAsync().GetAwaiter();
                    }

                }
                else if (OnlineCustomerRadioButton.IsChecked == true)
                {
                    if (StringToLong(CreditCardText.Text) && StringToLong(PhonenumberText.Text ))
                    {

                        if (string.IsNullOrEmpty(CreditCardText.Text) || string.IsNullOrEmpty(DeliveryAddressText.Text))
                        {
                            var dialog = new MessageDialog("Du har inte fyllt i alla obligatoriska rutor");
                            var t = dialog.ShowAsync().GetAwaiter();
                        }
                        else
                        {
                            CustomerViewList.AddNewOnlineUser(NameText.Text, AddressText.Text, PhonenumberText.Text, CustomerType.Onlinekund, DeliveryAddressText.Text, CreditCardText.Text, CustomerEmailText.Text);
                        }
                    }
                    else
                    {
                        //throw exception
                        var dialog = new MessageDialog("Du har fyllt rutorna med fel format");
                        var t = dialog.ShowAsync().GetAwaiter();
                    }
                }
                else
                {
                    var anotherDialog = new MessageDialog("Du har inte valt kundtyp");
                    var y = anotherDialog.ShowAsync().GetAwaiter();
                }
                    
            }
            
        }

        private bool StringToLong(string text)
        {
            bool isNumber = false;
            long number;
            if (long.TryParse(text, out number))
            {
                isNumber = true;
                return isNumber;
            }
            else
            {
            return isNumber;
            }
        }

        private void ContentDialog_CancelButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void OnlineCustomer_IsChecked(object sender, RoutedEventArgs e)
        {
            DeliveryAddressText.Visibility = Visibility.Visible;
            CreditCardText.Visibility = Visibility.Visible;
            CustomerEmailText.Visibility = Visibility.Visible;
        }

        private void StoreCustomer_IsChecked(object sender, RoutedEventArgs e)
        {
        }
    }
}
