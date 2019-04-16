using AutoMapper;
using DTOs;
using OrderFoodApp.Domain.Interfaces;
using OrderFoodApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodApp.Service.Orders
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public OrdersService(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public IList<OrderDto> OrdersTodaysList(bool includeDone = true)
        {
            return _mapper.Map<IList<OrderDto>>(_ordersRepository.OrdersTodaysList(includeDone));
        }

        public IList<OrderDto> OrdersList(DateTime date)
        {
            return _mapper.Map<IList<OrderDto>>(_ordersRepository.OrdersList(date));
        }

        public OrderDto Save(OrderDto order)
        {
            var orderDb = _mapper.Map<Order>(order);
            orderDb = _ordersRepository.Save(orderDb);
            return _mapper.Map<OrderDto>(orderDb);
        }

        public OrderDto GetTodayById(int id, DateTime today)
        {
            var order = _ordersRepository.GetTodayById(id, today);
            return _mapper.Map<OrderDto>(order);
        }

        public PrevNextIdsDto GetPrevNextOrderIDs(OrderDto order, DateTime today)
        {
            var orderDb = _mapper.Map<Order>(order);
            var res = _ordersRepository.GetPrevNextOrderIDs(orderDb, today);
            return _mapper.Map<PrevNextIdsDto>(res);
        }

        public bool ToggleState(int id)
        {
            return _ordersRepository.ToggleState(id);
        }
    }
}
