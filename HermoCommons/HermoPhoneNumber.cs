using System.Text.Json.Serialization;

namespace HermoCommons
{
    public class HermoPhoneNumber
    {
        public HermoPhoneNumber()
        {
            number = "3333333333";
        }
        private static byte NUMBER_LENGHT = 10;
        private string number;

        [JsonPropertyName("number")]
        public string Number
        {
            get
            {
                return number.Insert(3, " ");
            }

            set
            {
                if (number.Length != NUMBER_LENGHT) throw new InvalidNumberException();

                try
                {
                    long.Parse(value);
                }
                catch (FormatException)
                {
                    throw new InvalidNumberException();
                }

                number = value;
            }
        }
    }

    public class InvalidNumberException : Exception
    {
        public InvalidNumberException()
            : base("A phone number must contain only numbers and be exactly 10 digits long.") { }
    }
}