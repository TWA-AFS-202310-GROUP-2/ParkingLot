using Xunit;
using ParkingLot;
using System.Collections.Generic;

namespace ParkingLotTests
{
    public class ParkingStrategyTests
    {
        [Fact]
        public void ParkCar_ChangeToSmartParkingStrategy_ParksInLotWithMostSpace()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(2);
            var parkingLot2 = new ParkingLot.ParkingLot(3); // This lot has more spaces

            // default strategy is StandardParkingStrategy
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();

            var ticket = parkingBoy.Park(car);

            // Assert that the car was parked in the lot with more spaces
            Assert.NotNull(ticket);
            Assert.Equal(1, parkingLot1.AvailablePositions); // This should still be 1 since parkingLot1 was chosen
            Assert.Equal(3, parkingLot2.AvailablePositions);

            parkingBoy.SetParkingStrategy(new SmartParkingStrategy());
            var ticket2 = parkingBoy.Park(car);

            Assert.NotNull(ticket2);
            Assert.Equal(1, parkingLot1.AvailablePositions);
            Assert.Equal(2, parkingLot2.AvailablePositions); // This should still be 2 since parkingLot2 was chosen
        }

        [Fact]
        public void FetchCar_ChangeToStandardParkingStrategy_FetchesCorrectly()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(2);
            var parkingLot2 = new ParkingLot.ParkingLot(3); // This lot has more spaces

            // set strategy to SmartParkingStrategy
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 }, new SmartParkingStrategy());
            var car = new Car();

            var ticket = parkingBoy.Park(car);

            // Assert that the car was parked in the lot with more spaces
            Assert.NotNull(ticket);
            Assert.Equal(2, parkingLot1.AvailablePositions);
            Assert.Equal(2, parkingLot2.AvailablePositions); // This should still be 2 since parkingLot2 was chosen

            parkingBoy.SetParkingStrategy(new StandardParkingStrategy());
            var ticket2 = parkingBoy.Park(car);

            Assert.NotNull(ticket2);
            Assert.Equal(1, parkingLot1.AvailablePositions); // This should still be 1 since parkingLot1 was chosen
            Assert.Equal(2, parkingLot2.AvailablePositions);
            var fetchedCar = parkingBoy.Fetch(ticket2);

            Assert.Equal(car, fetchedCar);
        }
    }
}
