using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLot;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        // AC 1
        [Fact]
        public void Should_get_the_same_car_when_fetch_cat_by_ticket()
        {
            //Given
            ParkingLots parkingLot = new ParkingLots();
            string ticket = parkingLot.Park("car");
            //When
            string car = parkingLot.Fetch(ticket);
            //Then
            Assert.Equal("car", car);
        }

        [Fact]
        public void Should_get_correct_car_when_fetch_car_given_corresponding_ticket()
        {
            //Given
            ParkingLots parkingLot = new ParkingLots();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");
            //When
            string car1 = parkingLot.Fetch(ticket1);
            string car2 = parkingLot.Fetch(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }
    }
}
