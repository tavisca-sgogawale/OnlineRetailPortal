namespace ERPBackend.Models
{
    public class Price : IPrice
    {
        public double Amount { get; set; }
        public bool IsNegotiable { get; set; }

    }
}