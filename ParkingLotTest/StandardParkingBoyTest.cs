using Parking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingBoyTest
    {
        [Fact]
        public void Should_park_car_to_second_parking_lot_when_the_first_parking_lot_is_full()
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new ParkingLot("first"),
            new ParkingLot("second"),
        };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);

            for (int i = 0; i < 9; i++)
            {
                standardParkingBoy.Park("car");
            }

            string ticket = standardParkingBoy.Park("car");
            string ticket2 = standardParkingBoy.Park("car");

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
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            string ticket = standardParkingBoy.Park(carNumber);
            string car = standardParkingBoy.FetchCar(ticket);

            Assert.Equal(carNumber, car);

            for (int i = 0; i < 9; i++)
            {
                standardParkingBoy.Park("texi");
            }

            string ticket2 = standardParkingBoy.Park(carNumber2);
            string car2 = standardParkingBoy.FetchCar(ticket2);

            Assert.Equal(carNumber2, car2);
        }

        [Theory]
        [InlineData("car1", "car2")]
        public void Should_get_correct_car_when_fetch_with_corresponding_ticket(string carNumber1, string carNumber2)
        {
            List<ParkingLot> parkingLots = new List<ParkingLot>
        {
            new ParkingLot("first"),
            new ParkingLot("second"),
        };
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            string ticket = standardParkingBoy.Park(carNumber1);
            string ticket2 = standardParkingBoy.Park(carNumber2);
            string car = standardParkingBoy.FetchCar(ticket);
            string car2 = standardParkingBoy.FetchCar(ticket2);
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
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            string ticket = standardParkingBoy.Park(carNumber);
            string car = standardParkingBoy.FetchCar();
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

            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);

            for (int i = 0; i < 10; i++)
            {
                standardParkingBoy.Park("texi");
            }

            string ticket = standardParkingBoy.Park(carNumber);
            string car = standardParkingBoy.FetchCar(ticket);

            Assert.Equal(carNumber, car);

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => standardParkingBoy.FetchCar("anyway"));

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
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);
            string ticket = standardParkingBoy.Park(carNumber);
            string car = standardParkingBoy.FetchCar(ticket);
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => standardParkingBoy.FetchCar(ticket));

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
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);

            for (int i = 0; i < 20; i++)
            {
                standardParkingBoy.Park("texi");
            }

            FullCapacityException fullCapacityException = Assert.Throws<FullCapacityException>(() => standardParkingBoy.Park(carNumber));
            Assert.Equal("No available position.", fullCapacityException.Message);
        }
    }
}
