using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotTestUserStory3
    {
        [Fact]
        public void Should_get_the_same_car_when_fetch_car_given_ticket_us3()
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(9)];
            ParkingBoy parkingBoy = new ParkingBoy(new StandardParkingStrategy(), lots);
            string ticket = parkingBoy.ParkCar("car");
            //When
            string car = parkingBoy.FetchCar(ticket);
            //Then
            Assert.Equal("car", car);
        }

        [Fact]
        public void Should_get_correct_car_when_fetch_car_given_corresponding_ticket_us3()
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(9)];
            ParkingBoy parkingBoy = new ParkingBoy(new StandardParkingStrategy(), lots);
            string ticket1 = parkingBoy.ParkCar("car1");
            //When
            string car1 = parkingBoy.FetchCar(ticket1);

            Assert.Equal("car1", car1);
        }

        [Fact]
        public void Should_get_correct_car_when_fetch_two_car_given_each_corresponding_ticket_us3()
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(9)];
            ParkingBoy parkingBoy = new ParkingBoy(new StandardParkingStrategy(), lots);
            string ticket1 = parkingBoy.ParkCar("car1");
            string ticket2 = parkingBoy.ParkCar("car2");
            //When
            string car1 = parkingBoy.FetchCar(ticket1);
            string car2 = parkingBoy.FetchCar(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("123")]
        public void Should_get_no_car_when_fetch_car_given_wrong_or_null_ticket_us3(string wrongticket)
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(9)];
            ParkingBoy parkingBoy = new ParkingBoy(new StandardParkingStrategy(), lots);
            //When
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.FetchCar(wrongticket));
            //Then
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_get_no_car_when_fetch_car_given_used_ticket_us3()
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(9)];
            ParkingBoy parkingBoy = new ParkingBoy(new StandardParkingStrategy(), lots);
            string ticket1 = parkingBoy.ParkCar("car1");
            //When
            parkingBoy.FetchCar(ticket1);

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.FetchCar(ticket1));
            //Then
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_not_get_ticket_when_park_given_parkinglot_capacity_us3()
        {
            // Given
            List<ParkingLots> lots = [new ParkingLots(0)];
            ParkingBoy parkingBoy = new ParkingBoy(new StandardParkingStrategy(), lots);
            // When
            UnAvailablePositionException unavailablePositionException = Assert.Throws<UnAvailablePositionException>(() => parkingBoy.ParkCar("car"));
            // Then
            Assert.Equal("No available position.", unavailablePositionException.Message);
        }

        [Theory]
        [InlineData("12356")]
        public void Should_throw_error_msg_when_fetch_car_given_unrecognized_ticket_us3(string wrongticket)
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(9)];
            ParkingBoy parkingBoy = new ParkingBoy(new StandardParkingStrategy(), lots);
            //When and Then
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.FetchCar(wrongticket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_throw_error_msg_when_fetch_car_given_used_ticket_us3()
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(9)];
            ParkingBoy parkingBoy = new ParkingBoy(new StandardParkingStrategy(), lots);
            string ticket1 = parkingBoy.ParkCar("car1");
            //When
            parkingBoy.FetchCar(ticket1);

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.FetchCar(ticket1));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Theory]
        [InlineData(0)]
        public void Should_throw_error_msg_when_unavailable_position_given_capacity(int capacity)
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(capacity)];
            ParkingBoy parkingBoy = new ParkingBoy(new StandardParkingStrategy(), lots);
            //When and Then
            UnAvailablePositionException unavailablePositionException = Assert.Throws<UnAvailablePositionException>(() => parkingBoy.ParkCar("car"));
            Assert.Equal("No available position.", unavailablePositionException.Message);
        }
    }
}
