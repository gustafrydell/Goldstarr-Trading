using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    public class CustomerOrder : Customer, INotifyPropertyChanged
    {
        public DateTime DateTime { get; set; }
        public Customer Customer { get; set; }
        public ObservableCollection <ProductBought> ProductsBoughtList { get; set; }

        public CustomerOrder()
        {
            ProductsBoughtList = new ObservableCollection<ProductBought>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
