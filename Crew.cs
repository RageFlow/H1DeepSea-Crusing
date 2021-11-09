using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1DeepSea_Crusing
{
    public enum Role { None, Captain, Sailor, Cook, Waiter, Machinist }
    internal class Crew
    {
        static int nextId;
        public int Id { get; private set; }
        public Crew() { Id = Interlocked.Increment(ref nextId) + 1000; }

        public bool OnBoard { get; set; } = false;
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; } = Role.None;
        public Worktimes Worktimes { get; set; } = new Worktimes();
    }

    class Worktimes
    {
        public DateTime ShiftStart { get; set; } = new DateTime();
        public DateTime ShiftEnd { get; set; } = new DateTime();
    }
}
