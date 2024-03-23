TakeHome Exam Dye & Durham

dotnet new sln -name name-sorter

dotnet new console -o name-sorter
dotnet new xunit -o name-sorter-test
dotnet new console -o generate-data


# Name Sorter

## Overview

This project aims to sort a list of names provided in a text file based on last names and given names.

## User Class

When starting this project, I immediately created a `User` class to represent individuals. Each user object contains properties for last name and given names. To accommodate the possibility of multiple given names, I used an IEnumerable<string> for the `GivenNames` property. This decision was made because IEnumerable is a lighter-weight interface compared to List<string>, and it signifies that the collection can be iterated over to access its elements, but the elements themselves cannot be modified. This aligns well with the purpose of `GivenNames`, which is to represent a user's given names in a fixed order. Additionally, I overrode the `ToString` method to provide a string representation of the user's full name.

## NameSorter Class

To facilitate sorting and printing the names, I created a `NameSorter` class with a method `SortAndPrintUsersAsync`. This method reads names from a file, sorts them based on last names and given names, and prints the sorted list to the console. To handle asynchronous operations efficiently, I utilized async/await patterns for reading lines from the file and adding users to a ConcurrentBag<User> for thread safety. The sorted users are then printed to the console, and their names are written to a new file called "sorted-names-list.txt".

## Usage
To use the name sorter, follow these steps:

1. Compile the project.
2. Run the compiled executable with the path to the input file as a command-line argument.


```bash
cd /name-sorter/bin/Debug/net8.0/

./name-sorter ./unsorted-names-list.txt
```

## Error Handling
The program includes error handling to catch exceptions such as file not found or sorting/printing errors.

csharp
```bash
try
{
    // Main logic here
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Error: File not found: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error sorting and printing names: {ex.Message}");
}
```


## Unit Tests
The project includes unit tests to ensure the correctness of the sorting algorithm and the handling of file operations.

## SortsAndPrintsUsersCorrectly
This test verifies that the SortAndPrintUsersAsync method correctly sorts and prints the users to the console.

ThrowsFileNotFoundExceptionForNonexistentFile
This test verifies that the SortAndPrintUsersAsync method throws a FileNotFoundException when attempting to sort a nonexistent file.

How to Run Tests
To run the unit tests, follow these steps:

Navigate to the project directory.
Run the following command:
bash
```bash
dotnet test
```
## Dependencies
This project uses .NET Core and requires no additional dependencies.

## Authors
Kursat Arslan