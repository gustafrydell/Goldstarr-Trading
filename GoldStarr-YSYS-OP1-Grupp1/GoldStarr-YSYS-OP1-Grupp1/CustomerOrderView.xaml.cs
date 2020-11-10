using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Email.DataProvider;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    /// 
    
    public sealed partial class CustomerOrderView : Page
    {
        private ObservableCollection<Customer> customersList;
        private CustomerOrder customerOrder;
        private ProductBought clickedProduct;
        public MerchandiseManager merchandiseManager;
        private int _quantity;
        private Merchandise _merch;
        private ProductBought removedProduct;
       // public event PropertyChangedEventHandler PropertyChanged;

        //private int _stock;

        public CustomerOrderView()
        {
            this.InitializeComponent();
            customersList = CustomerViewList.Customers;
            merchandiseManager = App._merchandiseManager;
            _merch = new Merchandise();
           
        }

        // after pressing the add order button
        private void AddNewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            disableAllList();
            customerOrder = new CustomerOrder();
            customerOrder.DateTime = DateTime.Now;
            chooseCustomerTextblock.Visibility = Visibility.Visible;
            this.customerList_Listview.Visibility = Visibility.Visible;
            ChooseCustomer_label.Foreground = new SolidColorBrush(Colors.Black);
            ChooseCustomer_label.FontWeight = Windows.UI.Text.FontWeights.Bold;
        }

        // after selecting a customer
        private void SelectCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            customerOrder.Customer = (Customer)e.ClickedItem;
            this.merchandiseList_Listview.Visibility = Visibility.Visible;
            chooseProductTextblock.Visibility = Visibility.Visible;
            FinishOrderButton.Visibility = Visibility.Visible;
            ChooseProduct_label.Foreground = new SolidColorBrush(Colors.Black);
            ChooseProduct_label.FontWeight = Windows.UI.Text.FontWeights.Bold;
        }
        
        // after pressing add product
        

        private void AddProductToOrderButton_Click(object sender, RoutedEventArgs e)
        {
            clickedProduct = new ProductBought();
            cartTitle.Visibility = Visibility.Visible;

            var parent = (sender as Button).Parent; // listviewItem

            //Find selected product item
            TextBlock findSelectedProductTextblock = parent.GetChildrenOfType<TextBlock>().First(x => x.Name == "productName");

            //search through merchandise list to find and add that reference to clickedProduct
            foreach (var item in merchandiseManager.merchlist)
            {
                if (item.Name == findSelectedProductTextblock.Text)
                {
                    clickedProduct.ProductChosen = item;
                    _merch = item;
                    clickedProduct.ProductChosen.Stock = item.Stock;
                }
            }

            //find selected quantity textbox
            TextBox findQuantityTextbox = parent.GetChildrenOfType<TextBox>().First( x => x.Name == "quantityInput");

            if (int.TryParse(findQuantityTextbox.Text, out _quantity))
            {
                clickedProduct.QuantityBought = _quantity;
                AddToCart_listview.ItemsSource = customerOrder.ProductsBoughtList;

                if (clickedProduct.QuantityBought <= clickedProduct.ProductBoughtStock)
                {
                    for (int i = 0; i < customerOrder.ProductsBoughtList.Count; i++)
                    {
                        if (clickedProduct.ProductChosen.MerchandiseId == customerOrder.ProductsBoughtList[i].ProductChosen.MerchandiseId )
                        {                            
                            clickedProduct.ProductBoughtStock += customerOrder.ProductsBoughtList[i].QuantityBought; ;
                            clickedProduct.QuantityBought += customerOrder.ProductsBoughtList[i].QuantityBought;
                            //clickedProduct.ProductChosen.Stock -= clickedProduct.QuantityBought;
                            //_merch.Stock = clickedProduct.ProductChosen.Stock;
                            customerOrder.ProductsBoughtList.RemoveAt(i);
                        }
                        
                    }

                    customerOrder.ProductsBoughtList.Add(clickedProduct);
                    clickedProduct.ProductBoughtStock -= clickedProduct.QuantityBought;
                    Debug.WriteLine(clickedProduct.ProductBoughtStock);

                    //_merch.Stock = clickedProduct.ProductChosen.Stock;  ********

                    AddToCart_listview.Visibility = Visibility.Visible;
                    
                    TextBlock findStockTextBlock = parent.GetChildrenOfType<TextBlock>().First(x => x.Name == "inStock_TextBlock");
                    findStockTextBlock.Text = clickedProduct.ProductChosen.Stock.ToString();
                    
                    //orderedProductName_Textblock.Text = clickedProduct.ProductChosen.Name;
                    //orderedQuantityPurchased_Textblock.Text = findQuantityTextbox.Text;
                   

                    findQuantityTextbox.Text = "";
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
        }

        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {
            var removeButton = (Button)sender;
            removedProduct = (ProductBought)removeButton.DataContext;

            customerOrder.ProductsBoughtList.Remove(removedProduct);
           //removedProduct.ProductChosen.Stock += removedProduct.QuantityBought; // uppdatera

            //var parent = (Frame)Parent;
            //TextBlock findStockTextBlock = removedProduct.GetChildrenOfType<TextBlock>().First(x => x.Name == "inStock_TextBlock");
            //findStockTextBlock.Text = removedProduct.ProductChosen.Stock.ToString();

            foreach (var item in merchandiseManager.merchlist)
            {
                if (item.Name == removedProduct.ProductChosen.Name)
                {
                    removedProduct.ProductBoughtStock += removedProduct.QuantityBought;
                    //item.Stock += removedProduct.QuantityBought;
                }
            }

            

        }

        private async void FinishOrderButton_Click(object sender, RoutedEventArgs e)
        {
            //enabledOrderVisibility();
            
            foreach (var item in customerOrder.ProductsBoughtList)
            {
               item.ProductChosen.Stock = item.ProductBoughtStock;
            }

            App.customerOrders.Add(customerOrder);


            Confirmation_label.Foreground = new SolidColorBrush(Colors.Black);
            Confirmation_label.FontWeight = Windows.UI.Text.FontWeights.Bold;

            App.currentOrder = customerOrder;
            OrderConfirmation confirmation = new OrderConfirmation();
            await confirmation.ShowAsync();
            disableAllList();
        }

        // ska återställa allt när man avbryter ordern
        private void CancelOrderButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in customerOrder.ProductsBoughtList)
            {
                item.ProductChosen.Stock += item.QuantityBought; // uppdatering saknas

                var parent = (sender as Button).Parent;
                TextBlock findStockTextBlock = parent.GetChildrenOfType<TextBlock>().First(x => x.Name == "inStock_TextBlock");
                findStockTextBlock.Text = item.ProductChosen.Stock.ToString();
            }
            customerOrder.ProductsBoughtList.Clear();

            
            disableAllList();

        }

        private void disableAllList()
        {
            chooseCustomerTextblock.Visibility = Visibility.Collapsed;
            customerList_Listview.Visibility = Visibility.Collapsed;
            ChooseCustomer_label.Foreground = new SolidColorBrush(Colors.Gray);
            ChooseCustomer_label.FontWeight = Windows.UI.Text.FontWeights.Normal;

            chooseProductTextblock.Visibility = Visibility.Collapsed;
            ChooseProduct_label.Foreground = new SolidColorBrush(Colors.Gray);
            ChooseProduct_label.FontWeight = Windows.UI.Text.FontWeights.Normal;

            chooseCustomerTextblock.Visibility = Visibility.Collapsed;
            merchandiseList_Listview.Visibility = Visibility.Collapsed;

            
            AddToCart_listview.Visibility = Visibility.Collapsed;
            cartTitle.Visibility = Visibility.Collapsed;
            Confirmation_label.Foreground = new SolidColorBrush(Colors.Gray);
            Confirmation_label.FontWeight = Windows.UI.Text.FontWeights.Normal;
        }
        

        private void productCheckBox_Click(object sender, RoutedEventArgs e)
        {

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
