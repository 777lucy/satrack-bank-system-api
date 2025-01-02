namespace SatrackBankSystem.Domain.ValueObjects
{
    public class LegalRepresentative
    {
        public string Identification { get; private set; }
        public string Name { get; private set; }
        public Phone Phone { get; private set; }

        public LegalRepresentative(string identification, string name, Phone phone)
        {
            if (string.IsNullOrWhiteSpace(identification))
                throw new ArgumentException("Identification cannot be null or empty", nameof(identification));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty", nameof(name));

            Identification = identification;
            Name = name;
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }

        //override para validar que se compare como ValueObject
        public override bool Equals(object? obj)
        {
            if (obj is not LegalRepresentative other)
                return false;

            return Identification == other.Identification &&
                   Name == other.Name &&
                   Phone.Equals(other.Phone);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Identification, Name, Phone);
        }
    }

}
