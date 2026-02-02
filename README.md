# Toy Robot Simulator

A .NET 8 console application that simulates a toy robot moving on a 5x5 square tabletop.

## Core Classes

1. **Direction.cs** - Enum for `NORTH`, `EAST`, `SOUTH`, `WEST`
2. **Position.cs** - Immutable position class with movement logic
3. **Robot.cs** - Robot state management with `Place`, `Move`, `TurnLeft`, `TurnRight`, and `Report` methods
4. **Table.cs** - 5x5 table with boundary validation
5. **CommandParser.cs** - Parses command strings into executable actions
6. **RobotSimulator.cs** - Orchestrates all components and enforces rules

## Features Implemented

- ✓ 5x5 table with boundary protection
- ✓ `PLACE X,Y,F` command (must be first valid command)
- ✓ `MOVE` command (prevented if would cause fall)
- ✓ `LEFT`/`RIGHT` rotation commands
- ✓ `REPORT` command outputs "X,Y,DIRECTION"
- ✓ Commands ignored until valid PLACE executed
- ✓ Supports both file input and interactive console mode

## Test Files

| Test File | Description | Expected Output |
|-----------|-------------|-----------------|
| `test1.txt` | Basic movement | `0,1,NORTH` |
| `test2.txt` | Rotation test | `0,0,WEST` |
| `test3.txt` | Complex movement | `3,3,NORTH` |
| `test4.txt` | Commands before PLACE ignored | `0,1,NORTH` |
| `test5.txt` | Boundary protection test | `4,4,EAST` |

## How to Run

### From File
```bash
FranzToyRobotTest.exe test1.txt
```

### Interactive Mode
```bash
FranzToyRobotTest.exe
```
Type commands interactively. Use `EXIT` to quit.

## Example Commands

```
PLACE 0,0,NORTH
MOVE
REPORT
LEFT
RIGHT
```

## Notes
- The application is build for coding test
- by: Francis B H Eusebio (2/2/2026)
