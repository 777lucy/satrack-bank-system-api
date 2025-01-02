namespace SatrackBankSystem.Domain.Entities
{
    public class SavingsAccount : FinancialProduct
    {
        public const decimal _INTEREST_RATE = 0.004m;
        public decimal Balance { get; private set; }

        public SavingsAccount(Guid id, string clientId, decimal balance)
            : base(id, clientId)
        {
            Balance = balance;
        }

        public void SetNewBalance(decimal amount)
        {
            if (amount < 0 && Math.Abs(amount) > Balance)
            {
                throw new ArgumentException("El monto de la transacción excede el saldo disponible.");
            }

            Balance += amount;
        }
    }
}
