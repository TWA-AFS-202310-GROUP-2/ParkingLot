using Xunit;
using ParkingLot;
using System.Collections.Generic;

namespace ParkingLotTests
{
    public class SmartParkingBoyTests
    {
        [Fact]
        public void SmartParkingBoy_ParkCar_InLotWithMostSpaces()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(2); // This lot has more spaces
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();

            var ticket = smartParkingBoy.Park(car);

            // Assert that the car was parked in the lot with more spaces
            Assert.NotNull(ticket);
            Assert.Equal(1, parkingLot2.AvailablePositions);
            Assert.Equal(1, parkingLot1.AvailablePositions); // This should still be 1 since parkingLot2 was chosen
        }

        [Fact]
        public void SmartParkingBoy_ParkCar_InFirstLotIfBothHaveSameNumberOfSpaces()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();

            var ticket = smartParkingBoy.Park(car);

            // Assert that the car was parked in the first lot
            Assert.NotNull(ticket);
            Assert.Equal(0, parkingLot1.AvailablePositions);
            Assert.Equal(1, parkingLot2.AvailablePositions);
        }

        [Fact]
        public void SmartParkingBoy_FetchCarWithValidTickets_ReturnsCorrectCarsFromBothLots()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car1 = new Car();
            var car2 = new Car();
            var ticket1 = smartParkingBoy.Park(car1);
            var ticket2 = smartParkingBoy.Park(car2);

            var fetchedCar1 = smartParkingBoy.Fetch(ticket1);
            var fetchedCar2 = smartParkingBoy.Fetch(ticket2);

            Assert.Equal(car1, fetchedCar1);
            Assert.Equal(car2, fetchedCar2);
        }

        [Fact]
        public void SmartParkingBoy_FetchCarWithWrongTicket_ThrowsUnrecognizedTicketException()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();
            smartParkingBoy.Park(car);
            var wrongTicket = new Ticket();

            var exception = Assert.Throws<UnrecognizedTicketException>(() => smartParkingBoy.Fetch(wrongTicket));

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void SmartParkingBoy_FetchCarWithUsedTicket_ThrowsUnrecognizedTicketException()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();
            var ticket = smartParkingBoy.Park(car);
            smartParkingBoy.Fetch(ticket);

            var exception = Assert.Throws<UnrecognizedTicketException>(() => smartParkingBoy.Fetch(ticket));

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void SmartParkingBoy_ParkCarWhenParkingLotFull_ThrowsNoAvailablePositionException()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car1 = new Car();
            var car2 = new Car();
            smartParkingBoy.Park(car1);
            smartParkingBoy.Park(car2); // This should fill up the parking lots

            var car3 = new Car();
            var exception = Assert.Throws<NoAvailablePositionException>(() => smartParkingBoy.Park(car3));

            Assert.Equal("No available position.", exception.Message);
        }
    }
}
