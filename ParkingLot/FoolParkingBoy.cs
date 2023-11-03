using System.Collections.Generic;
using System.Linq;

namespace Parking;

public class FoolParkingBoy
{
    private List<ParkingLot> _parkingLotList;

    public FoolParkingBoy(int parkingNumber)
    {
        _parkingLotList = new List<ParkingLot>();
        AddParkingLot(parkingNumber);
    }

    public void AddParkingLot(int parkingNumber)
    {
        for (int i = 0; i < parkingNumber; i++)
        {
            _parkingLotList.Add(new ParkingLot());
        }
    }

    public virtual Ticket Park(string car)
    {
        ParkingLot parkingLot =null;
        int location = -1;
        for (int i = 0; i < _parkingLotList.Count; i++)
        {
            if (_parkingLotList[i].ParkingCapacity > 0)
            {
                parkingLot = _parkingLotList[i];
                location = i;
                break;
            }
        }

        if (location == -1)
        {
            throw new NoCapacityExecption("No available position.");
        }

        return new Ticket(parkingLot.Park(car),location+1);
    }

    public string Fetch(string ticketId)
    {
        // I think parameter is a ticketId string is the real scenario. 
        string car ="";
        foreach (var parkingLot in _parkingLotList)
        {
            // Should try outside loop or inside the loop?
            try
            {
                car = parkingLot.Fetch(ticketId);
            }catch{}
        }

        if (string.IsNullOrEmpty(car))
        {
            throw new WrongTicketExecption("Unrecognized parking ticket.");
        }

        return car;
    }

    public void setParkingListCapacity(int index, int capacity)
    {
        _parkingLotList[index].ParkingCapacity=capacity;
    }

    public void SortParkingLotByCapacity()
    {
        _parkingLotList.Sort((p1, p2) => p1.ParkingCapacity - p2.ParkingCapacity);
    }

    public List<ParkingLot> GetParkLots()
    {
        return _parkingLotList; 
    }
}