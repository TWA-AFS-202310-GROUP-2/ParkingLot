using Parking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_park_car_to_parking_lot_with_most_empty_space_when_Park()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new ParkingLot("first"),
            new ParkingLot("second"),
        };
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);

            string ticket = smartParkingBoy.Park("car");
            string ticket2 = smartParkingBoy.Park("car");

            Assert.Equal("first", ticket.Split("-")[0]);
            Assert.Equal("second", ticket2.Split("-")[0]);
        }
    }
}
