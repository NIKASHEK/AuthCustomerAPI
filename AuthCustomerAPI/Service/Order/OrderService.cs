namespace AuthCustomerAPI.Service.Order
{
    using AuthCustomerAPI.Models;
    using AuthCustomerAPI.Models.OrderDto;
    using AuthCustomerAPI.Repository.Order;
    using System.Collections.Generic;

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }
        public OrderReadDto CreateOrder(OrderCreateDto createDto)
        {
            var order = new Order() 
            {
                TotalAmount = createDto.TotalAmount,
                CustomerId = createDto.CustomerId,
            };

            _repo.Add(order);
            _repo.SaveChanges();

            var readDto = new OrderReadDto()
            {
                Id = order.Id,
                TotalAmount = order.TotalAmount,
                CreatedDate = order.CreatedDate,
                CustomerId = order.CustomerId,
            };
            return readDto;
        }

        public void DeleteOrder(int id)
        {
            var order = _repo.GetById(id);
            _repo.Delete(order);
            _repo.SaveChanges();
        }

        public IEnumerable<OrderReadDto> FilterOrder(decimal? totalAmount)
        {
            var orders = _repo.Filter(totalAmount).Select(o => new OrderReadDto() 
            {
                Id = o.Id,
                TotalAmount = o.TotalAmount,
                CreatedDate = o.CreatedDate,
                CustomerId = o.CustomerId,
            });
            return orders;
        }

        public IEnumerable<OrderReadDto> GetAllOrders()
        {
            return _repo.GetAll().Select(o => new OrderReadDto 
            {
                Id = o.Id,
                TotalAmount = o.TotalAmount,
                CreatedDate = o.CreatedDate,
                CustomerId = o.CustomerId,
            });
        }

        public OrderReadDto? GetOrder(int id)
        {
            var order = _repo.GetById(id);
            if (order == null)
                return null;
            var readDto = new OrderReadDto()
            {
                Id= order.Id,
                TotalAmount = order.TotalAmount,
                CreatedDate = order.CreatedDate,
                CustomerId = order.CustomerId,
            };
            return readDto;
        }

        public bool PatchOrder(int id, OrderPatchDto patchDto)
        {
            var order = _repo.GetById(id);

            if(order == null)
                return false;
            
            if(patchDto.TotalAmount.HasValue)
                order.TotalAmount = patchDto.TotalAmount.Value;

            _repo.SaveChanges();

            return true;
        }

        public void UpdateOrder(int id, OrderUpdateDto updateDto)
        {
            var order = _repo.GetById(id);
            
            order.TotalAmount = updateDto.TotalAmount;

            _repo.SaveChanges();
        }
    }
}
