using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace H1DeepSea_Crusing
{
    internal class AddCrew
    {
        Crew crew = new Crew();

        internal AddCrew()
        {
            NewCrewMember();
        }

        void NewCrewMember()
        {
            Console.Clear();
            Console.WriteLine("New Crew");

            while (crew.Name == null || crew.Name == "")
            {
                Console.WriteLine("Full name: ");
                Console.SetCursorPosition(11, Console.CursorTop - 1);
                crew.Name = Console.ReadLine();
                WriteUserData(); // Runs write user typed data method
            } // While loop for finding new travelers "name"

            while (crew.Email == null || crew.Email == "")
            {
                Console.WriteLine("Email: \t\t\t\t(Format: xxx@xxx or xxx@xxx.com)");
                Console.SetCursorPosition(7, Console.CursorTop - 1);
                string email = Console.ReadLine();
                if (IsValidEmail(email))
                    crew.Email = email;

                WriteUserData(); // Runs write user typed data method
            }  // While loop for finding new travelers "email

            while (crew.PhoneNumber == null || !(((crew.PhoneNumber.Length >= 6) && crew.PhoneNumber.Length <= 15) && crew.PhoneNumber.All(char.IsNumber)))
            {
                crew.PhoneNumber = null;
                WriteUserData();  // Runs write user typed data method

                Console.WriteLine("Phone number: \t\t(Format: XXXXXXXX)");
                Console.SetCursorPosition(14, Console.CursorTop - 1);
                crew.PhoneNumber = Console.ReadLine();
            }  // While loop for finding new travelers "phone number"

            while (crew.Role == Role.None)
            {
                Console.WriteLine("Role: \t( [1] for Captain, [2] for Sailor, [3] for Cook, [4] for Waiter, [5] for Machinist)");
                Console.SetCursorPosition(8, Console.CursorTop - 1);
                string SW = Console.ReadLine();
                switch (SW)
                {
                    case "1":
                        crew.Role = Role.Captain;
                        break;
                    case "2":
                        crew.Role = Role.Sailor;
                        break;
                    case "3":
                        crew.Role = Role.Cook;
                        break;
                    case "4":
                        crew.Role = Role.Waiter;
                        break;
                    case "5":
                        crew.Role = Role.Machinist;
                        break;
                    default:
                        break;
                }
                WriteUserData(); // Runs write user typed data method
            }  // While loop for finding new travelers "gender"

            while (crew.Worktimes.ShiftStart == new DateTime())
            {
                Console.WriteLine("Shift start: \t\t\t(Format: 28 11 1998 or 28/11/1998 or 28-11-1998)");
                Console.SetCursorPosition(13, Console.CursorTop - 1);

                string dateInput = Console.ReadLine(); // f.eks. "Jan 1, 2009"

                if (dateInput != "")
                {
                    DateTime userShiftStart;
                    DateTime.TryParse(dateInput, out userShiftStart);

                    crew.Worktimes.ShiftStart = userShiftStart;
                }
                WriteUserData(); // Runs write user typed data method
            }

            while (crew.Worktimes.ShiftEnd == new DateTime())
            {
                Console.WriteLine("Shift end: \t\t\t(Format: 28 11 1998 or 28/11/1998 or 28-11-1998)");
                Console.SetCursorPosition(11, Console.CursorTop - 1);

                string dateInput = Console.ReadLine(); // f.eks. "Jan 1, 2009"

                if (dateInput != "")
                {
                    DateTime userShiftEnd;
                    DateTime.TryParse(dateInput, out userShiftEnd);

                    crew.Worktimes.ShiftStart = userShiftEnd;
                }
                WriteUserData(); // Runs write user typed data method
            }

        }

        void WriteUserData() // Method for clearing and writing user typed info
        {
            Console.WriteLine("New Traveler");

            if (crew.Name != null && crew.Name != "") Console.WriteLine($"Full name: {crew.Name}");

            if (crew.Email != null && crew.Email != "") Console.WriteLine($"Email: {crew.Email}");

            if (crew.PhoneNumber != null && crew.PhoneNumber != "") Console.WriteLine($"Phone number: {crew.PhoneNumber}");

            if (crew.Role != Role.None) Console.WriteLine($"Role: {crew.Role}");


        }

        bool IsValidEmail(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public Crew GetCrew()
        {
            return crew;
        }
    }
}
