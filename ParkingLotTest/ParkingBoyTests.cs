using Xunit;
using ParkingLot;
using System;

namespace ParkingLotTests
{
    public class ParkingBoyTests
    {
        [Fact]
        public void ParkingBoy_ParkCar_ReturnsTicket()
        {
            var parkingLot = new ParkingLot.ParkingLot(10);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();

            var ticket = parkingBoy.Park(car);

            Assert.NotNull(ticket);
        }

        [Fact]
        public void ParkingBoy_FetchCarWithValidTicket_ReturnsCar()
        {
            var parkingLot = new ParkingLot.ParkingLot(10);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var ticket = parkingBoy.Park(car);

            var fetchedCar = parkingBoy.Fetch(ticket);

            Assert.Equal(car, fetchedCar);
        }

        [Fact]
        public void ParkingBoy_FetchCarWithValidTickets_ReturnsCorrectCars()
        {
            var parkingLot = new ParkingLot.ParkingLot(10);
            var parkingBoy = new ParkingBoy(parkingLot);
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
            var parkingLot = new ParkingLot.ParkingLot(10);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            parkingBoy.Park(car);
            var wrongTicket = new Ticket();

            var exception = Assert.Throws<UnrecognizedTicketException>(() => parkingBoy.Fetch(wrongTicket));

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void ParkingBoy_FetchCarWithUsedTicket_ThrowsUnrecognizedTicketException()
        {
            var parkingLot = new ParkingLot.ParkingLot(10);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car();
            var ticket = parkingBoy.Park(car);
            parkingBoy.Fetch(ticket);

            var exception = Assert.Throws<UnrecognizedTicketException>(() => parkingBoy.Fetch(ticket));

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void ParkingBoy_ParkCarWhenParkingLotFull_ThrowsNoAvailablePositionException()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy(parkingLot);
            var car1 = new Car();
            parkingBoy.Park(car1);
            var car2 = new Car();

            var exception = Assert.Throws<NoAvailablePositionException>(() => parkingBoy.Park(car2));

            Assert.Equal("No available position.", exception.Message);
        }
    }
}
