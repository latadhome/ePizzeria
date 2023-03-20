namespace ePizzeriaHub.WebUI.Models
{
    public class ToppingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int CartItemId { get; set; }

        public int Quantity { get; set; }
    }
}
