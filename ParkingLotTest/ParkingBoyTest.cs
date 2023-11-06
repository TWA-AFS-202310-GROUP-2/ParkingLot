using Xunit;

namespace ParkingLotTest
{
    using Parking;

    public class ParkingBoyTest
    {
        [Theory]
        [InlineData("car")]
        public void Should_get_the_same_car_when_FetchCar_by_ticket(string carNumber)
        {
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            string ticket = parkingBoy.Park(carNumber);
            string car = parkingBoy.FetchCar(ticket);
            Assert.Equal(carNumber, car);
        }

        [Theory]
        [InlineData("car1", "car2")]
        public void Should_get_correct_car_when_fetch_with_corresponding_ticket(string carNumber1, string carNumber2)
        {
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            string ticket = parkingBoy.Park(carNumber1);
            string ticket2 = parkingBoy.Park(carNumber2);
            string car = parkingBoy.FetchCar(ticket);
            string car2 = parkingBoy.FetchCar(ticket2);
            Assert.Equal(carNumber1, car);
            Assert.Equal(carNumber2, car2);
        }

        [Theory]
        [InlineData("car")]
        public void Should_not_fetch_car_when_FetchCar_without_ticket(string carNumber)
        {
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            string ticket = parkingBoy.Park(carNumber);
            string car = parkingBoy.FetchCar();
            Assert.Null(car);
        }

        [Theory]
        [InlineData("car")]
        public void Should_throw_WrongTicketException_when_FetchCar_with_wrong_ticket(string ticket)
        {
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.FetchCar(ticket));

            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Theory]
        [InlineData("car")]
        public void Should_throw_WrongTicketException_when_FetchCar_with_used_ticket(string carNumber)
        {
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);
            string ticket = parkingBoy.Park(carNumber);
            string car = parkingBoy.FetchCar(ticket);
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.FetchCar(ticket));

            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Theory]
        [InlineData("car")]
        public void Should_not_park_car_when_Park_given_full_capacity_parking_lot(string carNumber)
        {
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);

            for (int i = 0; i < 10; i++)
            {
                parkingBoy.Park(carNumber);
            }

            FullCapacityException fullCapacityException = Assert.Throws<FullCapacityException>(() => parkingLot.Park(carNumber));
            Assert.Equal("No available position.", fullCapacityException.Message);
        }
    }
}
