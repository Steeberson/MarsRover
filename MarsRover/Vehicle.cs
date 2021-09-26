using System;
using System.Collections.Generic;
using System.Linq;
using MarsRover.Interfaces;

namespace MarsRover
{
    public class Vehicle : IVehicle
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Surface Surface { get; private set; }
        public Direction Direction { get; private set; }
        public int Scuffs { get; set; }

        /// <summary>Base rover declaration</summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        public Vehicle(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
            Surface = new Surface(5, 5);
            Scuffs = 0;
        }

        /// <summary>process a movement request for the rover</summary>
        /// <param name="movement"></param>
        public void MoveVehicle(Movement movement)
        {
            try
            {
                switch (movement)
                {
                    case Movement.L:
                        Left();
                        break;
                    case Movement.R:
                        Right();
                        break;
                    case Movement.F:
                        Forward();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Move Vehicle: {ex.Message}");
            }
        }

        /// <summary>process a string of movements</summary>
        /// <param name="movements"></param>
        public void VehicleControl(string movements)
        {
            try
            {
                foreach (char movement in movements)
                {
                    if (Enum.IsDefined(typeof(Movement), movement.ToString()))
                        MoveVehicle((Movement)Enum.Parse(typeof(Movement), movement.ToString()));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Vehcile Control: {ex.Message}");
            }
        }

        /// <summary>Move forward in the current direction</summary>
        private void Forward()
        {
            if (CheckValidPath())
            {
                switch (Direction)
                {
                    case Direction.N:
                        Y += 1;
                        break;
                    case Direction.E:
                        X += 1;
                        break;
                    case Direction.W:
                        X -= 1;
                        break;
                    case Direction.S:
                        Y -= 1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                Scuffs++;
            }
        }

        /// <summary>Check for edges</summary>
        private bool CheckValidPath()
        {
            return Direction switch
            {
                (Direction.N) => Y + 1 < Surface.Height,
                (Direction.E) => X + 1 < Surface.Height,
                (Direction.W) => X - 1 >= 0,
                (Direction.S) => Y - 1 >= 0,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        /// <summary>Deal with left turns from the current direction</summary>
        private void Left()
        {
            Direction = Direction switch
            {
                (Direction.N) => Direction.W,
                (Direction.E) => Direction.N,
                (Direction.W) => Direction.S,
                (Direction.S) => Direction.E,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        /// <summary>Deal with right turns from the current direction</summary>
        private void Right()
        {
            Direction = Direction switch
            {
                (Direction.N) => Direction.E,
                (Direction.E) => Direction.S,
                (Direction.W) => Direction.N,
                (Direction.S) => Direction.W,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
