using Parking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_park_car_to_parking_lot_with_most_empty_space_when_Park()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new ParkingLot("first"),
            new ParkingLot("second"),
        };
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);

            string ticket = smartParkingBoy.Park("car");
            string ticket2 = smartParkingBoy.Park("car");

            Assert.Equal("first", ticket.Split("-")[0]);
            Assert.Equal("second", ticket2.Split("-")[0]);
        }

        [Theory]
        [InlineData("car", "car2")]
        public void Should_get_the_same_car_when_FetchCar_by_ticket(string carNumber, string carNumber2)
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new ParkingLot("first"),
            new ParkingLot("second"),
        };
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);
            string ticket = smartParkingBoy.Park(carNumber);
            string car = smartParkingBoy.FetchCar(ticket);

            Assert.Equal(carNumber, car);

            string ticket2 = smartParkingBoy.Park(carNumber2);
            string car2 = smartParkingBoy.FetchCar(ticket2);

            Assert.Equal(carNumber2, car2);
        }

        [Theory]
        [InlineData("car1", "car2")]
        public void Should_get_correct_car_when_FetchCar_with_corresponding_ticket(string carNumber1, string carNumber2)
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new ParkingLot("first"),
            new ParkingLot("second"),
        };
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);
            string ticket = smartParkingBoy.Park(carNumber1);
            string ticket2 = smartParkingBoy.Park(carNumber2);
            string car = smartParkingBoy.FetchCar(ticket);
            string car2 = smartParkingBoy.FetchCar(ticket2);
            Assert.Equal(carNumber1, car);
            Assert.Equal(carNumber2, car2);
        }

        [Theory]
        [InlineData("car")]
        public void Should_not_fetch_car_when_FetchCar_without_ticket(string carNumber)
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new ParkingLot("first"),
            new ParkingLot("second"),
        };
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);
            string ticket = smartParkingBoy.Park(carNumber);
            string car = smartParkingBoy.FetchCar();
            Assert.Null(car);
        }

        [Theory]
        [InlineData("car")]
        public void Should_throw_WrongTicketException_when_FetchCar_with_wrong_ticket(string carNumber)
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new ParkingLot("first"),
            new ParkingLot("second"),
        };

            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => smartParkingBoy.FetchCar("anyway"));

            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Theory]
        [InlineData("car")]
        public void Should_throw_WrongTicketException_when_FetchCar_with_used_ticket(string carNumber)
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new ParkingLot("first"),
            new ParkingLot("second"),
        };
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);
            string ticket = smartParkingBoy.Park(carNumber);
            string car = smartParkingBoy.FetchCar(ticket);
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => smartParkingBoy.FetchCar(ticket));

            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Theory]
        [InlineData("car")]
        public void Should_not_park_car_when_Park_given_full_capacity_parking_lot(string carNumber)
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new ParkingLot("first"),
            new ParkingLot("second"),
        };
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);

            for (int i = 0; i < 20; i++)
            {
                smartParkingBoy.Park("texi");
            }

            FullCapacityException fullCapacityException = Assert.Throws<FullCapacityException>(() => smartParkingBoy.Park(carNumber));
            Assert.Equal("No available position.", fullCapacityException.Message);
        }
    }
}
