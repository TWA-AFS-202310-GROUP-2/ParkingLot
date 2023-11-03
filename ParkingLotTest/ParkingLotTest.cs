namespace ParkingLotTest
{
    using Parking;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_the_same_car_when_fetch_car_by_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            string car = parkingLot.fetch(ticket);

            Assert.Equal("car",car);
        }

        [Fact]
        public void Should_get_the_correct_car_when_fetch_car_by_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");

            string car1 = parkingLot.fetch(ticket1);
            string car2 = parkingLot.fetch(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2",car2);
        }

        [Fact]
        public void Should_get_no_car_when_fetch_car_by_wrong_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");

            string car1 = parkingLot.fetch("car2");

            Assert.Equal("No car", car1);
        }

        [Fact]
        public void Should_get_no_car_when_car_aleady_fetched_by_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            parkingLot.fetch(ticket1);

            string car1 = parkingLot.fetch(ticket1);

            Assert.Equal("No car", car1);
        }

        [Fact]
        public void Should_get_no_capacity_when_parkinglot_is_up_to_capacity()
        {
            ParkingLot parkingLot = new ParkingLot();
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

            string ticket1 = parkingLot.Park("car11");

            Assert.Equal("No capacity", ticket1);
        }

        [Fact]
        public void Should_get_error_car_when_car_aleady_parked()
        {
            ParkingLot parkingLot = new ParkingLot();
            parkingLot.Park("car1");

            string ticket1 = parkingLot.Park("car1");

            Assert.Equal("Error car", ticket1);
        }

        [Fact]
        public void Should_get_error_car_when_park_a_null_car()
        {
            ParkingLot parkingLot = new ParkingLot();

            string ticket1 = parkingLot.Park("");

            Assert.Equal("Error car", ticket1);
        }

        [Fact]
        public void Should_get_error_car_when_fetch_car_by_null_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");

            string car1 = parkingLot.fetch("");

            Assert.Equal("Invalid ticket", car1);
        }
    }
}
