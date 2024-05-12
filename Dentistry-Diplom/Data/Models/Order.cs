using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dentistry_Diplom.Data.Models
{
    public class Order
    {
        [BindNever] //никогда не будем отображать
        public int id { get; set; }
        [Display(Name ="Введите имя:")]
        [StringLength(50)]
        [Required(ErrorMessage ="Вы не ввели имя")]
        public string name { get; set; }
        [Display(Name = "Введите фамилию:")]
        [StringLength(50)]
        [Required(ErrorMessage = "Вы не ввели фамилию")]
        public string surname { get; set; }
        [Display(Name = "Введите адрес:")]
        [StringLength(200)]
        [Required(ErrorMessage = "Вы не ввели адрес")]
        public string adres { get; set; }
        [Display(Name = "Контактный номер:")]
        [StringLength(11)]
        [Required(ErrorMessage = "Вы не ввели телефон")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
        [Display(Name = "E-mail:")]
        [StringLength(30)]
        [Required(ErrorMessage = "Вы не ввели e-mail")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [BindNever]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetail { get; set; }
    }
}
