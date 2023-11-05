using Xunit;
using ParkingLot;

namespace ParkingLotTests
{
    public class ParkingLotTests
    {
        [Fact]
        public void ParkCar_WhenParkingLotHasSpace_ReturnsTicket()
        {
            var parkingLot = new ParkingLot.ParkingLot(10);
            var car = new Car();
            var ticket = parkingLot.Park(car);
            Assert.NotNull(ticket);
        }

        [Fact]
        public void FetchCar_WithValidTicket_ReturnsCar()
        {
            var parkingLot = new ParkingLot.ParkingLot(10);
            var car = new Car();
            var ticket = parkingLot.Park(car);
            var fetchedCar = parkingLot.Fetch(ticket);
            Assert.Equal(car, fetchedCar);
        }

        [Fact]
        public void FetchCar_WithValidTicket_ReturnsCar_Twice()
        {
            var parkingLot = new ParkingLot.ParkingLot(10);
            var car1 = new Car();
            var car2 = new Car();
            var ticket1 = parkingLot.Park(car1);
            var ticket2 = parkingLot.Park(car2);
            var fetchedCar1 = parkingLot.Fetch(ticket1);
            var fetchedCar2 = parkingLot.Fetch(ticket2);
            Assert.Equal(car1, fetchedCar1);
            Assert.Equal(car2, fetchedCar2);
        }

        [Fact]
        public void FetchCar_WithWrongTicket_ReturnsNull()
        {
            var parkingLot = new ParkingLot.ParkingLot(10);
            var car = new Car();
            parkingLot.Park(car);
            var wrongTicket = new Ticket();
            var fetchedCar = parkingLot.Fetch(wrongTicket);
            Assert.Null(fetchedCar);
        }

        [Fact]
        public void FetchCar_WithUsedTicket_ReturnsNull()
        {
            var parkingLot = new ParkingLot.ParkingLot(10);
            var car = new Car();
            var ticket = parkingLot.Park(car);
            parkingLot.Fetch(ticket); // Simulate fetching the car
            var fetchedCar = parkingLot.Fetch(ticket); // Attempt to fetch with the same ticket
            Assert.Null(fetchedCar);
        }

        [Fact]
        public void ParkCar_WhenParkingLotIsFull_ReturnsNull()
        {
            var parkingLot = new ParkingLot.ParkingLot(1); // Parking lot with capacity of 1
            var car1 = new Car();
            var car2 = new Car();
            parkingLot.Park(car1); // Park first car
            var ticket = parkingLot.Park(car2); // Attempt to park another car
            Assert.Null(ticket);
        }
    }
}
