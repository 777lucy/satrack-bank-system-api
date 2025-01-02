using SatrackBankSystem.Domain.Enums;
using SatrackBankSystem.Domain.ValueObjects;

public class BusinessClient : Client
{
    public LegalRepresentative LegalRepresentative { get; private set; }

    public BusinessClient(string identification, string name, LegalRepresentative legalRepresentative, ClientType clientType)
        : base(identification, name, clientType)
    {
        Identification = identification;
        Name = name;
        LegalRepresentative = legalRepresentative;
        ClientType = clientType;
    }
}
