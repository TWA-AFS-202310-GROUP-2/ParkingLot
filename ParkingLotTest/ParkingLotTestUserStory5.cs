using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotTestUserStory5
    {
        [Fact]
        public void Should_park_in_first_parkinglot_when_park_car_given_a_smart_strategy_parking_boy()
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(8), new ParkingLots(10)];
            ParkingBoy parkingBoy = new ParkingBoy(new SmartParkingStrategy(), lots);
            // When
            string ticket = parkingBoy.ParkCar("car_us5");
            //Then
            var lotWithMostSpace = lots.OrderByDescending(lot => lot.PositionCapacity()).First();
            Assert.Equal(9, lotWithMostSpace.PositionCapacity());
        }

        [Fact]
        public void Should_park_in_second_parkinglot_when_first_parkinglot_is_full_given_a_smart_strategy_parking_boy()
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(0), new ParkingLots(8)];
            ParkingBoy parkingBoy = new ParkingBoy(new SmartParkingStrategy(), lots);
            // When
            string ticket = parkingBoy.ParkCar("car");
            //Then
            Assert.Equal(7, lots.ElementAt(1).PositionCapacity());
        }

        [Fact]
        public void Should_get_each_correct_car_when_fetch_twice_given_two_tickets_and_a_smart_strategy_parking_boy_with_two_parkinglots()
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(9), new ParkingLots(8)];
            ParkingBoy parkingBoy = new ParkingBoy(new SmartParkingStrategy(), lots);
            // When
            string ticket1 = parkingBoy.ParkCar("car_tmp1");
            string ticket2 = parkingBoy.ParkCar("car_tmp2");

            string car1 = parkingBoy.FetchCar(ticket1);
            string car2 = parkingBoy.FetchCar(ticket2);
            //Then
            Assert.Equal("car_tmp1", car1);
            Assert.Equal("car_tmp2", car2);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("12345")]
        public void Should_throw_err_msg_when_fetch_a_car_given_an_unrecognized_ticket_and_a_smart_strategy_parking_boy_with_two_parkinglots(string wrongticket)
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(9), new ParkingLots(8)];
            ParkingBoy parkingBoy = new ParkingBoy(new SmartParkingStrategy(), lots);
            //When
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.FetchCar(wrongticket));
            //Then
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_throw_err_msg_when_fetch_car_given_used_ticket_and_a_smart_strategy_parking_boy_with_two_parkinglots()
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(9), new ParkingLots(8)];
            ParkingBoy parkingBoy = new ParkingBoy(new SmartParkingStrategy(), lots);
            string ticket1 = parkingBoy.ParkCar("car_temp_us4");
            //When
            parkingBoy.FetchCar(ticket1);

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.FetchCar(ticket1));
            //Then
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_throw_err_msg_when_park_car_unavailable_position_and_a_smart_strategy_parking_boy_with_two_parkinglots()
        {
            //Given
            List<ParkingLots> lots = [new ParkingLots(0), new ParkingLots(0)];
            ParkingBoy parkingBoy = new ParkingBoy(new SmartParkingStrategy(), lots);
            //When
            UnAvailablePositionException unavailablePositionException = Assert.Throws<UnAvailablePositionException>(() => parkingBoy.ParkCar("car_us4_unavailable_position"));
            // Then
            Assert.Equal("No available position.", unavailablePositionException.Message);
        }
    }
}
