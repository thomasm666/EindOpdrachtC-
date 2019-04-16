using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodApp.Service.Orders
{
    public interface IOrdersService
    {
        IList<OrderDto> OrdersTodaysList(bool includeDone = true);
        IList<OrderDto> OrdersList(DateTime date);
        OrderDto Save(OrderDto order);
        OrderDto GetTodayById(int id, DateTime today);
        PrevNextIdsDto GetPrevNextOrderIDs(OrderDto order, DateTime today);
        bool ToggleState(int id);
    }
}
