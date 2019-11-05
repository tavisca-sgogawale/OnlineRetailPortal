namespace OnlineRetailPortal.Contracts
{
    public class Money
    {
        public double Amount { get; set; }
        public string Currency { get; set; }

        public Money(double amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }
        public override string ToString()
        {
            return this.MemberwiseClone().ToString();
        }
    }
}