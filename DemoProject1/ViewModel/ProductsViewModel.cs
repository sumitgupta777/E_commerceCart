using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject1.ViewModel
{
    public class ProductsViewModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please enter the price")]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Description { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public IFormFile ProductImg { get; set; }
    }
}
