using SatrackBankSystem.Domain.Enums;

public class IndividualClient : Client
{
    public IndividualClient(string identification, string name, ClientType clientType) : base(identification, name, clientType)
    {
        Identification = identification;
        Name = name;
        ClientType = clientType;
    }

}
