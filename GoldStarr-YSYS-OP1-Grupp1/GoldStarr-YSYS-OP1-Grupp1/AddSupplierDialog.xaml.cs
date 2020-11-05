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
    public sealed partial class AddSupplierDialog : ContentDialog
    {
        private App _app;

        public AddSupplierDialog()
        {
            this.InitializeComponent();
            _app = (App)App.Current;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //_app.SupplierList.AddNewSupplier(CompanyNameText.Text, EmailNameText.Text, PhoneNrText.Text);

            int phoneNr;
            //phoneNr = int.Parse(PhoneNrText.Text);

            if(int.TryParse(PhoneNrText.Text, out phoneNr))
            {

                //_app.SupplierList.AddNewSupplier(CompanyNameText.Text, EmailNameText.Text, phoneNr);

                if(CompanyNameText.Text == string.Empty)
                {
                    var dialogtext = new MessageDialog("Företaget måste ha ett namn");
                    var t1 = dialogtext.ShowAsync().GetAwaiter();
                }
                else if(EmailNameText.Text == string.Empty)
                {
                    var dialogtext = new MessageDialog("Du måste skriva en mail");
                    var t = dialogtext.ShowAsync().GetAwaiter();

                }
                else
                {
                    _app.SupplierList.AddNewSupplier(CompanyNameText.Text, EmailNameText.Text, phoneNr);
                }
            }
           
            else
            {
                var dialogtext = new MessageDialog("Endast siffror i telefonnummret tack.");
                var t = dialogtext.ShowAsync().GetAwaiter();
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
