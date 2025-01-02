namespace SatrackBankSystem.Domain.Entities
{
    public abstract class FinancialProduct
    {
        public Guid Id { get; private set; }
        public string ClientId { get; private set; }
        public DateTime CreationDate { get; private set; }

        protected FinancialProduct(Guid id, string clientId)
        {
            Id = id;
            ClientId = clientId;
            CreationDate = DateTime.UtcNow;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not FinancialProduct other)
                return false;

            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
