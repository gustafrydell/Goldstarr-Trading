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
        private List<Customer> customersList;
        private CustomerOrder customerOrder;
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
            this.customerList_Listview.Visibility = Visibility.Visible;
        }

        private void SelectCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            customerOrder.Customer = (Customer)e.ClickedItem;
            this.merchandiseList_Listview.Visibility = Visibility.Visible;
        }

        private void AddProductToOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var parent = (sender as Button).Parent; // listviewItem

            //Find selected product item
            TextBlock findSelectedProductTextblock = parent.GetChildrenOfType<TextBlock>().First(x => x.Name == "productName");

            //search through merchandise list to find and add that reference to clickedProduct
            foreach (var item in merchandiseManager.merchlist)
            {
                if (item.Name == findSelectedProductTextblock.Text)
                {
                    clickedProduct = item;
                }
            }

            //find selected quantity textbox
            TextBox findQuantityTextbox = parent.GetChildrenOfType<TextBox>().First( x => x.Name == "quantityInput");


            if (int.TryParse(findQuantityTextbox.Text, out _quantity))
            {
                customerOrder.Quantity = _quantity;
                
                if (customerOrder.Quantity <= clickedProduct.Stock)
                {
                    customerOrder.ProductsBought.Add(clickedProduct);
                    clickedProduct.Stock -= customerOrder.Quantity;

                    TextBlock findStockTextBlock = parent.GetChildrenOfType<TextBlock>().First(x => x.Name == "inStock_TextBlock");
                    findStockTextBlock.Text = clickedProduct.Stock.ToString();

                    orderedProductName_Textblock.Text = clickedProduct.Name;
                    orderedQuantityPurchased_Textblock.Text = findQuantityTextbox.Text;
                    orderedCustomerName_Textblock.Text = customerOrder.Customer.Name;
                    orderedDateTime_Textblock.Text = customerOrder.DateTime.ToString();
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

            //for (int i = 0; i < customerOrder.ProductsBought.Count; i++)
            //{
            //    Debug.WriteLine(customerOrder.ProductsBought[i].Name);
            //}

            //Debug.WriteLine(customerOrder.Quantity);
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
