using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject1.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [MaxLength(75)]
        public string Name { get; set; }


        // Foreign key   
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }



        [Display(Name = "Price")]
        [Required(ErrorMessage = "Please enter the price")]
        public double Price { get; set; }

        public int Quantity { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public string ProductImg { get; set; }
    }
}
