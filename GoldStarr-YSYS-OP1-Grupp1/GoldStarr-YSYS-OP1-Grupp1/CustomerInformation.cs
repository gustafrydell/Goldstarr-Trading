using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    class CustomerInformation : CustomerOrder
    {

        public List<Customer> customerList { get; set; }


        public CustomerInformation()
        {
            customerList = new List<Customer>();
        }

        

        public void CreateCustomerList()
        {
            Customer customer = new Customer();

            customerList.Add(new Customer { Name = "Lars Larsson", Address = "MalmöGatan 37", PhoneNumber = 0708123123, CustomerId = 1 });
            customerList.Add(new Customer { Name = "Bella Bellsson", Address = "MalmöGatan 37", PhoneNumber = 0708123123, CustomerId = 2 });
            customerList.Add(new Customer { Name = "Per Morberg", Address = "MalmöGatan 37", PhoneNumber = 0708123123, CustomerId = 3 });
            customerList.Add(new Customer { Name = "Lena Manfredsson", Address = "MalmöGatan 37", PhoneNumber = 0708123123, CustomerId = 4 });
            customerList.Add(new Customer { Name = "Abdi Abdisson", Address = "Trellehullsgatan 18", PhoneNumber = 0708123123, CustomerId = 5 });



        }
    }
}
