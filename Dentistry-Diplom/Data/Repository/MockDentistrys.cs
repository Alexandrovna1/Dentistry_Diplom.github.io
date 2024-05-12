using Dentistry_Diplom.Data.Interfaces;
using Dentistry_Diplom.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentistry_Diplom.Data.Repository
{
    public class MockDentistrys : IAllDentistry
    {
        private readonly IDentistryCategory _densCategory = new MockCategory();
        public IEnumerable<DentistryInfo> Dentistrys { 
            get
            {
                return new List<DentistryInfo>
                {
                    new DentistryInfo{
                        name = "PlayStation 4",
                        shortDesc = "Одна из лучших, но ушедших моделей",
                        longDesc = "Старое поколение, но с большим количеством игр и поддержек. Бюджетный вариант, если вы желаете приобрести консоль",
                        img = "/img/ps4-img-card.jpg",
                        price = 9000,
                        isFavourite = true,
                        available = true,
                        _Category = _densCategory.AllCategories.ToList().ElementAt(0)
                    },
                    new DentistryInfo{
                        name = "PlayStation 5",
                        shortDesc = "Новое поколение. Новые возможности",
                        longDesc = "Новая приставка, позволяющая растянуть удовольствие на целый десяток. Понравится большинсту геймеров, которые впервые знакомяться с приставками",
                        img = "/img/ps5-img-card.png",
                        price = 20000,
                        isFavourite = true,
                        available = true,
                        _Category = _densCategory.AllCategories.ToList().ElementAt(0)
                    },
                    new DentistryInfo{
                        name = "Nintendo Junior",
                        shortDesc = "Старый, но заставит поностальгировать",
                        longDesc = "Консоль старого поколения, поддержка которой прекращена давно. Прилагается для коллекционеров и ценителей старых моделей",
                        img = "/img/junior-img-card.png",
                        price = 2500,
                        isFavourite = true,
                        available = true,
                        _Category = _densCategory.AllCategories.ToList().ElementAt(0)
                    },
                     new DentistryInfo{
                        name = "Xbox Series X",
                        shortDesc = "Думаете это холодильник? Ошибайтесь",
                        longDesc = "Лучшая приставка со стороны выгоды. Не уступает PlayStation 5",
                        img = "/img/xbox-img-card.png",
                        price = 17000,
                        isFavourite = true,
                        available = true,
                        _Category = _densCategory.AllCategories.ToList().ElementAt(0)
                    },
                    new DentistryInfo{
                        name = "Steam Deck",
                        shortDesc = "Он всегда при тебе",
                        longDesc = "Средне-бюджетный вариант для карамнной консоли. Будет по душе, если желаете сэкономить",
                        img = "/img/deck-img-card.png",
                        price = 16000,
                        isFavourite = true,
                        available = true,
                        _Category = _densCategory.AllCategories.ToList().ElementAt(1)
                    },
                     new DentistryInfo{
                        name = "Asus ROG Ally",
                        shortDesc = "Монстр в кармане",
                        longDesc = "Самый дорогой, но самый лучший вариант среди карманных приставок. Переживет не одно поколение",
                        img = "/img/rog-img-card.png",
                        price = 26000,
                        isFavourite = true,
                        available = true,
                        _Category = _densCategory.AllCategories.ToList().ElementAt(1)
                    },
                     new DentistryInfo{
                        name = "Game Box",
                        shortDesc = "Признаюсь честно. Я старик",
                        longDesc = "Легкая, но старая приставочка. Увы, вышло из моды и прогресса",
                        img = "/img/box-img-card.png",
                        price = 2000,
                        isFavourite = true,
                        available = true,
                        _Category = _densCategory.AllCategories.ToList().ElementAt(1)
                    },
                     new DentistryInfo{
                        name = "PSP",
                        shortDesc = "Однажды о такой мечтали",
                        longDesc = "Ушедшее поколение приставок, но можно купить и в коллекцию",
                        img = "/img/psp-img-card.png",
                        price = 4000,
                        isFavourite = true,
                        available = true,
                        _Category = _densCategory.AllCategories.ToList().ElementAt(1)
                    },
                     new DentistryInfo{
                        name = "Nintendo Switch",
                        shortDesc = "Что среднее, между Deck и ROG",
                        longDesc = "Портативная приставка с закрытой ос. Хочешь играть - плоти",
                        img = "/img/switch-img-card.png",
                        price = 12000,
                        isFavourite = true,
                        available = true,
                        _Category = _densCategory.AllCategories.ToList().ElementAt(1)
                    },
                };
            }
        }

        public IEnumerable<DentistryInfo> getFavDentistry { get => throw new NotImplementedException(); }

        public DentistryInfo getSingleDentistry(int dentistryId)
        {
            throw new NotImplementedException();
        }
    }
}
