namespace SatrackBankSystem.Infrastructure.Dtos
{
    public class ClientBalanceDto
    {
        public string ClientIdentification { get; set; } = string.Empty;
        public decimal TotalBalance { get; set; }
    }
}
