using System.Collections.Concurrent;

namespace name_sorter;

public class User
{
    public string LastName { get; }
    public IReadOnlyList<string> GivenNames { get; }

    public User(string lastName, IReadOnlyList<string> givenNames)
    {
        LastName = lastName;
        GivenNames = givenNames;
    }

    public override string ToString()
    {
        return $"{string.Join(" ", GivenNames)} {LastName}";
    }
}

public class NameSorter
{
    private readonly StreamReader _reader;

    public NameSorter(StreamReader reader)
    {
        _reader = reader;
    }
    public async Task SortAndPrintUsersAsync(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentNullException(nameof(filePath));
        }
        try
        {
            var users = new ConcurrentBag<User>();
            var tasks = new List<Task>();
            while (await _reader.ReadLineAsync() is { } line)
            {
                var lineCopy = line;
                tasks.Add(Task.Run(() =>
                {
                    var nameParts = line.Split(' ');
                    var user = new User(nameParts.LastOrDefault(), nameParts.Take(nameParts.Length - 1).ToList());
                    users.Add(user);
                }));
            }

            await Task.WhenAll(tasks);

            var sortedUsers = users.OrderBy(u => u.LastName)
                .ThenBy(u => string.Join(" ", u.GivenNames)).ToList();

            foreach (var user in sortedUsers)
            {
                Console.WriteLine(user);
            }

            await File.WriteAllLinesAsync("sorted-names-list.txt", sortedUsers.Select(u => u.ToString()));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sorting and printing names: {ex.Message}");
        }
    }
}


public static class Program
{
    public static async Task Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: name-sorter <file-path>");
            return;
        }
        string filePath = args[0];

        try
        {
            using var reader = new StreamReader(filePath);
            var nameSorter = new NameSorter(reader);
            await nameSorter.SortAndPrintUsersAsync(filePath);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Error: File not found: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sorting and printing names: {ex.Message}");
        }
    }
}