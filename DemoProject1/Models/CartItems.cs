using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject1.Models
{
    public class CartItems
    {
        [Key]
        public int CartItemsId { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Products Product { get; set; }

        public int Count { get; set; }
        
    }
}
