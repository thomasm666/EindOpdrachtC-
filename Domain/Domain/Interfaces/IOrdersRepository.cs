using OrderFoodApp.Domain.Models;
using OrderFoodApp.Domain.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Order list
/// </summary>
namespace OrderFoodApp.Domain.Interfaces
{
    public interface IOrdersRepository
    {
        IList<Order> OrdersTodaysList(bool includeDone);
        IList<Order> OrdersList(DateTime date);
        Order Save(Order order);
        Order GetTodayById(int id, DateTime today);
        PrevNextIds GetPrevNextOrderIDs(Order order, DateTime today);
        bool ToggleState(int id);
    }
}
