using MarsRover;
using System;
using System.Linq;
using Xunit;

namespace MarsRoverTest
{
    public class SpecificVehicleMovementTests
    {


        [Fact]
        public void Scenario1()
        {
            Vehicle rover = new Vehicle(0, 2, Direction.E);
            rover.VehicleControl("FLFRFFFRFFRR");
            Assert.True(rover.X == 4 && rover.Y == 1);
            Assert.True(rover.Direction == Direction.N);
            Assert.True(rover.Scuffs == 0);
        }

        [Fact]
        public void Scenario2()
        {
            Vehicle rover = new Vehicle(4, 4, Direction.S);
            rover.VehicleControl("LFLLFFLFFFRFF");
            Assert.True(rover.X == 0 && rover.Y == 1);
            Assert.True(rover.Direction == Direction.W);
            Assert.True(rover.Scuffs == 1);
        }

        [Fact]
        public void Scenario3()
        {
            Vehicle rover = new Vehicle(2, 2, Direction.W);
            rover.VehicleControl("FLFLFLFRFRFRFRF");
            Assert.True(rover.X == 2 && rover.Y == 2);
            Assert.True(rover.Direction == Direction.N);
            Assert.True(rover.Scuffs == 0);
        }

        [Fact]
        public void Scenario4()
        {
            Vehicle rover = new Vehicle(1, 3, Direction.N);
            rover.VehicleControl("FFLFFLFFFFF");
            Assert.True(rover.X == 0 && rover.Y == 0);
            Assert.True(rover.Direction == Direction.S);
            Assert.True(rover.Scuffs == 3);
        }
    }
}
