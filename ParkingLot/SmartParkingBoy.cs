using System.Collections.Generic;
using System.Linq;

namespace Parking;

public class SmartParkingBoy : FoolParkingBoy
{
    public SmartParkingBoy(int parkingNumber) : base(parkingNumber)
    {
    }

    public override Ticket Park(string car)
    {
        var parkingLotsBackup = new List<ParkingLot> (GetParkLots());
        SortParkingLotByCapacity();
        parkingLotsBackup.Sort((x,y)=>y.ParkingCapacity-x.ParkingCapacity);
        var currentMaxCapacityParkingLot = parkingLotsBackup.First();
        if (currentMaxCapacityParkingLot.ParkingCapacity == 0)
        {
            throw new NoCapacityExecption("No available position.");
        }

        int location = GetParkLots().IndexOf(currentMaxCapacityParkingLot);
        return new Ticket(currentMaxCapacityParkingLot.Park(car),location+1);
    }


}