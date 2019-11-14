namespace OnlineRetailPortal.MongoDBStore
{
    public class StorePrice
    {
        public string Currency { get; set; }
        public double Amount { get; set; }
        public bool IsNegotiable { get; set; }
    }
}
