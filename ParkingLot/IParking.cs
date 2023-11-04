namespace Parking;

public interface IParking
{
    public Ticket Park(string car);
    public string Fetch(string ticketId);
    public void SetParkingListCapacity(int index, int capacity);

}