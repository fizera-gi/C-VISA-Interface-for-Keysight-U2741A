Keysight U2741A Multimeter Control Application

A C# console application for controlling and reading measurements from a Keysight U2741A multimeter using VISA communication.


✨ Features



🚀 Getting Started : Prerequisites

   
## Installation

1. Clone this repository
2. Open the solution in Visual Studio
3. Restore NuGet packages (if any)
4. Build the solution

## Usage

Update the VISA address in `Program.cs` to match your instrument:

```csharp
string visaAddress = "USB0::0x0957::0x4918::MY61170017::0::INSTR";
