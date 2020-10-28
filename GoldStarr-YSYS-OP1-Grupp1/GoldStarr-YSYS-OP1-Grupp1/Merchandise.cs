using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    public class Merchandise : MerchandiseInformation 
    {
        public string Name { get; set; }
        public string Supplier { get; set; }
        public int Stock { get; set; }

        public int MerchandiseId { get; set; }

        public void AddStock(int productId, int incommingStock) // fyller i product id och antalet inkommande varor => får nya antalet
        {
            foreach (var item in merchList )
            {
                if (productId == item.MerchandiseId)
                {
                    item.Stock += incommingStock;
                }
            }
            
            
        }

       
    }
}
