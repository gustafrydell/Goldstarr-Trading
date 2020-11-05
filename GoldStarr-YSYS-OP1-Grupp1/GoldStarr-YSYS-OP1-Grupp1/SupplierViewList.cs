using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldStarr_YSYS_OP1_Grupp1
{
    public class SupplierViewList
    {
        public ObservableCollection<Suppliers> Suppliers { get; set; }

        public SupplierViewList()
        {
            CreateSupplierInfo();
        }

        public ObservableCollection<Suppliers> GetList()
        {
            return Suppliers;
        }

        void CreateSupplierInfo()
        {
            var supplierList = new ObservableCollection<Suppliers>();

            supplierList.Add(new Suppliers { Name = "PropGangInc", Email = "WeGetPropCaps@gmail.com", PhoneNr = 0708112233 });
            supplierList.Add(new Suppliers { Name = "PojkenEnterprise", Email = "PojkenEnterprise@gmail.com", PhoneNr = 0708112233 });
            supplierList.Add(new Suppliers { Name = "AdidasSämreHälft", Email = "AdidasWorseHalf@gmail.com", PhoneNr = 0708112233 });
            supplierList.Add(new Suppliers { Name = "NotShadyInc", Email = "NotShadyInc@gmail.com", PhoneNr = 0708112233 });
            supplierList.Add(new Suppliers { Name = "WeLoveSocksEnterprise", Email = "SuperSocksInternational@gmail.com", PhoneNr = 0708112233 });
            supplierList.Add(new Suppliers { Name = "KemisternaAB", Email = "PotionsGoesBoom@gmail.com", PhoneNr = 0708112233 });

            Suppliers = supplierList;
        }

        public void AddNewSupplier(string _name, string _address, int _phonenumber)
        {
            Suppliers.Add(new Suppliers { Name = _name, Email = _address, PhoneNr = _phonenumber});
        }
    }
}
