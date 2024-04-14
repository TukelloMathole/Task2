# Dataset Processing Console Application

This console application is designed to process employee data stored in a CSV file. It reads the data from the file, sorts it by the joining year of employees, and then displays the sorted data.

## Features

- Read employee data from a CSV file.
- Sort the data by the joining year of employees.
- Display the sorted data in the console.

## Getting Started

To use this application, follow these steps:

1. Clone or download the repository to your local machine.

2. Ensure that you have the .NET Core SDK installed on your machine.

3. Navigate to the directory containing the application files.

4. Open a terminal or command prompt in that directory.

5. Build the application by running the following command:

dotnet build


6. Run the application by executing the following command:

dotnet run


7. The application will read the employee data from the "Employee.csv" file in the same directory, sort it by the joining year, and display the sorted data in the console.

## File Structure

- `Program.cs`: Contains the main logic of the application.
- `Employee.cs`: Defines the `Employee` class used to represent employee data.
- `Employee.csv`: Sample CSV file containing employee data.

## Dependencies

This application doesn't have any external dependencies beyond the .NET Core runtime.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for detail