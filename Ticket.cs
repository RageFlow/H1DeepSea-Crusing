using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1DeepSea_Crusing
{
    public enum DestinationEnum { None, Kalkan, Antalya, Istanbul }
    public enum TicketType { None, Economy, SecondClass, FirstClass }

    internal class Ticket
    {
        public DestinationEnum Origin { get; set; } = DestinationEnum.None;
        public DestinationEnum Destination { get; set; } = DestinationEnum.None;
        public TicketType Type { get; set; } = TicketType.None;
        public DestinationTimes TravelTimes { get; set; } = new DestinationTimes();

        public int AssignedTraveler { get; set; }

        public int CabinNr { get; private set; }

        static int nextTicketId;
        public int TicketId { get; private set; }
        public Ticket() { TicketId = Interlocked.Increment(ref nextTicketId); CabinNr = TicketId + 100; }
    }

    class DestinationTimes
    {
        public DateTime DepartureDate { get; set; } = new DateTime();
        public DateTime ArrivalDate { get; set; } = new DateTime();
    }
}
