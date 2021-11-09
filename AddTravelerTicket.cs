using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace H1DeepSea_Crusing
{
    internal class AddTravelerTicket
    {
        //public Traveler TicketSetup()
        //{
        Ticket ticket = new Ticket();
        Traveler traveler = new Traveler();

        internal AddTravelerTicket(){
            NewTicket();
            GetTraveler();
        }
        // Console.ReadKey().Key != ConsoleKey.Enter
        void NewTicket()
        {
            Console.Clear();
            Console.WriteLine("New Ticket");

            while (ticket.Origin == DestinationEnum.None)
            {
                Console.WriteLine();
                Console.WriteLine("Choose a departure location: [1] for Kalkan, [2] for Antalya, [3] for Istanbul");
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.KeyChar == '1')
                    ticket.Origin = DestinationEnum.Kalkan;
                else if (cki.KeyChar == '2')
                    ticket.Origin = DestinationEnum.Antalya;
                else if (cki.KeyChar == '3')
                    ticket.Origin = DestinationEnum.Istanbul;
                else
                { // Else when user doesn't type a appropriate option (letter or number outside of 1-3)
                    Console.Clear();
                    Console.WriteLine("Please input a correct option! (Only numbers 1-3)");
                    NewTicket();
                }
                WriteTicketData();
            }

            while (ticket.Destination == DestinationEnum.None)
            {
                Console.WriteLine();
                Console.WriteLine("Choose a Destination location: [1] for Kalkan, [2] for Antalya, [3] for Istanbul");
                string input = Console.ReadLine();
                if (input == "1")
                    ticket.Destination = DestinationEnum.Kalkan;
                else if (input == "2")
                    ticket.Destination = DestinationEnum.Antalya;
                else if (input == "3")
                    ticket.Destination = DestinationEnum.Istanbul;
                else
                { // Else when user doesn't type a appropriate option (letter or number outside of 1-3)
                    Console.Clear();
                    Console.WriteLine("Please input a correct option! (Only numbers 1-3)");
                    NewTicket();
                }
                WriteTicketData();
            }

            while (ticket.TravelTimes.DepartureDate == new DateTime()) // Date of Birth and Age
            {
                Console.WriteLine();
                Console.WriteLine("Type departure date. (Trip takes 3 days total)");
                Console.WriteLine("Departure Date: \t\t(Format: 28 11 2021 or 28/11/2021 or 28-11-2021)");
                Console.SetCursorPosition(16, Console.CursorTop - 1);

                string dateInput = Console.ReadLine(); // f.eks. "Jan 1, 2009"

                if (dateInput != "")
                {
                    DateTime tempDepartureDate;
                    DateTime tempArrivalDate;

                    DateTime.TryParse(dateInput, out tempDepartureDate);

                    if (tempDepartureDate > DateTime.Today)
                    {
                        ticket.TravelTimes.DepartureDate = tempDepartureDate;
                        tempArrivalDate = tempDepartureDate.AddDays(3);
                        ticket.TravelTimes.ArrivalDate = tempArrivalDate;
                    }
                }
                WriteTicketData(); // Runs write ticket data method
            }

            while (ticket.Type == TicketType.None)
            {
                Console.WriteLine();
                Console.WriteLine("Choose a ticket type: [1] for Economy Class, [2] for Second Class, [3] for First Class");
                string input = Console.ReadLine();
                if (input == "1")
                    ticket.Type = TicketType.Economy;
                else if (input == "2")
                    ticket.Type = TicketType.SecondClass;
                else if (input == "3")
                    ticket.Type = TicketType.FirstClass;
                else
                { // Else when user doesn't type a appropriate option (letter or number outside of 1-3)
                    Console.Clear();
                    Console.WriteLine("Please input a correct option! (Only numbers 1-3)");
                    NewTicket();
                }
                WriteTicketData();
            }

            NewTraveler();
        }

        void WriteTicketData() // Method for clearing and writing user typed info
        {
            Console.Clear();
            Console.WriteLine("New Ticket");

            if (ticket.Origin != DestinationEnum.None) Console.WriteLine($"Departure: {ticket.Origin}");

            if (ticket.Destination != DestinationEnum.None) Console.WriteLine($"Destination: {ticket.Destination}");

            if (ticket.TravelTimes.DepartureDate != new DateTime()) Console.WriteLine($"Departure Date: {ticket.TravelTimes.DepartureDate.ToString("d")}");
            if (ticket.TravelTimes.ArrivalDate != new DateTime()) Console.WriteLine($"Arrival Date: {ticket.TravelTimes.ArrivalDate.ToString("d")} - 3 Days");

            if (ticket.Type != TicketType.None) Console.WriteLine($"Type: {ticket.Type} \n");

        } // Method for clearing and writing user typed info

        void NewTraveler()
        {
            Console.Clear();
            WriteTicketData();
            Console.WriteLine("New Traveler");

            while (traveler.Name == null || traveler.Name == "")
            {
                Console.WriteLine("Full name: ");
                Console.SetCursorPosition(11, Console.CursorTop - 1);
                traveler.Name = Console.ReadLine();
                WriteUserData(); // Runs write user typed data method
            } // While loop for finding new travelers "name"

            while (traveler.Email == null || traveler.Email == "")
            {
                Console.WriteLine("Email: \t\t\t\t(Format: xxx@xxx or xxx@xxx.com)");
                Console.SetCursorPosition(7, Console.CursorTop - 1);
                string email = Console.ReadLine();
                if (IsValidEmail(email))
                    traveler.Email = email;

                WriteUserData(); // Runs write user typed data method
            }  // While loop for finding new travelers "email

            while (traveler.PhoneNumber == null || !(((traveler.PhoneNumber.Length >= 6) && traveler.PhoneNumber.Length <= 15) && traveler.PhoneNumber.All(char.IsNumber)))
            {
                traveler.PhoneNumber = null;
                WriteUserData();  // Runs write user typed data method

                Console.WriteLine("Phone number: \t\t(Format: XXXXXXXX)");
                Console.SetCursorPosition(14, Console.CursorTop - 1);
                traveler.PhoneNumber = Console.ReadLine();
            }  // While loop for finding new travelers "phone number"

            while (traveler.Gender == GenderType.None)
            {
                Console.WriteLine("Gender: \t( [1] for Male, [2] for female )");
                Console.SetCursorPosition(8, Console.CursorTop - 1);
                string SW = Console.ReadLine();
                switch (SW)
                {
                    case "1":
                        traveler.Gender = GenderType.Male;
                        break;
                    case "2":
                        traveler.Gender = GenderType.Female;
                        break;
                    default:
                        break;
                }
                WriteUserData(); // Runs write user typed data method
            }  // While loop for finding new travelers "gender"

            while (traveler.DoB == new DateTime()) // Date of Birth and Age
            {
                Console.WriteLine("Date of Birth: \t\t\t(Format: 28 11 1998 or 28/11/1998 or 28-11-1998)");
                Console.SetCursorPosition(15, Console.CursorTop - 1);

                string dateInput = Console.ReadLine(); // f.eks. "Jan 1, 2009"

                if (dateInput != "")
                {
                    DateTime userBirthdate;
                    DateTime.TryParse(dateInput, out userBirthdate);

                    if (userBirthdate < DateTime.Today)
                    {
                        TimeSpan ts = DateTime.Today - userBirthdate;
                        DateTime dt = new DateTime(ts.Ticks);

                        if (dt.Year < 98)
                        {
                            traveler.DoB = userBirthdate;
                        }
                    }
                }
                WriteUserData(); // Runs write user typed data method
            } // Date of Birth and Age

            while (traveler.Description == null || traveler.Description == "")
            {
                Console.WriteLine("Do you want to add a description with extra details? \t[y] for yes, [n] for no");
                Console.SetCursorPosition(53, Console.CursorTop - 1);
                string input = Console.ReadLine();
                if (input == "y" || input == "Y")
                {
                    while (traveler.Description == null || traveler.Description == "")
                    {
                        WriteUserData(); // Runs write user typed data method
                        Console.WriteLine("Description: ");
                        Console.SetCursorPosition(13, Console.CursorTop - 1);
                        string input2 = Console.ReadLine();
                        traveler.Description = input2;
                    }
                }
                else if (input == "n" || input == "N")
                    traveler.Description = "NONE";

                WriteUserData(); // Runs write user typed data method
            }  // While loop for new travelers "description" (If user wants to aff extra details)

            while (traveler.Pets.Count == 0)
            {
                Console.WriteLine("Do you own any pets? \t[y] for yes, [n] for no");
                Console.SetCursorPosition(21, Console.CursorTop - 1);
                string input = Console.ReadLine();
                if (input == "y" || input == "Y")
                {
                    bool petSetup = true;
                    while (petSetup)
                    {
                        string petName = null;
                        string petRace = null;

                        while (petName == null)
                        {
                            Console.WriteLine("Pets name: ");
                            Console.SetCursorPosition(11, Console.CursorTop - 1);
                            string input2 = Console.ReadLine();
                            petName = input2;
                        }

                        while (petRace == null)
                        {
                            Console.WriteLine("Pets race: ");
                            Console.SetCursorPosition(11, Console.CursorTop - 1);
                            string input2 = Console.ReadLine();
                            petRace = input2;
                        }

                        traveler.Pets.Add(new PetDesc() { Name = petName, Race = petRace });

                        while (true)
                        {
                            Console.WriteLine("Do you have any other pets? \t[y] for yes, [n] for no");
                            Console.SetCursorPosition(28, Console.CursorTop - 1);
                            string input3 = Console.ReadLine();
                            if (input3 == "y" || input3 == "Y")
                                break;
                            else if (input3 == "n" || input3 == "N")
                                petSetup = false;
                            break;
                        }
                    }
                }
                else if (input == "n" || input == "N")
                    break;

                WriteUserData(); // Runs write user typed data method
            } // While loop for new travelers "pets" (If user owns pets)

            ticket.AssignedTraveler = traveler.Id;
            traveler.Ticket = ticket;

            Console.WriteLine();
            Console.WriteLine($"Traveler with ticket: {traveler.Name}, has successfully been added");
            Console.WriteLine("Press ENTER to go back to menu");
            Console.ReadLine();
            Console.Clear();
        }

        void WriteUserData() // Method for clearing and writing user typed info
        {
            WriteTicketData();
            Console.WriteLine("New Traveler");

            if (traveler.Name != null && traveler.Name != "") Console.WriteLine($"Full name: {traveler.Name}");

            if (traveler.Email != null && traveler.Email != "") Console.WriteLine($"Email: {traveler.Email}");

            if (traveler.PhoneNumber != null && traveler.PhoneNumber != "") Console.WriteLine($"Phone number: {traveler.PhoneNumber}");

            if (traveler.Gender != GenderType.None) Console.WriteLine($"Gender: {traveler.Gender.ToString()}");

            if (traveler.DoB != new DateTime())
            {
                Console.WriteLine($"Date of Birth: {traveler.DoB.ToString("d")}");
                Console.WriteLine($"Age: {traveler.Age()}");
            }

            if (traveler.Description != null && traveler.Description != "NONE" && traveler.Description != "") Console.WriteLine($"Description: {traveler.Description}");

            if (traveler.Pets.Count > 0)
            {
                foreach (var pet in traveler.Pets)
                {
                    Console.WriteLine($"(Pet) - Name: {pet.Name}, Race: {pet.Race} ");
                }
            }
        } // Method for clearing and writing user typed info

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
    
        public Traveler GetTraveler()
        {
            return traveler;
        }
    }
}
