using System;

// The entry that will be stored in the hash tables
public class HashEntry
{
    // Fields
    // private field for data in hash entry
    private int data;

    // the next chained hash entry
    private HashEntry next;

    // Constructors
    public HashEntry(int data)
    {
        this.data = data;
        this.Next = null;
    }

    // Default
    public HashEntry()
    {
        this.data = 0;
        this.Next = null;
    }

    // Properties
    public int Data
    {
        get { return this.data; }
        set { this.data = value; }
    }

    public HashEntry Next
    {
        get { return this.next; }
        set { this.next = value; }
    }
}