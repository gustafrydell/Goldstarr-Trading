using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public static RestockOption Restock;
        public static MerchandiseManager _merchandiseManager;
        public static MerchandiseView Merchandise;
        public static CustomerOrder currentOrder;
        public static ObservableCollection<CustomerOrder> customerOrders;
        public static CustomerOrder selectedCustomerOrder;
        public SupplierViewList SupplierList;

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            _merchandiseManager = new MerchandiseManager();
            Restock = new RestockOption();
            SupplierList = new SupplierViewList();
        }

        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;


            FileManager readCustomerFile = new FileManager("Customers.json");
            CustomerViewList.Customers = await readCustomerFile.ReadFromFile<ObservableCollection<Customer>>();
            if (CustomerViewList.Customers == null)
            {
                CustomerViewList.Customers = CustomerViewList.CreateCustomers();
            }
            FileManager readMerchFile = new FileManager("Merchandise.json");
            _merchandiseManager.merchlist = await readMerchFile.ReadFromFile<ObservableCollection<Merchandise>>();
            if (_merchandiseManager.merchlist == null)
            {
                _merchandiseManager.merchlist = MerchandiseManager.GetMerchList();
            }

            FileManager readOrders = new FileManager("Orders.json");
            customerOrders = await readOrders.ReadFromFile<ObservableCollection<CustomerOrder>>();
            if (customerOrders == null)
            {
                customerOrders = new ObservableCollection<CustomerOrder>();
            }

            FileManager readSuppliers = new FileManager("Suppliers.json");
            SupplierList.Suppliers = await readSuppliers.ReadFromFile<ObservableCollection<Suppliers>>();
            if(SupplierList.Suppliers == null)
            {
                SupplierList.CreateSupplierInfo();
            }


            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }

        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            FileManager customerFile = new FileManager("Customers.json");
            customerFile.SaveFile(CustomerViewList.Customers);

            FileManager merchFile = new FileManager("Merchandise.json");
            merchFile.SaveFile(_merchandiseManager.merchlist);

            FileManager orderFile = new FileManager("Orders.json");
            orderFile.SaveFile(customerOrders);

            FileManager suppliersFile = new FileManager("Suppliers.json");
            suppliersFile.SaveFile(SupplierList.Suppliers);

            deferral.Complete();
        }
    }
}
