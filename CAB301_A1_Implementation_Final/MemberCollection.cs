//CAB301 assessment 1 
//The implementation of MemberCollection ADT
using System;
using System.Collections;
using System.Globalization;
using System.Linq;


//Invariants: Capacity >= Count; Count >=0; and members in this member collection are sorted in alphabetical order by their full name (if there are two members who have the same last name, they are sorted by their first name in alphabetical order).


class MemberCollection : IMemberCollection
{
    // Fields
    private int capacity;
    private int count;
    private Member[] members; //members are sorted in alphabetical order

    // Properties

    // get the capacity of this member collection 
    // pre-condition: nil
    // post-condition: return the capacity of this member collection and this member collection remains unchanged
    public int Capacity { get { return capacity; } }

    // get the number of members in this member collection 
    // pre-condition: nil
    // post-condition: return the number of members in this member collection and this member collection remains unchanged
    public int Number { get { return count; } }

    public Member[] Members { get { return members; } }

    // Constructor - to create an object of member collection 
    // Pre-condition: capacity > 0
    // Post-condition: an object of this member collection class is created

    public MemberCollection(int capacity)
    {
        if (capacity > 0)
        {
            this.capacity = capacity;
            members = new Member[capacity];
            count = 0;
        }
    }

    // check if this member collection is full
    // Pre-condition: nil
    // Post-condition: return true if this member collection is full; otherwise return false. This member collection remains unchanged.
    public bool IsFull()
    {
        return count == capacity;
    }

    // check if this member collection is empty
    // Pre-condition: nil
    // Post-condition: return true if this member collection is empty; otherwise return false. This member collection remains unchanged.
    public bool IsEmpty()
    {
        return count == 0;
    }

    // Add a new member to this member collection
    // Pre-condition: this member collection is not full
    // Post-condition: The given member is added to this member collection and the members remains sorted in alphabetical order by their full names, if the given member does not appear in this member collection; otherwise, the given member is not added to this member collection. 
    // No duplicate has been added into this the member collection

    /* FOR TESTING PURPOSES ONLY */
    public int AddSequential(IMember member)
    {
        int comparisons = 0;

        // check if the collection is full
        if (IsFull()) return comparisons;
        // if the collection is empty, don't bother with sorting
        if (IsEmpty())
        {
            members[0] = (Member)member;
            count++;
            return comparisons;
        }
        // find the position in the list to insert the new member
        int index;
        for (index = 0; index < Number; index++)
        {
            int comparison = member.CompareTo(members[index]);
            comparisons++;
            // if the member is the same as the current member (duplicate), don't insert it
            if (comparison == 0) return comparison;

            // if the member is less than the current member, insert it here
            else if (comparison < 0) break;

            /* if we reach the end of index without breaking, then the member needs
            to be inserted at the end of the array so we'll just keep going with index 
            equal to Number */
        }
        // shift all the members to the right of where the new member is meant to go
        for (int pos = Number; pos > index; pos--) members[pos] = members[pos - 1];

        // insert the member in the new free position
        members[index] = (Member)member;
        // update the count
        count++;

        return comparisons;
    }
    /* FOR TESTING PURPOSES ONLY */
    public int AddBinary(IMember member)
    {
        int comparisons = 0;
        if (IsFull()) return comparisons; // check if the collection is full

        if (IsEmpty()) // if the collection is empty, don't bother with sorting
        {
            members[0] = (Member)member;
            count++;
            return comparisons;
        }

        // define the indexes for the binary search
        int left = 0;
        int right = Number - 1;
        int index = 0;

        // do the binary search
        while (left <= right)
        {
            int mid = (left + right) / 2;
            int comparison = member.CompareTo(members[mid]);
            comparisons++;

            if (comparison == 0) return comparisons; // check for duplicates
            else if (comparison < 0) // if the member goes before the mid point
            {
                right = mid - 1;
                index = mid;
            }
            else // otherwise, the member goes after the mid point
            {
                // Member should be inserted after mid
                left = mid + 1;
                index = left;
            }
        }

        // once the right index is found, shift all members after that to the right
        for (int pos = Number; pos > index; pos--)
        {
            members[pos] = members[pos - 1];
        }

        // insert the new member keeping the alphabetical ordering
        members[index] = (Member)member;
        count++;

        return comparisons;
    }
    
    /* HELLO TUTOR, PLEASE MARK THIS METHOD */
    public void Add(IMember member)
    {
        if (IsFull()) return; // check if the collection is full

        if (IsEmpty()) // if the collection is empty, don't bother with sorting
        {
            members[0] = (Member)member;
            count++;
            return;
        }

        // define the indexes for the binary search
        int left = 0;
        int right = Number - 1;
        int index = 0;

        // do the binary search
        while (left <= right)
        {
            int mid = (left + right) / 2;
            int comparison = member.CompareTo(members[mid]);

            if (comparison == 0) return; // check for duplicates
            else if (comparison < 0) // if the member goes before the mid point
            {
                right = mid - 1;
                index = mid;
            }
            else // otherwise, the member goes after the mid point
            {
                // Member should be inserted after mid
                left = mid + 1;
                index = left;
            }
        }

        // once the right index is found, shift all members after that to the right
        for (int pos = Number; pos > index; pos--)
        {
            members[pos] = members[pos - 1];
        }

        // insert the new member keeping the alphabetical ordering
        members[index] = (Member)member;
        count++;
    }


    // Remove a given member out of this member collection
    // Pre-condition: nil
    // Post-condition: the given member is removed from this member collection, if the given member is in this member collection and the members in this member collection remains sorted in alphabetical order by their full names; otherwise, no member is removed from this member collection and this member collection remains unchanged. 
    public void Delete(string lastname, string firstname)
    {
        // search through the collection for the member
        for (int index = 0; index < Number; index++)
        {
            // if the member is found, remember the index
            if (members[index].LastName == lastname && members[index].FirstName == firstname)
            {
                // shift every value to the right of that member to the left
                // this essentially overwrites the value of the member to be removed
                // while keeping the list in alphabetical order
                for (int j = index; j < Number - 1; j++)
                {
                    members[j] = members[j + 1];
                }
                count -= 1;
                members[Number] = null; // remove the final duplicate member
                break; // break so we don't loop again                
            }
        }
    }

    // Search a given member by last name and first name in this member collection 
    // Pre-condition: nil
    // Post-condition: return true if the given member is in this member collection; return false otherwise. This member collection remains unchanged.
    public bool Search(string lastname, string firstname)
    {
        // search through the collection for the member
        for (int index = 0; index < Number; index++)
        {
            // if the member is found, return true
            if (members[index].LastName == lastname && members[index].FirstName == firstname)
            {
                return true;
            }
        }
        // otherwise, return false
        return false;
    }

    // Remove all the members in this member collection
    // Pre-condition: nil
    // Post-condition: Capacity remins unchanged; Number = 0; this member collection is empty.
    public void Clear()
    {
        count = 0;
        members = new Member[capacity];
    }

    // Return a string containing the information about all the members in this member collection.
    // The information includes last name, first name and contact number in this order
    // Pre-condition: nil
    // Post-condition: a string containing the information about all the members in this member collection is returned, the order of the members in the returned string is the same with that in this member collection and this collection remains unchanged. 
    //                  The information about a member includes the last name, first name and contact phone number of the member, which are separated by a comma (no whitespace before or after the comma). The members are separated by a semicolon (no white space before or after the semicolon).
    public override string ToString()
    {
        string returnValue = "";
        for (int index = 0; index < Number; index++)
        {
            Member current = members[index];
            returnValue += $"{current.LastName},{current.FirstName},{current.ContactNumber};";
        }
        return returnValue;
    }
}