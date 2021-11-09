using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1DeepSea_Crusing
{
    public enum GenderType { None, Male, Female }
    internal class Traveler
    {
        static int nextId;
        public int Id { get; private set; }
        public Traveler(){ Id = Interlocked.Increment(ref nextId); }

        public Ticket Ticket { get; set; }
        public bool OnBoard { get; set; } = false;

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public GenderType Gender { get; set; } = GenderType.None;
        public DateTime DoB { get; set; } = new DateTime();

        public int Age()
        {
            TimeSpan ts = DateTime.Today - DoB;
            DateTime dt = new DateTime(ts.Ticks);
            int age = dt.Year;
            return age;
        }

        public string Description { get; set; }
        public List<PetDesc> Pets { get; set; } = new List<PetDesc>();
        public DateTime DateCreated { get { return DateTime.Now; } }
    }

    class PetDesc
    {
        public string Name { get; set; }
        public string Race { get; set; }
    }
}
