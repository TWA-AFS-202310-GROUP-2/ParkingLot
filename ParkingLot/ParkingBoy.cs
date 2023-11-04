using System;

namespace Parking;

public class ParkingBoy
{
    private ParkingLot parkingLot;

    public ParkingBoy()
    {
        parkingLot = new ParkingLot();
    }

    public string Park(string car)
    {
        string parkResult;
        try
        {
            parkResult = parkingLot.Park(car);
        }
        catch (NoCapacityExecption e)
        {
             throw e;
        }

        return parkResult;
    }

    public string Fetch(string ticket)
    {
        string fetchResult;
        try
        {
            fetchResult = parkingLot.Fetch(ticket);
        }
        catch (WrongTicketExecption e)
        {
            throw e;
        }

        return fetchResult;
    }
}