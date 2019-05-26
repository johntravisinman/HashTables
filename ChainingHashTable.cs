using System;

// Hash table using chaining
public class ChainingHashTable
{
    // The hash table (just an array of hash entries)
    private HashEntry[] hashTable;
    private int tableSize;

    // Constructor
    public ChainingHashTable(int size)
    {
        // create an empty hashTable
        hashTable = new HashEntry[size];
        for (int i = 0; i < size; i++)
        {
            hashTable[i] = null;
        }

        // set the size field
        this.tableSize = size;
    }

    // Populate the hash table with the given values
    public void Populate(int[] values)
    {
        int key;
        for (int i = 0; i < values.Length; i++)
        {
            // Simple hash on the value to get the key
            // key = value % tableSize
            key = values[i] % tableSize;

            // No collision
            if (hashTable[key] == null)
            {
                // Store the new entry
                hashTable[key] = new HashEntry(values[i]);
            }

            // Collision. So chain
            else
            {
                HashEntry tempEntry = hashTable[key];

                // Loop through the chain until the end
                while (tempEntry.Next != null)
                {
                    tempEntry = tempEntry.Next;
                }

                // Store the new entry
                tempEntry.Next = new HashEntry(values[i]);
            }

        }
    }

    // Print the hash table
    public void Print()
    {
        Console.WriteLine("{0,3}:{1,6}", "Key", "Value");
        for (int i = 0; i < tableSize; i++)
        {
            // Empty
            if (hashTable[i] == null)
            {
                Console.WriteLine(i + "\tnull");
            }

            // Non-Empty
            else
            {
                // Get the first chained entry
                HashEntry nextEntry = hashTable[i].Next;
                Console.Write("{0,3}:{1, 6} ", i, hashTable[i].Data);
                while (nextEntry != null)
                {
                    Console.Write("-> {0, 6} ", nextEntry.Data);
                    nextEntry = nextEntry.Next;
                }
            }
            Console.WriteLine("");
        }
    }
}