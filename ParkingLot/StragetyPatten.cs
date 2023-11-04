namespace Parking;

public class StragetyPatten : IParking
{
    private  IParking _parking;

    public StragetyPatten(IParking parking)
    {
        _parking = parking;
    }

    public string Fetch(string ticketId)
    {
        return _parking.Fetch(ticketId);
    }

    public Ticket Park(string car)
    {
        return _parking.Park(car);
    }

    public void SetParkingListCapacity(int index, int capacity)
    {
        _parking.SetParkingListCapacity(index,capacity);
    }
}