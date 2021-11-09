
using H1DeepSea_Crusing;
using System.Globalization;

List<Traveler> TravelerList = new List<Traveler>();
List<Crew> CrewList = new List<Crew>();

void ChooseOption()
{

    List<PetDesc> Pets = new List<PetDesc>();
    Pets.Add(new PetDesc() { Name = "bob", Race = "YES" });

    TravelerList.Add(new Traveler()
    {
        Name = "bob marley",
        Email = "Email@jsid.dk",
        PhoneNumber = "28888031",
        Gender = GenderType.Male,
        DoB = DateTime.Parse("28 11 98"),
        Description = "NONE",
        Pets = Pets,
        Ticket = new Ticket(),
        OnBoard = false
    });
    CrewList.Add(new Crew()
    {
        Name = "bob marley",
        Email = "Email@jsid.dk",
        PhoneNumber = "28888031",
        Role = Role.Waiter,
        Worktimes = new Worktimes() { ShiftEnd = DateTime.Today, ShiftStart = DateTime.Today }
    });

    Console.Clear();
    Console.WriteLine("MENU");
    Console.WriteLine(" [1] for Traveler menu \n [2] for Crew menu");
    string menuInput = Console.ReadLine();
    if (menuInput == "1") // If input = 1, go to traveler setup
    {
        Console.Clear();
        Console.WriteLine("Traveler MENU: \n [1] for new Ticket/Traveler \n [2] for Checkin (On Board) \n [ANY KEY] for Go back");

        string input2 = Console.ReadLine();
        if (input2 == "1") // If input = 1, go to traveler setup
            NewTicketAndTraveler();
        else if (input2 == "2") // If input = 2
            CheckInTraveler();
        else
        { // Else when user doesn't type a appropriate option (letter or number outside of 1-2)
            Console.Clear();
            Console.WriteLine("Please input a correct option! (Only numbers)");
            ChooseOption();
        }
    }
    else if (menuInput == "2") // If input = 2, go to new ticket setup
    {
        Console.Clear();
        Console.WriteLine("Crew MENU: \n [1] for new Crew member \n [2] for Checkin (On Board) \n [3] for list all Crew \n [4] for list of all Travelers \n [ANY KEY] for Go back");

        string input2 = Console.ReadLine();
        if (input2 == "1") // If input = 1, go to crew setup
            NewCrew();
            //CrewSetup();
        else if (input2 == "2") // If input = 2
            CheckInCrew();
        else if (input2 == "3") // If input = 3
            ShowAllCrew();
        else if (input2 == "4") // If input = 4
            ShowAllPassengers();
        else
        { // Else when user doesn't type a appropriate option (letter or number outside of 1-4)
            Console.Clear();
            Console.WriteLine("Please input a correct option! (Only numbers)");
            ChooseOption();
        }
    }
    else
    { // Else when user doesn't type a appropriate option (letter or number outside of 1-2)
        Console.Clear();
        Console.WriteLine("Please input a correct option! (Only numbers 1-2)");
        ChooseOption();
    }
}

ChooseOption();

void NewTicketAndTraveler()
{
    AddTravelerTicket tempTraveler = new();
    TravelerList.Add(tempTraveler.GetTraveler());
    ChooseOption();

}

void CheckInTraveler()
{
    Console.Clear();
    Console.WriteLine("Check in Traveler - Type [0] for going back");
    Console.WriteLine();
    Console.Write("Full name, Phone number or Email of Traveler: \t\t\t(Case sensitive!)");
    string input = Console.ReadLine();

    if (input == "0")
    {
        ChooseOption();
    }

    if(input != null || input != ""){

        var foundTraveler = TravelerList.FirstOrDefault(o => o.Name == input);
        if(foundTraveler == null)
            foundTraveler = TravelerList.FirstOrDefault(o => o.PhoneNumber == input);
        else if (foundTraveler == null)
            foundTraveler = TravelerList.FirstOrDefault(o => o.Email == input);

        if (foundTraveler != null && foundTraveler.Ticket.TicketId != null && foundTraveler.OnBoard != true)
        {
            Console.Clear();
            Console.WriteLine("Check in Traveler");
            Console.WriteLine();
            Console.WriteLine($"Traveler: '{foundTraveler.Name}' with ID: {foundTraveler.Id} was found");
            Console.WriteLine($"--------- Trip data ---------");
            Console.WriteLine($"Departure: {foundTraveler.Ticket.Origin} at date: {foundTraveler.Ticket.TravelTimes.DepartureDate.ToString("d")}");
            Console.WriteLine($"Arrival: {foundTraveler.Ticket.Destination} at date: {foundTraveler.Ticket.TravelTimes.ArrivalDate.ToString("d")}");
            Console.WriteLine();
            Console.WriteLine("Do you want to check this traveler in? [y] for yes, [n] for abort");

            string input2 = Console.ReadLine();
            switch (input2)
            {
                case "y": case "Y":
                    foundTraveler.OnBoard = true;
                    Console.WriteLine($"Traveler {foundTraveler.Name} has been checked in!");
                    Console.WriteLine("Press ENTER to go to menu");
                    Console.ReadLine();
                    ChooseOption();
                    break;
                case "n": case "N":
                    Console.WriteLine("Checkin has been aborted!");
                    Console.WriteLine("Press ENTER to go back");
                    Console.ReadLine();
                    ChooseOption();
                    break;
                default:
                    CheckInTraveler();
                    break;
            }
        }
        else if(foundTraveler != null && foundTraveler.Ticket.TicketId != null && foundTraveler.OnBoard == true)
        {
            Console.WriteLine($"Traveler: '{foundTraveler.Name}' is already checked in!");
            Console.WriteLine("Press ENTER to go to menu");
            Console.ReadLine();
            ChooseOption();
        }
        else
        {
            Console.WriteLine($"Traveler: {input} could not found!");
            Console.WriteLine("Please try with different input.");
            Console.WriteLine("Press enter to try again!");
            Console.ReadLine();
            CheckInTraveler();
        }
    }
    else
    {
        CheckInTraveler();
    }
}

void NewCrew()
{
    AddCrew tempCrew = new();
    CrewList.Add(tempCrew.GetCrew());
    ChooseOption();
}

void CheckInCrew()
{
    Console.Clear();
    Console.WriteLine("Check in Crew - Type [0] for going back");
    Console.WriteLine();
    Console.Write("Full name, Phone number or Email of Crew: \t\t\t(Case sensitive!)");
    string input = Console.ReadLine();

    if (input == "0")
        ChooseOption();

    if (input != null)
    {
        var foundCrew = CrewList.FirstOrDefault(o => o.Name == input);
        if (foundCrew == null)
            foundCrew = CrewList.FirstOrDefault(o => o.PhoneNumber == input);
        else if (foundCrew == null)
            foundCrew = CrewList.FirstOrDefault(o => o.Email == input);

        if (foundCrew != null && foundCrew.OnBoard != true)
        {
            Console.Clear();
            Console.WriteLine("Check in Crew");
            Console.WriteLine();
            Console.WriteLine($"Crew: '{foundCrew.Name}' with ID: {foundCrew.Id} was found");
            Console.WriteLine();
            Console.WriteLine("Do you want to check this Crew in? [y] for yes, [n] for abort");

            string input2 = Console.ReadLine();
            switch (input2)
            {
                case "y":
                case "Y":
                    foundCrew.OnBoard = true;
                    Console.WriteLine($"Crew {foundCrew.Name} has been checked in!");
                    Console.WriteLine("Press ENTER to go to menu");
                    Console.ReadLine();
                    ChooseOption();
                    break;
                case "n":
                case "N":
                    Console.WriteLine("Checkin has been aborted!");
                    Console.WriteLine("Press ENTER to go back");
                    Console.ReadLine();
                    ChooseOption();
                    break;
                default:
                    CheckInCrew();
                    break;
            }
        }
        else if (foundCrew != null && foundCrew.OnBoard == true)
        {
            Console.WriteLine($"Crew: '{foundCrew.Name}' is already checked in!");
            Console.WriteLine("Press ENTER to go to menu");
            Console.ReadLine();
            ChooseOption();
        }
        else
        {
            Console.WriteLine($"Crew: {input} could not found!");
            Console.WriteLine("Please try with different input.");
            Console.WriteLine("Press enter to try again!");
            Console.ReadLine();
            CheckInCrew();
        }
    }
    else
    {
        CheckInCrew();
    }
}

void ShowAllPassengers()
{
    Console.Clear();
    Console.WriteLine("All travelers:");
    Console.WriteLine();
    foreach (var t in TravelerList)
    {
        int defaultTop = Console.CursorTop;
        int tempTop = Console.CursorTop;

        string validTicket = "Invalid";
        if (t.Id == t.Ticket.AssignedTraveler) { validTicket = "Valid"; }

        //Console.Write($"ID: {t.Id,-5} Type: {t.GetType().Name,-10} Name: {t.Name,-12} Age: {t.Age,-12} DoB: {t.DoB.ToString("D"),-20} ");
        Console.WriteLine($"ID {t.Id} - Ticket: {validTicket}");
        Console.WriteLine($"Checked in: {t.OnBoard}");
        Console.WriteLine($"Created: {t.DateCreated.ToString("d")}");

        Console.SetCursorPosition(24, defaultTop); Console.Write($" Name {t.Name}");
        Console.SetCursorPosition(24, Console.CursorTop + 1); Console.Write($" Email: {t.Email}");
        Console.SetCursorPosition(24, Console.CursorTop + 1); Console.Write($" Phone: {t.PhoneNumber}");

        Console.SetCursorPosition(48, defaultTop); Console.Write($" Gender: {t.Gender}");
        Console.SetCursorPosition(48, Console.CursorTop + 1); Console.Write($" Age: {t.Age()}");
        Console.SetCursorPosition(48, Console.CursorTop + 1); Console.Write($" DoB: {t.DoB.ToString("d")}");

        Console.SetCursorPosition(72, defaultTop); Console.Write($" Pets: ");
        if (t.Pets.Count > 0)
        {
            foreach (var p in t.Pets)
            {
                Console.SetCursorPosition(72, Console.CursorTop + 1); Console.Write($" Name: {p.Name}, Race: {p.Race}");
            }

            if (t.Pets.Count > 2)
            {
                tempTop = Console.CursorTop - 2;
            }
        }

        Console.SetCursorPosition(96, defaultTop); Console.Write($" Description:");
        Console.SetCursorPosition(96, Console.CursorTop + 1); Console.Write($" {t.Description}");

        Console.SetCursorPosition(96, tempTop + 3);
        Console.WriteLine();
    }

    Console.WriteLine("Press ENTER to go back to menu");
    Console.ReadLine();

    ChooseOption();
}

void ShowAllCrew()
{
    Console.Clear();
    Console.WriteLine("All crew:");
    Console.WriteLine();
    foreach (var c in CrewList)
    {
        int defaultTop = Console.CursorTop;
        int tempTop = Console.CursorTop;
        //Console.Write($"ID: {t.Id,-5} Type: {t.GetType().Name,-10} Name: {t.Name,-12} Age: {t.Age,-12} DoB: {t.DoB.ToString("D"),-20} ");
        Console.WriteLine($" ID {c.Id}");
        Console.WriteLine($" Name {c.Name}");
        Console.WriteLine($" Role: {c.Role}");

        Console.SetCursorPosition(24, defaultTop); Console.Write($" Email: {c.Email}");
        Console.SetCursorPosition(24, Console.CursorTop + 1); Console.Write($" Phone: {c.PhoneNumber}");
        Console.SetCursorPosition(24, Console.CursorTop + 1); Console.Write($"");

        Console.SetCursorPosition(48, defaultTop); Console.Write($" Worktimes:");
        Console.SetCursorPosition(48, Console.CursorTop + 1); Console.Write($" Shift Start: {c.Worktimes.ShiftStart}");
        Console.SetCursorPosition(48, Console.CursorTop + 1); Console.Write($" Shift End: {c.Worktimes.ShiftEnd}");

        Console.WriteLine();
    }

    Console.WriteLine("Press ENTER to go back to menu");
    Console.ReadLine();

    ChooseOption();
}