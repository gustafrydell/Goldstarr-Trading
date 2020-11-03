using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GoldStarr_YSYS_OP1_Grupp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomerOrderView : Page
    {
        //private string ProductName = "keps";
        private List<Customer> customersList;
        private CustomerOrder customerOrder;
        //private List<Merchandise> merchandiseManager;
        private Merchandise clickedProduct;
        public MerchandiseManager merchandiseManager;
        private int _quantity;

        public CustomerOrderView()
        {
          
            this.InitializeComponent();
            customersList = CustomerViewList.GetCustomers();
            merchandiseManager = App._merchandiseManager;
        }

        private void AddNewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            customerOrder = new CustomerOrder();
          
            customerOrder.DateTime = DateTime.Now;

            this.customerListView.Visibility = Visibility.Visible;
        }

        private void SelectCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            customerOrder.Customer = (Customer)e.ClickedItem;
            this.merchViewList.Visibility = Visibility.Visible;
        }

        //private void ProductListView_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    //clickedProduct = (Merchandise)e.ClickedItem;

           
        //}

        private void AddProductToOrder_Click(object sender, RoutedEventArgs e)
        {
            var parent = (sender as Button).Parent; // listviewItem

            //customerOrder.ProductsBought.Add(clickedProduct);

            var parent1 = (sender as Button).Parent; // listviewItem
            TextBlock merchTextBox1 = parent.GetChildrenOfType<TextBlock>().First(x => x.Name == "productName");

            foreach (var item in merchandiseManager.merchlist)
            {
                if (item.Name == merchTextBox1.Text)
                {
                    clickedProduct = item;
                    
                }
            }

            TextBox merchTextBox = parent.GetChildrenOfType<TextBox>().First( x => x.Name == "quantityInput");

            //

            if (int.TryParse(merchTextBox.Text, out _quantity))
            {
                customerOrder.Quantity = _quantity;
                // allt är ok
                // addToStock är uppdaterad
                if (customerOrder.Quantity <= clickedProduct.Stock)
                {
                    customerOrder.ProductsBought.Add(clickedProduct);
                    clickedProduct.Stock -= customerOrder.Quantity;

                    TextBlock merchStockTextBlock = parent.GetChildrenOfType<TextBlock>().First(x => x.Name == "merchTextBlock");
                    merchStockTextBlock.Text = clickedProduct.Stock.ToString();


                    ProductNameTextBlock.Text = clickedProduct.Name;
                    quantityPurchasedTextBlock.Text = merchTextBox.Text;
                    CustomerNameTextBlock.Text = customerOrder.Customer.Name;
                    DateTimeTextBlock.Text = customerOrder.DateTime.ToString();
                }
                else
                {
                    var anotherDialog = new MessageDialog("du är för fattig, du har inte så många på lager");
                    var y = anotherDialog.ShowAsync().GetAwaiter();
                }
                
               

               

            }
            else
            {
                var dialog = new MessageDialog ("Gör om, gör rätt");
                var t = dialog.ShowAsync().GetAwaiter();
            }


            for (int i = 0; i < customerOrder.ProductsBought.Count; i++)
            {
                Debug.WriteLine(customerOrder.ProductsBought[i].Name);
            }


            //if (customerOrder.Quantity)merchTextBox.Text






            //Debug.WriteLine(customerOrder.Quantity);


            // lägga till antalet produkter ???

            /*foreach (var item in customerOrder.ProductsBought)
            {
                this.text.Text = item.Name;
            }*/
        }



    }

    public static class Extensions
    {
        public static IEnumerable<T> GetChildrenOfType<T>(this DependencyObject start) where T : class // går alla grejjer som finns i listviewn
        {
            var queue = new Queue<DependencyObject>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();

                var realItem = item as T;
                if (realItem != null)
                {
                    yield return realItem;
                }

                int count = VisualTreeHelper.GetChildrenCount(item);
                for (int i = 0; i < count; i++)
                {
                    queue.Enqueue(VisualTreeHelper.GetChild(item, i));
                }
            }
        }
    }
}
