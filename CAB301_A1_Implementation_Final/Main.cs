class App
{
    static void Main()
    {
        MemberCollection myCollection = new MemberCollection(10);
        Member member1 = new Member("John", "Doe", "1234", "1234");
        Member member2 = new Member("Jane", "Doe", "1234", "1234");
        Member member3 = new Member("John", "Smith", "1234", "1234");
        Member member4 = new Member("Jane", "Smith", "1234", "1234");
        Member member5 = new Member("Connor", "Southern");
        Member member6 = new Member("James", "De Raat");
        Member member7 = new Member("Mitchell", "Thomas");

        myCollection.Add2(member1);
        Console.WriteLine(myCollection.ToString());
        myCollection.Add2(member2);
        Console.WriteLine(myCollection.ToString());
        myCollection.Add2(member3);
        Console.WriteLine(myCollection.ToString());
        myCollection.Add2(member4);
        Console.WriteLine(myCollection.ToString());

    }
}