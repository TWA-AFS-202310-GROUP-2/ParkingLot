namespace Parking;

public class Ticket
{
    public string ticketId;
    public int location;

    public Ticket(string tickedId, int location)
    {
        this.ticketId = tickedId;
        this.location = location;
    }
}