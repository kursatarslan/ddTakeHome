using System;
using System.IO;

class NameGenerator
{
    static string[] FirstNames = { "James", "John", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Charles", "Thomas",
                                    "Mary", "Patricia", "Linda", "Barbara", "Elizabeth", "Jennifer", "Susan", "Margaret", "Dorothy", "Lisa" };
    static string[] MiddleNames = { "Marie", "Louise", "Dorothy", "Elizabeth", "Catherine", "Josephine", "Anne", "Margaret", "Evelyn", "Helen", "", "" };
static string[] LastNames = {
    "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Rodriguez", "Wilson",
    "Moore", "Lewis", "Robinson", "Walker", "Clark", "Young", "Allen", "Wright", "King", "Scott",
    "Anderson", "Thomas", "Jackson", "Evans", "Benjamin", "Miller", "Nelson", "Campbell",
    "Carter", "Parker", "Hall", "Adams", "Bell", "Ellis", "Turner", "Phillips", "Powell", "Russell",
    "Edwards", "Brooks", "Hughes", "Lewis", "Cook", "Morgan", "Nguyen", "Lee", "Nguyen", "Lee",
    "Zhang", "Gonzalez", "Lopez", "Sanchez", "Menendez", "Garcia", "Hernandez", "Ramirez", "Cruz",
    "Yoder", "Miller", "Fisher", "King", "Miller", "Martin", "Davis", "Garcia", "Hernandez", "Lopez",
    "Robinson", "Moore", "Allen", "Taylor", "Thomas", "Wilson", "Brown", "Walker", "Moore", "Anderson",
    "Nelson", "Carter", "Williams", "Garcia", "Mitchell", "Hernandez", "Lopez", "Roberts", "Johnson", "Jones",
    "Chevalier", 
    "Rossi", 
    "Schmidt", 
    "Petrov", 
    "Murphy", 
    "Patel", 
    "Tanaka", 
    "Kim", 
    "Diallo", 
    "Mbappe", 
    "Mohammed", 
    "Cohen", 
    "Alexander", 
    "Rivera", 
};

    static void Main(string[] args)
    {
        const int NumNames = 10000;
        string filePath = "10000_names.txt";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < NumNames; i++)
            {
                string firstName = GetRandomName(FirstNames);
                string middleName = GetRandomName(MiddleNames);
                string lastName = GetRandomName(LastNames);
                string fullName = $"{firstName} {(middleName.Length > 0 ? middleName + " " : "")}{lastName}\n";
                writer.Write(fullName);
            }
        }

        Console.WriteLine($"Generated {NumNames} names and saved to {filePath}");
    }

    static string GetRandomName(string[] names)
    {
        return names[new Random().Next(names.Length)];
    }
}