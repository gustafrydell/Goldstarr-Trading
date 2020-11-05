using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.ApplicationModel;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    public class CustomerViewList
    {

        public static ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

        public CustomerViewList()
        {
            Customers = CreateCustomers();
        }


        public static ObservableCollection<Customer> CreateCustomers()
        {
            var list = new ObservableCollection<Customer>();

            list.Add(new Customer { Name = "Gustaf Larsson", Address = "Malmögatan 69", PhoneNumber = "0706504929", DeliveryAddress = "ej tillgänglig", CreditCardNumber = "ej tillgänglig", CustomerEmail = "ej tillgänglig" });
            list.Add(new Customer { Name = "Calle Ballsson", Address = "Drottningatan 42", PhoneNumber = "040495939", DeliveryAddress = "ej tillgänglig", CreditCardNumber = "ej tillgänglig", CustomerEmail = "ej tillgänglig" });
            list.Add(new Customer { Name = "Yahya Yahyasson", Address = "Karstorpsvägen 32", PhoneNumber = "070492010", DeliveryAddress = "ej tillgänglig", CreditCardNumber = "ej tillgänglig", CustomerEmail = "ej tillgänglig" });
            list.Add(new Customer { Name = "Samy Kinkysson", Address = "Smultrongatan 54", PhoneNumber = "073346420", DeliveryAddress = "ej tillgänglig", CreditCardNumber = "ej tillgänglig", CustomerEmail = "ej tillgänglig" });
            list.Add(new Customer { Name = "Alex Grottman", Address = "Kasgatan 4", PhoneNumber = "075305001", DeliveryAddress = "ej tillgänglig", CreditCardNumber = "ej tillgänglig", CustomerEmail = "ej tillgänglig" });
            list.Add(new Customer { Name = "Jenny King", Address = "Skolgatan 41", PhoneNumber = "075233210", DeliveryAddress = "ej tillgänglig", CreditCardNumber = "ej tillgänglig", CustomerEmail = "ej tillgänglig" });


            return list;
        }


        public static void AddNewStoreUser(string name, string address, string phonenumber,CustomerType customerType)
        {
            Customers.Add(new Customer { Name = name, Address = address, PhoneNumber = phonenumber , IsOnline = customerType, DeliveryAddress = "ej tillgänglig", CreditCardNumber = "ej tillgänglig", CustomerEmail = "ej tillgänglig" });
        }
        
        public static void AddNewOnlineUser(string name, string address, string phonenumber, CustomerType customerType, string deliveryAdress, string creditCardNumber,string customerEmail)
        {
            Customers.Add(new Customer { Name = name, Address = address, PhoneNumber = phonenumber, IsOnline = customerType, DeliveryAddress = deliveryAdress, CreditCardNumber = creditCardNumber, CustomerEmail = customerEmail });
        }
    }
}
