using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Interfaces
{
    interface IVehicle
    {
        int X { get; }
        int Y { get; }
        Surface Surface { get; }
        Direction Direction { get;}
        int Scuffs { get; set; }
        void MoveVehicle(Movement movement);
        void VehicleControl(string movements);
    }
}
