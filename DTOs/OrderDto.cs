using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Address { get; set; }
        public bool Done { get; set; }
        public IList<OrderItemDto> Items { get; set; }
    }
}
