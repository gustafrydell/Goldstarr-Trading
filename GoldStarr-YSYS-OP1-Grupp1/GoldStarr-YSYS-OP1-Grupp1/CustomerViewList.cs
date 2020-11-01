using System.Collections.Generic;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    public class CustomerViewList
    {
        public static List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();

            customers.Add(new Customer { Name = "Gustaf Larsson", Address = "Malmögatan 69", PhonenNumber = 123123123 });
            customers.Add(new Customer { Name = "CalleBalle", Address = "Malmögatan 69", PhonenNumber = 123123123 });
            customers.Add(new Customer { Name = "Knatte", Address = "Malmögatan 69", PhonenNumber = 123123123 });
            customers.Add(new Customer { Name = "Fnatte", Address = "Malmögatan 69", PhonenNumber = 123123123 });
            customers.Add(new Customer { Name = "TjackLasse", Address = "Malmögatan 69", PhonenNumber = 123123123 });



            return customers;
        }

        //public void ShowList()
        //{
        //    foreach (var c in )
        //    {

        //    }
        //}
    }
}
