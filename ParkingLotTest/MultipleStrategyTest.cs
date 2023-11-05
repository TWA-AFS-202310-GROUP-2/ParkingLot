using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot;
using Xunit;
using static ParkingLot.ParkingLots;

namespace ParkingLotTest
{
    public class MultipleStrategyTest
    {
        [Theory]
        [InlineData(5, 10, "Car1")]
        public void Should_MultipleStrategy_return_car_When_fetch_Given_ticket(int lot1, int lot2, string carName)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1),
                new ParkingLots(lot2),
            };
            SmartParkingBoy smartparkingBoy = new SmartParkingBoy(parkingLots);
            MultipleParkingBoys multipleParkingBoys = new MultipleParkingBoys(parkingLots, smartparkingBoy);
            Ticket ticket = multipleParkingBoys.Park(parkingLots, carName);
            //when
            string car = multipleParkingBoys.Fetch(parkingLots, ticket);
            //then
            Assert.Equal("Car1", car);
        }

        [Theory]
        [InlineData(5, 10, "Car1", "Car2")]
        public void Should_MultipleStrategy_return_correct_cars_When_fetch_cars_Given_tickets(int lot1, int lot2, string carName1, string carName2)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1),
                new ParkingLots(lot2),
            };
            SmartParkingBoy smartparkingBoy = new SmartParkingBoy(parkingLots);
            MultipleParkingBoys multipleParkingBoys = new MultipleParkingBoys(parkingLots, smartparkingBoy);
            Ticket ticke1 = multipleParkingBoys.Park(parkingLots, carName1);
            Ticket ticke2 = multipleParkingBoys.Park(parkingLots, carName2);
            //When
            string car1 = multipleParkingBoys.Fetch(parkingLots, ticke1);
            string car2 = multipleParkingBoys.Fetch(parkingLots, ticke2);
            //Then
            Assert.Equal("Car1", car1);
            Assert.Equal("Car2", car2);
        }

        [Theory]
        [InlineData(5, 10, "Car1", "Ticket 1")]
        public void Should_MultipleStrategy_throw_WrongTicketException_When_fetch_cars_Given_wrong_tickets(int lot1, int lot2, string carName1, string ticketName)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1),
                new ParkingLots(lot2),
            };
            SmartParkingBoy smartparkingBoy = new SmartParkingBoy(parkingLots);
            MultipleParkingBoys multipleParkingBoys = new MultipleParkingBoys(parkingLots, smartparkingBoy);
            Ticket ticket = multipleParkingBoys.Park(parkingLots, carName1);
            Ticket givenTicket = new Ticket { TicketName = ticketName };
            //When
            Action action = () => multipleParkingBoys.Fetch(parkingLots, givenTicket);
            //Then
            var exception = Assert.Throws<WrongTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData(5, 10, "Car1")]
        public void Should_MultipleStrategy_throw_WrongTicketException_When_fetch_cars_Given_null_tickets(int lot1, int lot2, string carName1)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1),
                new ParkingLots(lot2),
            };
            SmartParkingBoy smartparkingBoy = new SmartParkingBoy(parkingLots);
            MultipleParkingBoys multipleParkingBoys = new MultipleParkingBoys(parkingLots, smartparkingBoy);
            Ticket ticket = multipleParkingBoys.Park(parkingLots, carName1);
            Ticket givenTicket = new Ticket { TicketName = null };
            //When
            Action action = () => multipleParkingBoys.Fetch(parkingLots, givenTicket);
            //Then
            var exception = Assert.Throws<WrongTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData(5, 10, "Car1")]
        public void Should_MultipleStrategy_throw_WrongTicketException_When_fetch_cars_Given_an_used_ticket(int lot1, int lot2, string carName1)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1),
                new ParkingLots(lot2),
            };
            SmartParkingBoy smartparkingBoy = new SmartParkingBoy(parkingLots);
            MultipleParkingBoys multipleParkingBoys = new MultipleParkingBoys(parkingLots, smartparkingBoy);
            Ticket ticke1 = multipleParkingBoys.Park(parkingLots, carName1);
            string car = multipleParkingBoys.Fetch(parkingLots, ticke1);
            //When
            Action action = () => multipleParkingBoys.Fetch(parkingLots, ticke1);
            //Then
            var exception = Assert.Throws<WrongTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData(5, 100, "Car111")]
        public void Should_MultipleStrategy_throw_NoPositionException_When_park_cars_Given_more_than_10_cars(int lot1, int lot2, string moreCarName)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1),
                new ParkingLots(lot2),
            };
            SmartParkingBoy smartparkingBoy = new SmartParkingBoy(parkingLots);
            MultipleParkingBoys multipleParkingBoys = new MultipleParkingBoys(parkingLots, smartparkingBoy);
            for (int i = 0; i < lot1 + lot2; i++)
            {
                multipleParkingBoys.Park(parkingLots, $"Car {i}");
            }

            //When
            Action action = () => multipleParkingBoys.Park(parkingLots, moreCarName);
            //Then
            var exception = Assert.Throws<NoPositionException>(action);
            Assert.Equal("No available position.", exception.Message);
        }

        [Theory]
        [InlineData(5, 2)]
        public void Should_MultipleStrategy_park_in_more_empty_positions_When_park_cars(int lot1, int lot2)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1) { Number = "lot1" },
                new ParkingLots(lot2) { Number = "lot2" },
            };
            SmartParkingBoy smartparkingBoy = new SmartParkingBoy(parkingLots);
            MultipleParkingBoys multipleParkingBoys = new MultipleParkingBoys(parkingLots, smartparkingBoy);
            List<string> paringOrder = new List<string>();
            //预计的Parking order,相同数量时默认数量多的
            List<string> expectParkingOrder = new List<string>
            {
                "lot1", "lot1", "lot1", "lot1", "lot2", "lot1", "lot2",
            };
            //When
            for (int i = 0; i < lot1 + lot2; i++)
            {
                Ticket ticket = multipleParkingBoys.Park(parkingLots, $"Car {i}");
                paringOrder.Add(ticket.PakingLotName);
            }

            //Then
            Assert.Equal(expectParkingOrder, paringOrder);
        }

        [Theory]
        [InlineData(3, 3)]
        public void Should_MultipleStrategy_park_in_more_empty_positions_When_capacity_is_equal(int lot1, int lot2)
        {
            //Given
            List<ParkingLots> parkingLots = new List<ParkingLots>
            {
                new ParkingLots(lot1) { Number = "lot1" },
                new ParkingLots(lot2) { Number = "lot2" },
            };
            SmartParkingBoy smartparkingBoy = new SmartParkingBoy(parkingLots);
            MultipleParkingBoys multipleParkingBoys = new MultipleParkingBoys(parkingLots, smartparkingBoy);
            List<string> paringOrder = new List<string>();
            //capacity相同数量时,默认第一个
            List<string> expectParkingOrder = new List<string>
            {
                "lot1", "lot2", "lot1", "lot2", "lot1", "lot2",
            };
            //When
            for (int i = 0; i < lot1 + lot2; i++)
            {
                Ticket ticket = multipleParkingBoys.Park(parkingLots, $"Car {i}");
                paringOrder.Add(ticket.PakingLotName);
            }

            //Then
            Assert.Equal(expectParkingOrder, paringOrder);
        }
    }
}
