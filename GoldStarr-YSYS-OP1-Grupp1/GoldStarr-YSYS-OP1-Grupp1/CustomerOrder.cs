using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    class CustomerOrder : Customer
    {
        public DateTime DateTime { get; set; }
        public Customer Customer { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }



    }
}
