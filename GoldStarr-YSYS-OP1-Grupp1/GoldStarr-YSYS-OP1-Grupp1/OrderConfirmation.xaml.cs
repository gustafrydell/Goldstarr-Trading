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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GoldStarr_YSYS_OP1_Grupp1
{
    public sealed partial class OrderConfirmation : ContentDialog
    {
        private readonly CustomerOrder currentOrder;

        public OrderConfirmation()
        {
            this.InitializeComponent();
            currentOrder = App.currentOrder;
        }

        private void ContentDialog_OKButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
