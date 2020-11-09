using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    public class CustomerOrder : Customer, INotifyPropertyChanged
    {
        private int _quantity;

        public DateTime DateTime { get; set; }
        public Customer Customer { get; set; }
        public ObservableCollection<Merchandise> ProductsBought { get; set; }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public CustomerOrder()
        {
            ProductsBought = new ObservableCollection<Merchandise>();
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
