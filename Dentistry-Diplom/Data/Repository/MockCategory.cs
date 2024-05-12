using Dentistry_Diplom.Data.Interfaces;
using Dentistry_Diplom.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentistry_Diplom.Data.Repository
{
    public class MockCategory : IDentistryCategory
    {
        public IEnumerable<Category> AllCategories {
            get
            {
                return new List<Category>
                {
                    new Category { categoryName = "Стационарные (Домашние)", descr = "Необходим постоянный источник питания, а также требуется джойстик"},
                    new Category { categoryName = "Портативные (Карманные)", descr = "Не требует прямого источника питания и присутствует повышенная мобильность"}
                };
            }
        }
    }
}
