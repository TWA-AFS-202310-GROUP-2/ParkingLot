﻿using Parking;
using Xunit;

namespace ParkingLotTest;

public class StragetyPattenTest
{
    [Fact]
    public void Should_get_the_location_1_when_fetch_car_by_foolparkingboy()
    {
        var parkingBoy = new StragetyPatten(new FoolParkingBoy(2));

        Ticket ticket = parkingBoy.Park("car");

        Assert.Equal(1, ticket.location);
    }

    [Fact]
    public void Should_get_the_location_2_when_fetch_car_by_foolparkingboy()
    {
        var parkingBoy = new StragetyPatten(new FoolParkingBoy(2));
        parkingBoy.SetParkingListCapacity(0, 0);
        parkingBoy.SetParkingListCapacity(1, 5);
        Ticket ticket = parkingBoy.Park("car");

        Assert.Equal(2, ticket.location);
    }


    [Fact]
    public void Should_get_the_car_when_fetch_car_by_ticket_to_foolparkingboy()
    {
        var parkingBoy = new StragetyPatten(new FoolParkingBoy(2));
        parkingBoy.SetParkingListCapacity(0, 1);
        parkingBoy.SetParkingListCapacity(1, 5);

        Ticket ticket1 = parkingBoy.Park("car1");
        Ticket ticket2 = parkingBoy.Park("car2");

        string car1 = parkingBoy.Fetch(ticket1.ticketId);
        string car2 = parkingBoy.Fetch(ticket2.ticketId);

        Assert.Equal("car1", car1);
        Assert.Equal("car2", car2);

    }

    [Fact]
    public void Should_get_no_car_when_car_aleady_fetched_by_ticket()
    {
        var parkingBoy = new StragetyPatten(new FoolParkingBoy(2));

        Ticket ticket1 = parkingBoy.Park("car1");

        parkingBoy.Fetch(ticket1.ticketId);

        var expection = Assert.Throws<WrongTicketExecption>((() => parkingBoy.Fetch(ticket1.ticketId)));

        Assert.Equal("Unrecognized parking ticket.", expection.Message);
    }

    [Fact]
    public void Should_get_no_car_when_fetch_car_given_ticket_is_wrong_to_foolparkingboy()
    {
        var parkingBoy = new StragetyPatten(new FoolParkingBoy(2));

        Ticket ticket1 = parkingBoy.Park("car1");


        var expection = Assert.Throws<WrongTicketExecption>((() => parkingBoy.Fetch("car2")));

        Assert.Equal("Unrecognized parking ticket.", expection.Message);
    }

    [Fact]
    public void Should_get_no_capacity_when_parkinglot_is_up_to_capacity()
    {
        var parkingBoy = new StragetyPatten(new FoolParkingBoy(2));
        parkingBoy.SetParkingListCapacity(0, 0);
        parkingBoy.SetParkingListCapacity(1, 0);

        var expection = Assert.Throws<NoCapacityExecption>((() => parkingBoy.Park("car1")));

        Assert.Equal("No available position.", expection.Message);
    }

    [Fact]
    public void Should_get_the_location_2_when_fetch_car_by_smartparkingboy()
    {
        var parkingBoy = new StragetyPatten(new SmartParkingBoy(2));
        parkingBoy.SetParkingListCapacity(0, 1);
        parkingBoy.SetParkingListCapacity(1, 2);

        Ticket ticket = parkingBoy.Park("car");

        Assert.Equal(2, ticket.location);
    }

    [Fact]
    public void Should_get_the_location_2_1_2_when_fetch_car_by_foolparkingboy()
    {
        var parkingBoy = new StragetyPatten(new SmartParkingBoy(2));
        parkingBoy.SetParkingListCapacity(0, 1);
        parkingBoy.SetParkingListCapacity(1, 2);

        Ticket ticket1 = parkingBoy.Park("car1");
        Ticket ticket2 = parkingBoy.Park("car2");
        Ticket ticket3 = parkingBoy.Park("car3");

        Assert.Equal(2, ticket1.location);
        Assert.Equal(1, ticket2.location);
        Assert.Equal(2, ticket3.location);

    }
}