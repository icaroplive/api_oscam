namespace webapi.Models
{
    public class PedidoPagSeguro
    {
        public string currency { get; set; }
        public int itemId1 { get; set; }
        public int itemQuantity1 { get; set; }
        public decimal itemAmount1 { get; set; }
        public string itemDescription1 { get; set; }
    }
}