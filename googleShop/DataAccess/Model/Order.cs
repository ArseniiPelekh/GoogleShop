using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Model
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name="Введите имя")]
        [StringLength(25)]
        [Required(ErrorMessage = "Максимум 25 символов")]
        public string Name { get; set; }

        [Display(Name = "Введите Фамилию")]
        [StringLength(25)]
        [Required(ErrorMessage = "Максимум 25 символов")]
        public string Surname { get; set; }

        [Display(Name = "Введите Адрес")]
        [StringLength(35)]
        [Required(ErrorMessage = "Максимум 35 символов")]
        public string Adress { get; set; }

        [Display(Name = "Введите номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage = "Максимум 10 символов")]
        public string Phone { get; set; }

        [Display(Name = "Введите email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Максимум 25 символов")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDitail> OrderDitails { get; set; }
    }
}
