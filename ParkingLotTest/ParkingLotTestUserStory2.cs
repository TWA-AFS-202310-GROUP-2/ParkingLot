using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotTestUserStory2
    {
        // User Story 2: AC 1
        [Theory]
        [InlineData("123")]
        public void Should_get_no_car_throw_error_msg_when_fetch_car_given_wrong_ticket(string wrongticket)
        {
            //Given
            ParkingLots parkingLot = new ParkingLots();
            //When and Then
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(wrongticket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }
    }
}
