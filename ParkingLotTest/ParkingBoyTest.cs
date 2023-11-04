﻿using Parking;

namespace ParkingLotTest
{
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_get_the_same_car_when_fetch_car_by_ticket()
        {
            var parkingLot = new ParkingBoy();
            string ticket = parkingLot.Park("car");

            string car = parkingLot.Fetch(ticket);

            Assert.Equal("car", car);
        }
        
        [Fact]
        public void Should_get_the_correct_car_when_fetch_car_by_ticket()
        {
            var parkingLot = new ParkingBoy();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");

            string car1 = parkingLot.Fetch(ticket1);
            string car2 = parkingLot.Fetch(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_get_no_car_when_fetch_car_by_wrong_ticket()
        {
            var parkingLot = new ParkingBoy();
            string ticket1 = parkingLot.Park("car1");

            var expection = Assert.Throws<WrongTicketExecption>((() => parkingLot.Fetch("car2")));
            Assert.Equal("Unrecognized parking ticket.", expection.Message);
        }

        [Fact]
        public void Should_get_no_car_when_car_aleady_fetched_by_ticket()
        {
            var parkingLot = new ParkingBoy();
            string ticket1 = parkingLot.Park("car1");
            parkingLot.Fetch(ticket1);

            var expection = Assert.Throws<WrongTicketExecption>((() => parkingLot.Fetch(ticket1)));

            Assert.Equal("Unrecognized parking ticket.", expection.Message);
        }

        [Fact]
        public void Should_get_no_capacity_when_parkinglot_is_up_to_capacity()
        {
            var parkingLot = new ParkingBoy();
            parkingLot.Park("car1");
            parkingLot.Park("car2");
            parkingLot.Park("car3");
            parkingLot.Park("car4");
            parkingLot.Park("car5");
            parkingLot.Park("car6");
            parkingLot.Park("car7");
            parkingLot.Park("car8");
            parkingLot.Park("car9");
            parkingLot.Park("car10");

            var expection = Assert.Throws<NoCapacityExecption>((() => parkingLot.Park("car11")));

            Assert.Equal("No available position", expection.Message);
        }

        [Fact]
        public void Should_get_error_car_when_car_aleady_parked()
        {
            var parkingLot = new ParkingBoy();
            parkingLot.Park("car1");

            string ticket1 = parkingLot.Park("car1");

            Assert.Equal("", ticket1);
        }

        [Fact]
        public void Should_get_error_car_when_park_a_null_car()
        {
            var parkingLot = new ParkingBoy();

            string ticket1 = parkingLot.Park("");

            Assert.Equal("", ticket1);
        }

        [Fact]
        public void Should_get_error_car_when_fetch_car_by_null_ticket()
        {
            var parkingLot = new ParkingBoy();
            string ticket1 = parkingLot.Park("car1");
            var expection = Assert.Throws<WrongTicketExecption>((() => parkingLot.Fetch("")));

            Assert.Equal("Unrecognized parking ticket.", expection.Message);
        }
    }
}
