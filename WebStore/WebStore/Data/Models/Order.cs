using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebStore.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Имя")]
        [StringLength(20)]
        [Required(ErrorMessage = "Поле слишком короткое!")]
        public string firstName { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(20)]
        [Required(ErrorMessage = "Поле слишком короткое!")]
        public string lastName { get; set; }

        [Display(Name = "Email адрес")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        [Required(ErrorMessage = "Поле слишком короткое!")]
        public string email { get; set; }

        [Display(Name = "Контактный телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Поле слишком короткое!")]
        public string phone { get; set; }

        [Display(Name = "Адрес проживания")]
        [StringLength(30)]
        [Required(ErrorMessage = "Поле слишком короткое!")]
        public string address { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }

    }
}
