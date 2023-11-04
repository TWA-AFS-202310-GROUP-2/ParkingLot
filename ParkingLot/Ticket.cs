using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Ticket
    {
        public Guid Id { get; private set; }

        public Ticket()
        {
            Id = Guid.NewGuid();
        }
    }
}
