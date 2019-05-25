using System;

namespace HashingExamples
{
    // The entry that will be stored in the hash tables
    public class HashEntry
    {
        // private field for data in hash entry
        private int data;
        // public property to access the data in the hash entry
        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        // The next hash entry
        public HashEntry next;
        // Constructor
        public HashEntry(int data)
        {
            this.data = data;
            next = null;
        }
        // Default Constructor
        public HashEntry()
        {
            data = 0;
            next = null;
        }
    }
    // Hash table using chaining
    public class ChainingHashTable
    {
        // The hash table (just an array of hash entries)
        private HashEntry[] hashTable;
        private int size;
        // Constructor
        public ChainingHashTable(int size)
        {
            // create an empty hashTable
            hashTable = new HashEntry[size];
            for(int i = 0; i < size; i++)
            {
                hashTable[i] = null;
            }
            // set the size field
            this.size = size;
        }
        // Populate the hash table with the given values
        public void Populate(int[] values)
        {
            int key;
            for(int i = 0; i < values.Length; i++)
            {
                // Simple hash on the value to get the key
                // key = value % tableSize
                key = values[i] % size;
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
                    while (tempEntry.next != null)
                    {
                        tempEntry = tempEntry.next;
                    }
                    // Store the new entry
                    tempEntry.next = new HashEntry(values[i]);
                }

            }
        }

        // Print the hash table
        public void Print()
        {
            Console.WriteLine("{0,3}:{1,6}","Key","Value");
            for(int i = 0; i < size; i++)
            {
                // Empty
                if(hashTable[i] == null)
                {
                    Console.WriteLine(i + "\tnull");
                }
                // Non-Empty
                else
                {
                    // Get the first chained entry
                    HashEntry nextEntry = hashTable[i].next;
                    Console.Write("{0,3}:{1, 6} ", i, hashTable[i].Data);
                    while(nextEntry != null)
                    {
                        Console.Write("-> {0, 6} ", nextEntry.Data);
                        nextEntry = nextEntry.next;
                    }
                }
                Console.WriteLine("");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Sizes for both the sample data and the table itself. (eventually user input)
            const int tableSize = 100;
            const int dataSize = 1000;
            // Array of random ints. This will be sample data for all hash tables
            int[] arrayOfRandomInts = GetArrayOfRandomInts(dataSize, 100000);
            // Create an empty chaining hash table
            ChainingHashTable chainingHashTable = new ChainingHashTable(tableSize);
            chainingHashTable.Populate(arrayOfRandomInts);
            chainingHashTable.Print();
        }

        static int[] GetArrayOfRandomInts(int size, int range)
        {
            // Pseudo-random number generator
            Random rand = new Random();
            int[] arr = new int[size];
            for(int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(range);
            }
            return arr;
        }
    }
}
