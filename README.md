# Toy Robot 
A C# .Net 6 solution containing a toy robot able to move around a 5 by 5 table top. The solution is accompanied with unit tests to ensure the application is and continues to be robest with any further alterations. SOLID principles were considered throughout.

The application spec is copied to the bottom of the readme. 

# Application installation
As a C# solution the user must run the solution within an appropriate application. For example Visual Studio. The solution must then be built and run in release.  

# Application instructions
Once installed and run the user will be presented with a console and a welcome message to inform the user the application is ready for use. 

The user can issue the following commands.
Place x y f: Where x, y are integers and f is a string representation of a direction. E.g. "North", "East", "South", "West". The place command places the robot upon a table.
Move: Moves the robot in the direction it is currently facing.
Left: Rotates the robot 90 degrees to the left e.g. From north to west, without changing position
Right: Rotates the robot 90 degrees to the rifht e.g. From north to east, without changing position
Report: This will out a report in the console on the robot's current position and direction. 

These commands are not case sensitive. 

Constraints: 
The table is a 5 by 5 plain.
The robot can be placed anywhere on this plain, invalid placements are reported and ignored. A robot can only be placed once, after a valid initial placement the placement command is no longer valid. 
The robot can move anywhere on this plain, invalid movements are reported and ignored.

Test data:

Place 0 0 North

Move

Move

Report (Output will be "Output: 0, 2, North")

Right

Move 

Move

Report (Output will be "Output: 2, 2, East")

# Application further details
Nuget packages used:
Autofac 6.5.0 & Autofac.Extensions.DependencyInjection 8.0.0 - These are used for dependency injection with the solution. Allowing for classes and interfaces to be accessed with ease. 

NUnit 3.13.3 - This is used to create and run unit tests within the application

# Further developments
Due to time contraints further some features were considered, but are essencial and therefor were left out. 

- Using an appsettings.json and config pair to allow custom dimension settings of the table. 
- Implementation of the command pattern, allowing for commands to be queued and undone. 
- The solution would be easily adaptable to include multiple robots. 

# Application spec

"The application is a simulation of a toy robot moving on a square table top, of dimensions 5 units x 5 units. There are noother obstructions on the table surface. The robot is free to roam around the surface of the table, but must be preventedfrom falling to destruction. Any movement that would result in the robot falling from the table must be prevented,however further valid movement commands must still be allowed.

Create a console application that can read in commands of the following form -PLACE X,Y,F
MOVE
LEFT
RIGHT
REPORT

PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. The origin (0,0)can be considered to be the SOUTH WEST most corner. It is required that the first command to the robot is a PLACEcommand, after that, any sequence of commands may be issued, in any order, including another PLACE command. Theapplication should discard all commands in the sequence until a valid PLACE command has been executed. MOVE willmove the toy robot one unit forward in the direction it is currently facing.

LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of therobot. REPORT will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient. A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands. Input can be from a file, or from standard input, as the developer chooses.

Provide test data to exercise the application. It is not required to provide any graphical output showing the movement of the toy robot.The application should handle error states appropriately and be robust to user input.

Constraints:
The toy robot must not fall off the table during movement. This also includes the initial placement of the toy robot. Anymove that would cause the robot to fall must be ignored.

Example Input and Output:

a)

PLACE 0,0,NORTH

MOVE

REPORT

Output: 0,1,NORTH

b)

PLACE 0,0,NORTH

LEFT

REPORT

Output: 0,0,WEST

c)

PLACE 1,2,EAST

MOVE

MOVE

LEFT

MOVE

REPORT

Output: 3,3,NORTH"
