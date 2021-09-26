using MarsRover;
using System;
using System.Linq;
using Xunit;

namespace MarsRoverTest
{
    public class BasicVehicleMovementTests
    {
        private int StartX = 0;
        private int StartY = 0;
        private Direction StartDirection = Direction.E;

        [Fact]
        public void TestNewVehicle()
        {
            Vehicle rover = new Vehicle(StartX, StartY, StartDirection);
            Assert.True(StartDirection== rover.Direction);
            Assert.True(StartX == rover.X && StartY == rover.Y);
            Assert.True(rover.Surface.Height == 5 && rover.Surface.Width == 5);
            Assert.True(rover.Scuffs == 0);
        }

        [Fact]
        public void TestVehicleLeft()
        {
            Vehicle rover = new Vehicle(StartX, StartY, StartDirection);
            rover.MoveVehicle(Movement.L);
            Assert.True(Direction.N == rover.Direction);
        }

        [Fact]
        public void TestVehicleRight()
        {
            Vehicle rover = new Vehicle(StartX, StartY, StartDirection);
            rover.MoveVehicle(Movement.R);
            Assert.True(Direction.S == rover.Direction);
        }

        [Fact]
        public void TestVehicleForward()
        {
            Vehicle rover = new Vehicle(StartX, StartY, StartDirection);
            rover.MoveVehicle(Movement.F);
            Assert.True((StartX + 1) == rover.X && StartY == rover.Y && rover.Scuffs == 0);
        }

        [Fact]
        public void TestVehicleForwardScuff()
        {
            Vehicle rover = new Vehicle(StartX, StartY, Direction.W);
            rover.MoveVehicle(Movement.F);
            Assert.True(StartX == rover.X && StartY == rover.Y && rover.Scuffs == 1);
        }

        [Fact]
        public void TestVehcileControl()
        {
            Vehicle rover = new Vehicle(StartX, StartY, StartDirection);
            rover.VehicleControl("FF");
            Assert.True((StartX+2) == rover.X && StartY == rover.Y && rover.Scuffs == 0);
        }

        [Fact]
        public void TestVehcileControl_SquareLeft()
        {
            Vehicle rover = new Vehicle(1, 1, Direction.N);
            rover.VehicleControl("FLFLFLFL");
            Assert.True(rover.X == 1 && rover.Y == 1 && rover.Scuffs == 0);
        }

        [Fact]
        public void TestVehcileControl_SquareRight()
        {
            Vehicle rover = new Vehicle(1, 1, Direction.N);
            rover.VehicleControl("FRFRFRFR");
            Assert.True(rover.X == 1 && rover.Y == 1 && rover.Scuffs == 0);
        }

        [Fact]
        public void TestVehcileControl_InvalidCommands()
        {
            Vehicle rover = new Vehicle(StartX, StartY, StartDirection);
            rover.VehicleControl("BADCOMMAND");
            Assert.True(StartX == rover.X && StartY == rover.Y && rover.Scuffs == 0);
        }

    }
}
