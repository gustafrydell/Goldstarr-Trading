﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    class CustomerInformation
    {

        public List<Customer> customerList { get; set; }


        public CustomerInformation()
        {
            customerList = new List<Customer>();
        }
    }
}
