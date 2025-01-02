namespace SatrackBankSystem.Domain.Entities
{
    public class CDTAccount : FinancialProduct
    {
        public DateTime MaturityDate { get; private set; }
        public decimal DepositAmount { get; private set; }
        public decimal InterestRate { get; private set; }

        public CDTAccount(Guid id, string clientId, decimal depositAmount, DateTime maturityDate, decimal montlyInterest)
            : base(id, clientId)
        {
            if (maturityDate <= DateTime.UtcNow)
                throw new ArgumentException("La fecha de terminación debe ser en el futuro.", nameof(maturityDate));

            if (depositAmount <= 0)
                throw new ArgumentException("El monto de apertura del CDT debe ser mayor a cero.", nameof(maturityDate));

            MaturityDate = maturityDate;
            DepositAmount = depositAmount;
            InterestRate = montlyInterest;
        }
    }

}
