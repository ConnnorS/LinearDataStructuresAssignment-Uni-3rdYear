class App {
    static void Main() {
        MemberCollection myCollection = new MemberCollection(10);
        Member member1 = new Member("John", "Doe");
        Member member2 = new Member("Jane", "Doe");
        Member member3 = new Member("John", "Smith");
        Member member4 = new Member("Harry", "Potter");
        Member member5 = new Member ("Connor", "McCarthy");

        myCollection.Add2(member1);
        myCollection.Add2(member2);
        myCollection.Add2(member3);
        myCollection.Add2(member4);
       int numOfComparisons = myCollection.Add2(member5);
       Console.WriteLine("Number of comparisons: " + numOfComparisons);

    }
}