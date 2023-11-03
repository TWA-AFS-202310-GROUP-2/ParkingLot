using Parking;
using Xunit;

namespace ParkingLotTest;

public class SmartParkingBoyTest
{
    [Fact]
    public void Should_get_the_location_2_when_fetch_car_by_smartparkingboy()
    {
        var parkingBoy = new SmartParkingBoy(2);
        parkingBoy.setParkingListCapacity(0,1);
        parkingBoy.setParkingListCapacity(1,2);
        Ticket ticket = parkingBoy.Park("car");

        Assert.Equal(2, ticket.location);
    }

    [Fact]
    public void Should_get_the_location_2_1_2_when_fetch_car_by_foolparkingboy()
    {
        var parkingBoy = new SmartParkingBoy(2);
        parkingBoy.setParkingListCapacity(0, 1);
        parkingBoy.setParkingListCapacity(1, 2);
        Ticket ticket1 = parkingBoy.Park("car1");
        Ticket ticket2 = parkingBoy.Park("car2");
        Ticket ticket3 = parkingBoy.Park("car3");

        Assert.Equal(2, ticket1.location);
        Assert.Equal(1, ticket2.location);
        Assert.Equal(2, ticket3.location);

    }
}