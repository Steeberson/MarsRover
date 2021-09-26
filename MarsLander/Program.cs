using System;
using MarsRover;

namespace MarsLander
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle rover = new Vehicle(0, 2, Direction.E);
            rover.VehicleControl("FLFRFFFRFFRR");
            Console.WriteLine($" {rover.X} | {rover.Y} | {rover.Direction} | {rover.Scuffs} ");
            Console.ReadKey();
        }
    }
}
