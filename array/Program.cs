int[] randomnumbers = { 1, 23, 42, 12, 313, 13, 424, 2523, 23, 0 };

// counting
// Find how many even numbers are in this array

int numberofEvens = 0;
for (int i = 0; i < randomnumbers.Length; i++)
{
    if (randomnumbers[i] % 2 == 0)
    {
        numberofEvens++; // ++ means add 1
        Console.WriteLine(randomnumbers[i]);
    }
    else
    {
        numberofodds++; // ++ means add 1
        Console.WriteLine(randomnumbers[i]);
    }

}

Console.WriteLine("There are " + numberofEvens + " even numbers in this list");
Console.WriteLine("There are " + numberofodds + " odd numbers in this list");