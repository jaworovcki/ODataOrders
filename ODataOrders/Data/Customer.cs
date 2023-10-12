namespace ODataOrders.Data
{
	public class Customer
	{
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string CountryId { get; set; } = string.Empty;

        public List<Order> Orders { get; set; } = new();
    }
}
