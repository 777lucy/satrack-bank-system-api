namespace SatrackBankSystem.Infrastructure.Dtos
{
    public class GroupedTopClientsBalanceDto
    {
        public int ClientType { get; set; }
        public IEnumerable<ClientBalanceDto>? Clients { get; set; }
    }
}
