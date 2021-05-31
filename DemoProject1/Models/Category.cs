using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(75)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [MaxLength(150)]
        public string CategoryDescription { get; set; }

        public bool IsActive { get; set; }
    }
}
