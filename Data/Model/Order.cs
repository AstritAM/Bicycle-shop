using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data.Model
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name="Имя")]
        [StringLength(20)]
        [Required(ErrorMessage ="Обязательное поле")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина менее 6 символов")]
        public string Surname { get; set; }
        [Display(Name = "Отчество")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина менее 6 символов")]
        public string Patronic { get; set; }
        [Display(Name = "Адрес")]
        [StringLength(50)]
        [Required(ErrorMessage = "Длина менее 20 символов")]
        public string adress { get; set; }
        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        [Required(ErrorMessage = "Длина менее 11 символов")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(30)]
        [Required(ErrorMessage = "Длина менее 10 символов")]
        public string email { get; set; }
      
        
        [BindNever]
        [ScaffoldColumn(false)]

        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
