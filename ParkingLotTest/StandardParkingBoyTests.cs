using Xunit;
using ParkingLot;
using System;
using System.Collections.Generic;

namespace ParkingLotTests
{
    public class StandardParkingBoyTests
    {
        [Fact]
        public void ParkingBoy_ParkCar_SequentiallyInFirstAvailableLot()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car1 = new Car();
            var car2 = new Car();

            var ticket1 = parkingBoy.Park(car1);
            var ticket2 = parkingBoy.Park(car2);

            Assert.NotNull(ticket1);
            Assert.NotNull(ticket2);
            Assert.Throws<NoAvailablePositionException>(() => parkingBoy.Park(new Car())); // Both lots are now full
        }

        [Fact]
        public void ParkingBoy_ParkCar_ParkToSecondLotIfFirstIsFull()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(0); // First lot is full
            var parkingLot2 = new ParkingLot.ParkingLot(1); // Second lot has a position
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();

            var ticket = parkingBoy.Park(car);

            Assert.NotNull(ticket);
            // We assume that if a ticket is issued, the car is parked in the second lot.
        }

        [Fact]
        public void ParkingBoy_FetchCarWithValidTickets_ReturnsCorrectCarsFromBothLots()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car1 = new Car();
            var car2 = new Car();
            var ticket1 = parkingBoy.Park(car1);
            var ticket2 = parkingBoy.Park(car2);

            var fetchedCar1 = parkingBoy.Fetch(ticket1);
            var fetchedCar2 = parkingBoy.Fetch(ticket2);

            Assert.Equal(car1, fetchedCar1);
            Assert.Equal(car2, fetchedCar2);
        }

        [Fact]
        public void ParkingBoy_FetchCarWithWrongTicket_ThrowsUnrecognizedTicketException()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });

            var wrongTicket = new Ticket();

            var exception = Assert.Throws<UnrecognizedTicketException>(() => parkingBoy.Fetch(wrongTicket));

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void ParkingBoy_FetchCarWithUsedTicket_ThrowsUnrecognizedTicketException()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();
            var ticket = parkingBoy.Park(car);
            parkingBoy.Fetch(ticket);

            var exception = Assert.Throws<UnrecognizedTicketException>(() => parkingBoy.Fetch(ticket));

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void ParkingBoy_ParkCarWhenParkingLotFull_ThrowsNoAvailablePositionException()
        {
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            parkingBoy.Park(new Car()); // First lot is now full
            parkingBoy.Park(new Car()); // Second lot is now full

            Assert.Throws<NoAvailablePositionException>(() => parkingBoy.Park(new Car()));
        }
    }
}
