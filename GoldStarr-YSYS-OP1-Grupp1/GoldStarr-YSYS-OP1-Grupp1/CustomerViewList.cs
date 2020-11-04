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

            list.Add(new Customer { Name = "Gustaf Larsson", Address = "Malmögatan 69", PhoneNumber = "0706504929" });
            list.Add(new Customer { Name = "Calle Ballsson", Address = "Drottningatan 42", PhoneNumber = "040495939" });
            list.Add(new Customer { Name = "Yahya Yahyasson", Address = "Karstorpsvägen 32", PhoneNumber = "070492010" });
            list.Add(new Customer { Name = "Samy Kinkysson", Address = "Smultrongatan 54", PhoneNumber = "073346420" });
            list.Add(new Customer { Name = "Alex Grottman", Address = "Kasgatan 4", PhoneNumber = "075305001" });
            list.Add(new Customer { Name = "Jenny King", Address = "Skolgatan 41", PhoneNumber = "075233210" });


            return list;
        }


        public static void AddNewUser(string name, string address, string phonenumber)
        {
            Customers.Add(new Customer { Name = name, Address = address, PhoneNumber = phonenumber });
        }
    }
}
