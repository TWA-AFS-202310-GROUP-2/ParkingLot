namespace ParkingLotTest
{
    using ParkingLot;
    using System;
    using System.Collections.Generic;
    using System.Net.Sockets;
    using Xunit;
    using Xunit.Sdk;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_parking_ticket_When_park_Given_parking_lot_and_car()
        {
            var parkingLots = new List<ParkingLot>()
            {
                new ParkingLot(10), new ParkingLot(20)
            };

            var smartParkingStrategy = new SmartParkingStrategy();
            var parkingBoy = new ParkingBoy(smartParkingStrategy, parkingLots);

            var car = new Car();
            var ticket = parkingBoy.Park(car);

            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_return_parked_car_When_fetch_Given_parking_lot_with_parked_car_and_parking_ticket()
        {
            var parkingLots = new List<ParkingLot>()
            {
                new ParkingLot(10), new ParkingLot(20)
            };

            var smartParkingStrategy = new SmartParkingStrategy();
            var parkingBoy = new ParkingBoy(smartParkingStrategy, parkingLots);

            var car = new Car();
            var ticket = parkingBoy.Park(car);
            var fetchedCar = parkingBoy.Fetch(ticket);

            Assert.Equal(car, fetchedCar);
        }

        [Fact]
        public void Should_return_two_parked_cars_When_fetch_Given_parking_lot_with_two_parked_cars_and_two_parking_tickets()
        {
            var parkingLots = new List<ParkingLot>()
            {
                new ParkingLot(10), new ParkingLot(20)
            };

            var smartParkingStrategy = new SmartParkingStrategy();
            var parkingBoy = new ParkingBoy(smartParkingStrategy, parkingLots);

            var car1 = new Car();
            var ticket1 = parkingBoy.Park(car1);
            var car2 = new Car();
            var ticket2 = parkingBoy.Park(car2);
            var fetchedCar1 = parkingBoy.Fetch(ticket1);
            var fetchedCar2 = parkingBoy.Fetch(ticket2);

            Assert.Equal(car1, fetchedCar1);
            Assert.Equal(car2, fetchedCar2);
        }

        [Fact]
        public void Should_return_error_message_When_fetch_Given_a_wrong_ticket()
        {
            var parkingLots = new List<ParkingLot>()
            {
                new ParkingLot(10), new ParkingLot(20)
            };

            var smartParkingStrategy = new SmartParkingStrategy();
            var parkingBoy = new ParkingBoy(smartParkingStrategy, parkingLots);

            var car = new Car();
            parkingBoy.Park(car);
            var wrongTicket = new Ticket();
            WrongTicketException exception = Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(wrongTicket));

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_return_error_message_When_fetch_Given_used_a_ticket()
        {
            var parkingLots = new List<ParkingLot>()
            {
                new ParkingLot(10), new ParkingLot(20)
            };

            var smartParkingStrategy = new SmartParkingStrategy();
            var parkingBoy = new ParkingBoy(smartParkingStrategy, parkingLots);

            var car = new Car();
            var ticket = parkingBoy.Park(car);
            parkingBoy.Fetch(ticket); // Simulate fetching the car
            WrongTicketException exception = Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(ticket)); // Attempt to fetch with the same ticket

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_return_error_message_When_park_Given_a_full_parkingLot()
        {
            var parkingLots = new List<ParkingLot>()
            {
                new ParkingLot(1), new ParkingLot(0)
            };

            var smartParkingStrategy = new SmartParkingStrategy();
            var parkingBoy = new ParkingBoy(smartParkingStrategy, parkingLots);

            var car1 = new Car();
            var car2 = new Car();

            parkingBoy.Park(car1); // Park first car

            NoPositionException exception = Assert.Throws<NoPositionException>(() => parkingBoy.Park(car2)); // Attempt to fetch with the same ticket

            Assert.Equal("No available position.", exception.Message);
        }
    }
}
