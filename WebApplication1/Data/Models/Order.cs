using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Enter your name")]
        [StringLength(10)]
        [Required(ErrorMessage ="Name length must be shorter than 10")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [StringLength(12)]
        [Required(ErrorMessage = "Surname length must be shorter than 12")]
        public string Surname { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone number length must be 10 numbers")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email  { get; set; }

        [Display(Name = "Address")]
        [StringLength(15)]
        [Required(ErrorMessage = "Address length must be shorter than 15")]
        public string Addres { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime Created { get; set; }

        [BindNever]
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
