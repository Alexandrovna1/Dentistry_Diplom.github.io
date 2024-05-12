using Dentistry_Diplom.Data.Models;
using System.Linq;

namespace Dentistry_Diplom.Data.ViewModels
{
    public class ShopDentViewModel
    {
        public ShopDent shopDent { get; set; }
        public int Sum => shopDent.shopDentItems.Sum(c => c.dentistry.price);
    }
}
