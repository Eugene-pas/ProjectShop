namespace DemoApi.Models.OrderModels
{
    public class UpdateOrderModel
    {
        public long Id { get; set; }
        public string Adress { get; set; }
        public long CustomerId { get; set; }
        public long DeliveryId { get; set; }
    }
}
