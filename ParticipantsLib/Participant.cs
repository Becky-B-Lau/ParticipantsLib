namespace ParticipantsLib
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public Participant()
        {
        }

        public Participant(int id, string name, int age, string country)
        {
            Id = id;
            Name = name;
            Age = age;
            Country = country;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, Country: {Country}";
        }

        public void ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new Exception("Name is required");
            }
            if (Name.Length < 2)
            {
                throw new Exception("Name must be at least 2 characters long");
            }
        }

        public void ValidateAge()
        {
            if (Age < 12)
            {
                throw new Exception("Age must be at least 12");
            }
        }

        public void ValidateCountry()
        {
            if (string.IsNullOrEmpty(Country))
            {
                throw new Exception("Country is required");
            }
            if (Country.Length < 3)
            {
                throw new Exception("Country must be at least 3 characters long");
            }
        }

        public void Validate()
        {
            ValidateName();
            ValidateAge();
            ValidateCountry();
        }

    }
}
