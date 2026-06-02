/**********************************
 * Author: Florian Hauber
 * Class: 1IHIF
 * Date: 2026-02-06
 * Description: This program allows the user to enter information about people (last name, first name, year of birth) and then displays all entered persons. It also allows the user to filter the list of persons based on a minimum age.
 * ********************************/

namespace People
{
    internal class Program
    {
        private static People person = new People(); //i would have to pass it all the time if i dont declare it as static
        private static string[] persons = new string[10];
        private static string[] personDetails = new string[persons.Length];

        private static void Main(string[] args)
        {
            GetAllInfo();

            Console.Clear();
            Console.WriteLine("All entered persons:");
            DisplayAllPersons();

            Console.Write("Press enter to display persons filtered by age... ");
            Console.ReadLine();

            FilterListWithAge();

            Console.Write("Press enter to exit ...");
            Console.ReadLine();
        }

        private static string[] Split(string s, char delimiter)
        {
            int counter = 0;
            string[] result = new string[3];

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == delimiter)
                {
                    counter++;
                }
                else
                {
                    result[counter] += s[i];
                }
            }

            return result;
        }

        private static void FilterListWithAge()
        {
            int minimumAge = 0;
            int age = 0;

            Console.Clear();
            Console.Write("How old should the person at least be to be included in the filtered list? ");

            GetMinAge(out minimumAge);

            for (int i = 0; i < persons.Length; i++)
            {
                if (persons[i] != null)
                {
                    personDetails = Split(persons[i], ' ');
                    if (personDetails.Length == 3 && int.TryParse(personDetails[2], out int yearOfBirth))
                    {
                        age = DateTime.Now.Year - yearOfBirth; // Calculate age based on the current year and the year of birth
                        if (age >= minimumAge)
                        {
                            Console.WriteLine(persons[i]);
                        }
                    }
                }
            }
        }

        private static void GetMinAge(out int minimumAge)
        {
            bool valid = false;
            minimumAge = 0;

            while (!valid)
            {
                if (int.TryParse(Console.ReadLine(), out minimumAge) && minimumAge >= 0)
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid minimum age.");
                    Console.ResetColor();
                }
            }
        }

        private static void DisplayAllPersons()
        {
            bool end = false;

            for (int i = 0; i < persons.Length && !end; i++)
            {
                if (persons[i] != null)
                {
                    Console.WriteLine(persons[i]);
                }
                else
                {
                    end = true;
                }
            }
        }

        private static void GetAllInfo()
        {
            bool end = false;

            for (int i = 0; i < persons.Length && !end; i++)
            {
                GetLastName(i);

                if (person.GetLastName() != null && person.GetLastName() == "")
                {
                    end = true;
                }
                else
                {
                    persons[i] += person.GetLastName() + " ";

                    GetFirstName(i);

                    persons[i] += person.GetFirstName() + " ";

                    GetYearOfBirth(i);

                    persons[i] += person.GetYearOfBirth().ToString();
                }

                Console.Clear();
            }
        }

        private static void GetLastName(int i)
        {
            Console.Write("What do you want the last name to be for person " + (i + 1) + "? ");
            person.SetLastName(Console.ReadLine());
        }

        private static void GetFirstName(int i)
        {
            Console.Write("What do you want the first name to be for person " + (i + 1) + "? ");
            person.SetFirstName(Console.ReadLine());
        }

        private static void GetYearOfBirth(int i)
        {
            bool valid = false;
            int yearOfBirth = 0;

            while (!valid)
            {
                Console.Write("What do you want the year of birth to be for person " + (i + 1) + "? ");
                if (int.TryParse(Console.ReadLine(), out yearOfBirth) && yearOfBirth > 0)
                {
                    person.SetYearOfBirth(yearOfBirth);
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid year of birth.");
                    Console.ResetColor();
                }
            }
        }
    }
}