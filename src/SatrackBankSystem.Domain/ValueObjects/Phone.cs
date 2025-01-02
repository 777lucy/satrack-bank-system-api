using System.Text.RegularExpressions;

namespace SatrackBankSystem.Domain.ValueObjects
{
    public class Phone
    {
        public string Number { get; private set; }

        public Phone(string number)
        {
            if (!IsValidPhone(number))
                throw new ArgumentException("el teléfono no cumple la estructura del país, verificar.");

            Number = number;
        }

        private bool IsValidPhone(string number)
        {
            if (string.IsNullOrEmpty(number))
                return false;

            string pattern = @"^(\+57|0057)?(3\d{9}|\d{7})$";

            return Regex.IsMatch(number, pattern);
        }
    }

}
