using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    class MerchandiseInformation
    {

        public List<Merchandise> merchList { get; set; }

        public MerchandiseInformation()
        {
            merchList = new List<Merchandise>();
        }

        public void MakeMerchList()
        {
            merchList.Add(new Merchandise { Name = "PropellerKeps", Supplier = "PropGangInc", Stock = 100 });
            merchList.Add(new Merchandise { Name = "Guldbyxor", Supplier = "PojkenEnterprise", Stock = 100 });
            merchList.Add(new Merchandise { Name = "Sneakers", Supplier = "AdidasSämreHälft", Stock = 100 });
            merchList.Add(new Merchandise { Name = "Rånarluva", Supplier = "NotShadyInc", Stock = 100 });
            merchList.Add(new Merchandise { Name = "SuperStrumpor", Supplier = "WeLoveSocksEnterprise", Stock = 100 });
            merchList.Add(new Merchandise { Name = "LabbJacka", Supplier = "KemisternaAB", Stock = 100 });
        }
    }
}
