using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentistry_Diplom.Data.Models
{
    public class ShopDentItem
    {
        public int id { get; set; }
        public DentistryInfo dentistry { get; set; }
        public int price { get; set; }
        public string shopDentId { get; set; }
    }
}
