namespace OnlineRetailPortal.Core
{
    public class Value
    {
        public double Amount { get; set; }
        public string Currency { get; set; }

        public Value(double amount, string currency)
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