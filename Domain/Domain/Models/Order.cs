using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Order model, getters en setters
/// </summary>
namespace OrderFoodApp.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Address { get; set; }
        public bool Done { get; set; }
        public IList<OrderItem> Items { get; set; }

    }
}
