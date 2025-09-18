
# C# VISA Interface for Keysight U2741A

This project is a C\# application designed to interface with a Keysight/Agilent U2741A Digital Multimeter (DMM) using the VISA (Virtual Instrument Software Architecture) library. It provides a simple, object-oriented way to configure and read DC voltage measurements from the DMM.

-----

## ⚡ Key Features

  * **Device Identification**: Retrieves the instrument's identification string.
  * **DC Voltage Measurement**: Configures the DMM for DC voltage readings and performs a measurement.
  * **Automatic Cleanup**: Ensures proper resource disposal upon completion, even in case of errors.

-----

## 🛠️ Prerequisites

Before you can build and run this project, you need to have the following installed:

  * **.NET SDK**: The project targets **.NET 8.0**. You'll need the corresponding SDK installed on your machine.
  * **Keysight I/O Libraries**: This project relies on Keysight's VISA implementation for communication with the DMM. You must have the Keysight I/O Libraries installed. The project uses the `VisaComLib` COM reference.
  * **Correct VISA Address**: The `visaAddress` in `Program.cs` must be configured to match your specific DMM. The example address `USB0::0x0957::0x4918::MY61170017::0::INSTR` is for a Keysight U2741A, but you should verify it against your device's address in the Keysight Connection Expert.

-----

## 🚀 Getting Started

### Building the Project

1.  **Clone the repository**:
    ```bash
    git clone https://github.com/fizera-gi/C-VISA-Interface-for-Keysight-U2741A.git
    cd C-VISA-Interface-for-Keysight-U2741A
    ```
2.  **Restore dependencies**:
    ```bash
    dotnet restore
    ```
    This command will restore the necessary packages and references defined in `Test_U2741A.csproj`, including the `VisaComLib`[cite: 1].
3.  **Build the project**:
    ```bash
    dotnet build
    ```

### Running the Application

1.  **Connect the DMM**: Ensure your Keysight U2741A is connected to your computer via USB and is recognized by the Keysight Connection Expert.
2.  **Update the VISA Address**: Open the `Program.cs` file and change the `visaAddress` variable to match the address of your DMM.
3.  **Run the application**:
    ```bash
    dotnet run
    ```

The application will then connect to the DMM, retrieve its ID, configure it for a 10V DC voltage measurement, and display the result in the console.

-----

## 📂 Project Structure

  * **`Program.cs`**: The entry point of the application. It demonstrates how to create a `CentraleMesure` object, configure the DMM, and read a value.
  * **`CentraleMesure.cs`**: This class encapsulates the VISA communication logic. It handles opening and closing the connection, sending SCPI commands, and reading responses. It includes methods for identifying the device (`Idn`), configuring and reading DC voltage (`ConfigureVdc`, `ReadVdc`), and a placeholder for resistance measurements (`ConfigureResistance`, `ReadResistance`).
 

-----

## 📝 Extending the Project

The `CentraleMesure` class is designed to be extensible. You can add more methods to support other DMM functions by writing new SCPI commands to the `_io` object, similar to the `ConfigureVdc` and `ReadVdc` methods. For example, you could add support for AC voltage, current, or frequency measurements.
