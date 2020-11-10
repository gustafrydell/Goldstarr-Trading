using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    public enum CustomerType
    {
        Butikskund,
        Onlinekund
    }
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public CustomerType IsOnline { get; set; }
        public string DeliveryAddress { get; set; }
        public string CreditCardNumber { get; set; }
        public string CustomerEmail { get; set; }
        public ObservableCollection<CustomerOrder> CustomerOrders { get; set; }

        public Customer()
        {
            CustomerOrders = new ObservableCollection<CustomerOrder>();
        }
    }
}
