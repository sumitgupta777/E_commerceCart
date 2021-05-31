using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject1.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int SNo { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }

    }
}
