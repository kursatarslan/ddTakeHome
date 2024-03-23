using name_sorter;

namespace name_sorter_test
{
    public class NameSorterTests
    {
        [Fact]
        public async Task SortsAndPrintsUsersCorrectly()
        {
            // Arrange
            const string filePath = "unsorted-names-list.txt";
            File.WriteAllLines(filePath, new string[]
            {
                "John Doe",
                "Jane Smith",
                "Alice Johnson",
                "Bob Brown",
            });
            // Act
            using var reader = new StreamReader(filePath);
            var nameSorter = new NameSorter(reader);
            await nameSorter.SortAndPrintUsersAsync(filePath);
            

            // Assert
            string[] expectedSortedNames = { "Bob Brown", "John Doe", "Alice Johnson", "Jane Smith" };
            var actualSortedNames = await File.ReadAllLinesAsync("sorted-names-list.txt");
            Assert.Equal(expectedSortedNames, actualSortedNames);

            // Clean up
            File.Delete(filePath);
            File.Delete("sorted-names-list.txt");
        }

        [Fact]
        public async Task ThrowsFileNotFoundExceptionForNonexistentFile()
        {
            // Arrange
            const string filePath = "non-existent-file.txt";

            // Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () =>
            {
                using var reader = new StreamReader(filePath);
                var nameSorter = new NameSorter(reader);
                await nameSorter.SortAndPrintUsersAsync(filePath);
            });
        }
    }
}