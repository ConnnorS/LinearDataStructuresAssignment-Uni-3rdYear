using Bogus;

class App
{
    static void Main()
    {
        Faker faker = new Faker();

        int totalComparisons;

        for (int num = 0; num <= 10000; num += 100)
        {
            MemberCollection myCollection = new MemberCollection(num);
            totalComparisons = 0;

            for (int i = 0; i < num; i++)
            {
                Member member = new Member(faker.Name.FullName(), faker.Name.LastName());
                totalComparisons += myCollection.AddCompare(member);
            }

            Console.WriteLine($"{num},{totalComparisons}");
        }
    }
}