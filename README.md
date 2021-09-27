<!-- PROJECT SHIELDS -->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# Mars Lunar Rover Coding Challenge
This is the the Mars Lunar Rover coding challenge. The Mars Lunar Rover is sitting in a conveniently square crater that has been divided into a 5 by 5 grid and the task is to be able to demonstrate control of the Rover.

# Lunar Rover Controls
The position of the rover can be described by its X and Y coordinates within the grid and the direction that it is facing in the form of the compass points N, E, S or W.
For example, a position of 0, 0, E means the rover is in the bottom left corner of the grid and is facing East. A position of 3, 4, S means the rover is in the 4th square along and the 5th (or top) square up and is facing South.

# Using The Lunar Rover
First, we need to define a Rover (vehicle), there can be many in the crater but they will not be aware of each other, so we will focus on one Rover for this. You define the Rover with a new instance setting the start location (x, y, direction), for example: 
   ```c#
   Vehicle rover = new Vehicle(0, 2, Direction.E);
   ```
The surface is defaulted for this example, but could be changed by providing a replacment (see Surface Amendments below). 

The rover is controlled by sending it a sequence of instructions. Each instruction will either be:
 * ‘L’ to make the rover spin 90 degrees to the left
 * ‘R’ to make it spin 90 degrees to the right
 * ‘F’ to make it move forward one grid square in the direction that it is facing

There are two functions to allow the Rover to Move:
1. MoveVehicle - This accepts a Movement which is then executed. (O(1))
   ```c#
   rover.MoveVehicle(Movement.F);
   ```
2. VehicleControl - This accepts a string of movements which are validated and then executed in order. If one movement is not valid then this is skipped and the next executed. (O(n))
   ```c#
   rover.VehicleControl("FLFRFFFRFFRR");
   ```

If the instruction causes the rover to attempt to move out of the grid, then it will collide with the crater wall and scuff it's shiny new paintwork, which will be logged and cause the Rover to return to its position before that instruction.

# Testing The Lunar Rover
There are two sets of tests for this. The first checks the base functionality, can the rover move and deal with it's environment. The second set are specific tests, where 4 scenarios are checked.

# Surface Amendments
The surface can be amended, however this example would have to be set in the Vehicle class, or the permissions would have to be amended.
   ```c#
    Surface newSurface = new Surface(){
      height = 6,
      width = 6
    };
    rover.Surface = newSurface;
   ```


<!-- MARKDOWN LINKS & IMAGES -->
[contributors-shield]: https://img.shields.io/github/contributors/Steeberson/MarsRover.svg?style=for-the-badge
[contributors-url]: https://github.com/Steeberson/MarsRover/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/Steeberson/MarsRover.svg?style=for-the-badge
[forks-url]: https://github.com/Steeberson/MarsRover/network/members
[stars-shield]: https://img.shields.io/github/stars/Steeberson/MarsRover.svg?style=for-the-badge
[stars-url]: https://github.com/Steeberson/MarsRover/stargazers
[issues-shield]: https://img.shields.io/github/issues/Steeberson/MarsRover.svg?style=for-the-badge
[issues-url]: https://github.com/Steeberson/MarsRover/issues
[license-shield]: https://img.shields.io/github/license/Steeberson/MarsRover.svg?style=for-the-badge
[license-url]: https://github.com/Steeberson/MarsRover/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/steven-horton-a11331115

