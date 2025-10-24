namespace AuthCustomerAPI.Service.Order
{
    using AuthCustomerAPI.Models.OrderDto;
    public interface IOrderService
    {
        IEnumerable<OrderReadDto> GetAllOrders();
        OrderReadDto? GetOrder(int id);
        OrderReadDto CreateOrder(OrderCreateDto createDto);
        void DeleteOrder(int id);
        void UpdateOrder(int id, OrderUpdateDto updateDto);
        IEnumerable<OrderReadDto> FilterOrder(decimal? totalAmount);
        bool PatchOrder(int id, OrderPatchDto patchDto);
    }
}
