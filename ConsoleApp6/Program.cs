using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
     {
        ///// Part 01
        //////// HashTable(Non - Generic) ///////////

        //Structure: Key - value pairs, allows different data types.

        //Time Complexity: O(1) average, O(n) worst case.

        //Use Case: Legacy code, quick lookups in small datasets.
        //Example : 
        // Hashtable employees = new Hashtable();
        //employees.Add(1, "John");
        //Console.WriteLine(employees[1]);

        ////// Dictionary (Generic) ////////////

        //Structure: Key - value pairs, type - safe.

        //Time Complexity: O(1) average.

        //Use Case: Caching, indexing database records.
        //Example : 
        // Dictionary<int, string> students = new Dictionary<int, string>();
        //students.Add(101, "Mark");
        // Console.WriteLine(students[101]);

        //////SortedDictionary //////////////

        //Structure: Binary Search Tree(BST), keeps keys sorted.

        //Time Complexity: O(log n).

        // Use Case: Ordered storage, leaderboards.

        //Example :
        // SortedDictionary<int, string> users = new SortedDictionary<int, string>();
        // users.Add(1, "Alice");
        // Console.WriteLine(users[1]);


        //// SortedList //////////////

        //Structure: Uses two arrays internally.

        //Time Complexity: Insert O(n), Search O(log n).

        //Use Case: Read - heavy applications, sorted data.

        // Example:

        //     SortedList<int, string> employees = new SortedList<int, string>();
        //   employees.Add(1, "Emma");
        // Console.WriteLine(employees[1]);

        /////// HashSet ////////////

        // Structure: Hashing, unique elements.

        // Time Complexity: O(1) average.

        //Use Case: Storing unique values.

        // Example:
       // HashSet<int> uniqueNumbers = new HashSet<int>() { 1, 2, 3 };
        // Console.WriteLine(uniqueNumbers.Count);
        
        
        
        ////// Part 02

        #region Frequency Count using HashTable
        Console.WriteLine("Frequency Count using HashTable:");
        int[] array = { 1, 2, 3, 1, 2, 4, 5, 3, 1 };
        var frequency = CountFrequency(array);
        foreach (DictionaryEntry entry in frequency)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
        Console.WriteLine();
        #endregion

        #region Find Key with Highest Value in HashTable
        Console.WriteLine("Find Key with Highest Value in HashTable:");
        var hashTable = new Hashtable
        {
            { "key1", 10 },
            { "key2", 15 },
            { "key3", 7 }
        };
        string keyWithHighestValue = FindKeyWithHighestValue(hashTable);
        Console.WriteLine($"Key with highest value: {keyWithHighestValue}");
        Console.WriteLine();
        #endregion

        #region Find Keys Associated with Target Value
        Console.WriteLine("Find Keys Associated with Target Value:");
        var keyValueTable = new Hashtable
        {
            { "key1", "apple" },
            { "key2", "banana" },
            { "key3", "apple" }
        };
        string targetValue = "apple";
        FindKeysByValue(keyValueTable, targetValue);
        Console.WriteLine();
        #endregion

        #region Group Anagrams
        Console.WriteLine("Group Anagrams:");
        string[] words = { "listen", "silent", "enlist", "hello", "olleh" };
        var groupedAnagrams = GroupAnagrams(words);
        foreach (var group in groupedAnagrams)
        {
            Console.WriteLine(string.Join(", ", group));
        }
        Console.WriteLine();
        #endregion

        #region Check for Duplicates
        Console.WriteLine("Check for Duplicates:");
        int[] numbers = { 1, 2, 3, 4, 5, 2 };
        Console.WriteLine(ContainsDuplicates(numbers) ? "Duplicates found" : "No duplicates found");
        Console.WriteLine();
        #endregion

        #region SortedDictionary for Student IDs
        Console.WriteLine("SortedDictionary for Student IDs:");
        var studentDirectory = new SortedDictionary<int, string>();
        studentDirectory.Add(101, "Alice");
        studentDirectory.Add(102, "Bob");
        studentDirectory.Add(103, "Charlie");
        studentDirectory.Remove(102);
        foreach (var student in studentDirectory)
        {
            Console.WriteLine($"{student.Key}: {student.Value}");
        }
        Console.WriteLine();
        #endregion

        #region Employee Directory using SortedList
        Console.WriteLine("Employee Directory using SortedList:");
        var employeeDirectory = new SortedList<int, string>
        {
            { 1, "John" },
            { 3, "Emma" },
            { 2, "Sophia" }
        };
        foreach (var employee in employeeDirectory)
        {
            Console.WriteLine($"{employee.Key}: {employee.Value}");
        }
        Console.WriteLine();
        #endregion

        #region Find Missing Numbers
        Console.WriteLine("Find Missing Numbers:");
        int[] range = { 1, 2, 4, 6, 7 };
        int max = 7;
        var missingNumbers = FindMissingNumbers(range, max);
        Console.WriteLine("Missing numbers: " + string.Join(", ", missingNumbers));
        Console.WriteLine();
        #endregion

        #region HashSet with Unique Values
        Console.WriteLine("HashSet with Unique Values:");
        List<int> duplicateList = new List<int> { 1, 2, 2, 3, 4, 4, 5 };
        HashSet<int> uniqueValues = new HashSet<int>(duplicateList);
        Console.WriteLine("Unique values: " + string.Join(", ", uniqueValues));
        Console.WriteLine();
        #endregion

        #region Swap Keys and Values in HashTable
        Console.WriteLine("Swap Keys and Values in HashTable:");
        var originalHashTable = new Hashtable
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 }
        };
        var swappedHashTable = SwapKeysAndValues(originalHashTable);
        foreach (DictionaryEntry entry in swappedHashTable)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
        Console.WriteLine();
        #endregion

        #region Union of Two Sets
        Console.WriteLine("Union of Two Sets:");
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };
        var unionSet = UnionOfSets(set1, set2);
        Console.WriteLine("Union: " + string.Join(", ", unionSet));
        Console.WriteLine();
        #endregion

        #region Count Keys Starting with Target Character
        Console.WriteLine("Count Keys Starting with Target Character:");
        Dictionary<string, int> dictionary = new Dictionary<string, int>
        {
            { "apple", 1 },
            { "animal", 2 },
            { "airport", 3 }
        };
        char targetChar = 'a';
        int count = CountKeysStartingWith(dictionary, targetChar);
        Console.WriteLine($"Count: {count}");
        Console.WriteLine();
        #endregion
    }

    #region Methods
    static Hashtable CountFrequency(int[] array)
    {
        Hashtable frequency = new Hashtable();
        foreach (var num in array)
        {
            if (frequency.ContainsKey(num))
                frequency[num] = (int)frequency[num] + 1;
            else
                frequency[num] = 1;
        }
        return frequency;
    }

    static string FindKeyWithHighestValue(Hashtable hashtable)
    {
        string highestKey = "";
        int maxValue = int.MinValue;
        foreach (DictionaryEntry entry in hashtable)
        {
            if ((int)entry.Value > maxValue)
            {
                maxValue = (int)entry.Value;
                highestKey = (string)entry.Key;
            }
        }
        return highestKey;
    }

    static void FindKeysByValue(Hashtable hashtable, string value)
    {
        bool found = false;
        foreach (DictionaryEntry entry in hashtable)
        {
            if ((string)entry.Value == value)
            {
                Console.WriteLine(entry.Key);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Key not found");
        }
    }

    static List<List<string>> GroupAnagrams(string[] words)
    {
        var groups = new Dictionary<string, List<string>>();
        foreach (var word in words)
        {
            var sortedWord = String.Concat(word.OrderBy(c => c));
            if (!groups.ContainsKey(sortedWord))
            {
                groups[sortedWord] = new List<string>();
            }
            groups[sortedWord].Add(word);
        }
        return groups.Values.ToList();
    }

    static bool ContainsDuplicates(int[] array)
    {
        HashSet<int> uniqueNumbers = new HashSet<int>();
        foreach (var num in array)
        {
            if (!uniqueNumbers.Add(num)) return true;
        }
        return false;
    }

    static List<int> FindMissingNumbers(int[] array, int max)
    {
        HashSet<int> numbers = new HashSet<int>(array);
        List<int> missingNumbers = new List<int>();
        for (int i = 1; i <= max; i++)
        {
            if (!numbers.Contains(i))
            {
                missingNumbers.Add(i);
            }
        }
        return missingNumbers;
    }

    static Hashtable SwapKeysAndValues(Hashtable original)
    {
        Hashtable swapped = new Hashtable();
        foreach (DictionaryEntry entry in original)
        {
            swapped[entry.Value] = entry.Key;
        }
        return swapped;
    }

    static HashSet<int> UnionOfSets(HashSet<int> set1, HashSet<int> set2)
    {
        set1.UnionWith(set2);
        return set1;
    }

    static int CountKeysStartingWith(Dictionary<string, int> dictionary, char targetChar)
    {
        return dictionary.Keys.Count(key => key.StartsWith(targetChar.ToString()));
    }
    #endregion
        
}
