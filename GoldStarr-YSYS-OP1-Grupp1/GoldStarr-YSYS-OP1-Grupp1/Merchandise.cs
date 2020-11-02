using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    public class Merchandise : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Supplier { get; set; }

        private int _stock; //{ get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public int MerchandiseId { get; set; }
        public string CoverImage { get; set; }
        
        public int Stock { 
            get { return _stock; } 
            set { _stock = value; OnPropertyChanged(); }
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public string GetInStock()
        {
            return $"{Stock} i lager";
        }
        



    }

    public class MerchandiseManager
    {
    
        public ObservableCollection<Merchandise> merchlist { get; set; }

        public MerchandiseManager()
        {
            merchlist = GetMerchList();

        }
            public ObservableCollection<Merchandise> GetMerchList()
            {
                var merchList = new ObservableCollection<Merchandise>();
                {

                    merchList.Add(new Merchandise { Name = "PropellerKeps", Supplier = "PropGangInc", Stock = 10, MerchandiseId = 1, CoverImage = "Assets/proppellerkeps.jfif" });
                    merchList.Add(new Merchandise { Name = "Guldbyxor", Supplier = "PojkenEnterprise", Stock = 10, MerchandiseId = 2, CoverImage = "Assets/Goldenpants.jpg" });
                    merchList.Add(new Merchandise { Name = "Sneakers", Supplier = "AdidasSämreHälft", Stock = 10, MerchandiseId = 3, CoverImage = "Assets/dog-with-doggie-shoes.jpg" });
                    merchList.Add(new Merchandise { Name = "Rånarluva", Supplier = "NotShadyInc", Stock = 10, MerchandiseId = 4, CoverImage = "Assets/SkimaskDog.jfif" });
                    merchList.Add(new Merchandise { Name = "SuperStrumpor", Supplier = "WeLoveSocksEnterprise", Stock = 10, MerchandiseId = 5, CoverImage = "Assets/SuperStrumpor.jpg" });
                    merchList.Add(new Merchandise { Name = "LabbJacka", Supplier = "KemisternaAB", Stock = 10, MerchandiseId = 6, CoverImage = "Assets/LabcoatDog.jpg" });
                    return merchList;

                }
            }
        
    }



}
