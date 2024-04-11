using Bogus;

class App
{
    static void Main()
    {
        Faker faker = new Faker();

        int binaryComparisons;
        int sequentialComparisons;

        int maxComparisons = 10000;
        int iteration = 100;

        Console.WriteLine("Binary Search Comparisons:");
        for (int num = 0; num <= maxComparisons; num += iteration)
        {
            MemberCollection myCollection = new MemberCollection(num);

            binaryComparisons = 0;
            for (int i = 0; i < num; i++)
            {
                Member member = new Member(faker.Name.FullName(), faker.Name.LastName());
                binaryComparisons += myCollection.AddBinary(member);
            }
            Console.WriteLine($"{num},{binaryComparisons}");
        }

        Console.WriteLine("Sequential Search Comparisons:");
        for (int num = 0; num <= maxComparisons; num += iteration)
        {
            MemberCollection myCollection = new MemberCollection(num);

            sequentialComparisons = 0;
            for (int i = 0; i < num; i++)
            {
                Member member = new Member(faker.Name.FullName(), faker.Name.LastName());
                sequentialComparisons += myCollection.AddSequential(member);
            }
            Console.WriteLine($"{num},{sequentialComparisons}");
        }
    }
}