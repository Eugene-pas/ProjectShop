namespace DemoApi.Models.OrderModels
{
    public class CreateOrderModel
    {
        public string Adress { get; set; }
        public long CustomerId { get; set; }
        public long DeliveryId { get; set; }
    }
}
