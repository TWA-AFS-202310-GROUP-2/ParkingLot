using Parking;
using Parking.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingBoy = Parking.Strategy.ParkingBoy;

namespace ParkingLotTest
{
    public class StrategyParkingBoyTest
    {
        [Fact]
        public void Should_create_parking_boy_with_standard_parking_strategy_when_add_new_parking_boy()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new ParkingLot("first"),
            new ParkingLot("second"),
        };
            StandardParkingStrategy standardParkingStrategy = new StandardParkingStrategy();
            ParkingBoy standardParkingBoy = new ParkingBoy(standardParkingStrategy, parkingLots);

            for (int i = 0; i < 9; i++)
            {
                standardParkingBoy.Park("car");
            }

            string ticket = standardParkingBoy.Park("car");
            string ticket2 = standardParkingBoy.Park("car");

            Assert.Equal("first", ticket.Split("-")[0]);
            Assert.Equal("second", ticket2.Split("-")[0]);
        }

        [Fact]
        public void Should_create_parking_boy_with_smart_parking_strategy_when_add_new_parking_boy()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new ParkingLot("first"),
            new ParkingLot("second"),
        };
            SmartParkingStrategy smartParkingStrategy = new SmartParkingStrategy();
            ParkingBoy smartParkingBoy = new ParkingBoy(smartParkingStrategy, parkingLots);

            string ticket = smartParkingBoy.Park("car");
            string ticket2 = smartParkingBoy.Park("car");

            Assert.Equal("first", ticket.Split("-")[0]);
            Assert.Equal("second", ticket2.Split("-")[0]);
        }
    }
}
