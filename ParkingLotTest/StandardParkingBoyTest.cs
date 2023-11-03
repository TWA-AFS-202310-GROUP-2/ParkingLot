using Parking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingBoyTest
    {
        [Fact]
        public void Should_park_car_to_second_parking_lot_when_the_first_parking_lot_is_full()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new ParkingLot("first"),
            new ParkingLot("second"),
        };
            StandardParkingBoy stupidParkingBoy = new StandardParkingBoy(parkingLots);

            for (int i = 0; i < 9; i++)
            {
                stupidParkingBoy.Park("car");
            }

            string ticket = stupidParkingBoy.Park("car");
            string ticket2 = stupidParkingBoy.Park("car");

            Assert.Equal("first", ticket.Split("-")[0]);
            Assert.Equal("second", ticket2.Split("-")[0]);
        }
    }
}
