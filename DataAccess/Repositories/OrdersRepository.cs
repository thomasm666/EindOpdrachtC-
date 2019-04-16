using OrderFoodApp.Domain.Interfaces;
using OrderFoodApp.Domain.Models;
using OrderFoodApp.Domain.Support;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodApp.DataAccess.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OfaDbContext _context;
        public OrdersRepository(OfaDbContext context) => _context = context;

        public IList<Order> OrdersTodaysList(bool includeDone)
        {
            var todayStart = DateTime.Today;
            var todayEnd = DateTime.Today.AddDays(1);
            if (includeDone)
                return _context.Orders.Include(o => o.Items)
                        .Where(o => o.Created >= todayStart && o.Created < todayEnd)
                        .OrderByDescending(o => o.Created).ToList();
            else
                return _context.Orders.Include(o => o.Items)
                    .Where(o => o.Created >= todayStart && o.Created < todayEnd && o.Done == false)
                    .OrderByDescending(o => o.Created).ToList();
        }

        public IList<Order> OrdersList(DateTime date)
        {
            var dateEnd = date.AddDays(1);
            return _context.Orders.Include(o => o.Items)
                   .Where(o => o.Created >= date && o.Created < dateEnd)
                   .OrderByDescending(o => o.Created).ToList();
        }

        public Order Save(Order order)
        {
            order.Created = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public Order GetTodayById(int id, DateTime today)
        {
            var todayEnd = today.AddDays(1);
            return _context.Orders.Include(o => o.Items)
                    .Where(o => o.Created >= today && o.Created < todayEnd && o.Id == id)
                    .SingleOrDefault();
        }

        public PrevNextIds GetPrevNextOrderIDs(Order order, DateTime today)
        {
            var todayEnd = today.AddDays(1);
            var res = new PrevNextIds();
            var orders = _context.Orders.Where(o => o.Created >= today && o.Created < todayEnd)
                    .OrderBy(o => o.Created).ToList();
            if (0 != orders.Count)
            {

                var prev = orders.Where(o => o.Created <= order.Created && o.Id != order.Id)
                        .OrderByDescending(o => o.Created).Take(1).FirstOrDefault();

                var next = orders.Where(o => o.Created >= order.Created && o.Id != order.Id)
                        .OrderBy(o => o.Created).Take(1).FirstOrDefault();

                if (null != next)
                    res.NextId = next.Id;
                if (null != prev)
                    res.PrevId = prev.Id; 
            }
            return res;
        }

        public bool ToggleState(int id)
        {
            var order = _context.Orders.Find(id);
            if (null == order)
                return false;
            order.Done = !order.Done;
            _context.SaveChanges();
            return true;
        }
    }
}
