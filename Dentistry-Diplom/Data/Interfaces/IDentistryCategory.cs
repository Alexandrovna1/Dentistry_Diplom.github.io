using Dentistry_Diplom.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace Dentistry_Diplom.Data.Interfaces
{
    interface IDentistryCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
