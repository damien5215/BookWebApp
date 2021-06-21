using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShared.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public Book Book { get; set; }

    }
}
