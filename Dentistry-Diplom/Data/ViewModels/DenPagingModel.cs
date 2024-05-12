using Dentistry_Diplom.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentistry_Diplom.Data.Models
{
    public class DentistryPagingModel
    {
        public IEnumerable<DentistryInfo> Dentistrys { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int CurrentCategory { get; set; }
    }
}
