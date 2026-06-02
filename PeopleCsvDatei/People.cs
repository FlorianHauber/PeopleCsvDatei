namespace People
{
    internal class People
    {
        private string _lastName = "";
        private string _firstName = "";
        private int _yearOfBirth = 0;

        public string GetLastName()
        {
            return _lastName;
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public int GetYearOfBirth()
        {
            return _yearOfBirth;
        }

        public void SetLastName(string lastName)
        {
            _lastName = lastName;
        }

        public void SetFirstName(string firstName)
        {
            _firstName = firstName;
        }

        public void SetYearOfBirth(int yearOfBirth)
        {
            _yearOfBirth = yearOfBirth;
        }
    }
}