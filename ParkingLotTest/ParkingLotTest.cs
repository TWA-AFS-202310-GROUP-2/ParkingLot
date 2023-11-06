namespace ParkingLotTest
{
    using Parking;
    using Xunit;

    public class ParkingLotTest
    {
        [Theory]
        [InlineData("car")]
        public void Should_get_the_same_car_when_FetchCar_by_ticket(string carNumber)
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park(carNumber);
            string car = parkingLot.FetchCar(ticket);
            Assert.Equal(carNumber, car);
        }

        [Theory]
        [InlineData("car1", "car2")]
        public void Should_get_correct_car_when_fetch_with_corresponding_ticket(string carNumber1, string carNumber2)
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park(carNumber1);
            string ticket2 = parkingLot.Park(carNumber2);
            string car = parkingLot.FetchCar(ticket);
            string car2 = parkingLot.FetchCar(ticket2);
            Assert.Equal(carNumber1, car);
            Assert.Equal(carNumber2, car2);
        }

        [Theory]
        [InlineData("car")]
        public void Should_not_fetch_car_when_FetchCar_without_ticket(string carNumber)
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park(carNumber);
            string car = parkingLot.FetchCar();
            Assert.Null(car);
        }

        [Theory]
        [InlineData("car")]
        public void Should_throw_WrongTicketException_when_FetchCar_with_wrong_ticket(string ticket)
        {
            ParkingLot parkingLot = new ParkingLot();
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.FetchCar(ticket));

            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Theory]
        [InlineData("car")]
        public void Should_throw_WrongTicketException_when_FetchCar_with_used_ticket(string carNumber)
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park(carNumber);
            string car = parkingLot.FetchCar(ticket);
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.FetchCar(ticket));

            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Theory]
        [InlineData("car")]
        public void Should_not_park_car_when_Park_given_full_capacity_parking_lot(string carNumber)
        {
            ParkingLot parkingLot = new ParkingLot();
            for (int i = 0; i < 10; i++)
            {
                parkingLot.Park(carNumber);
            }

            FullCapacityException fullCapacityException = Assert.Throws<FullCapacityException>(() => parkingLot.Park(carNumber));
            Assert.Equal("No available position.", fullCapacityException.Message);
        }
    }
}
