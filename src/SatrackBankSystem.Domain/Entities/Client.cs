using SatrackBankSystem.Domain.Enums;

public abstract class Client(string name, string identification, ClientType clientType)
{
    public string Identification { get; protected set; } = identification;
    public string Name { get; protected set; } = name;
    public ClientType ClientType { get; protected set; } = clientType;
}

