namespace MyHashTableAlgorithms;

public class Program
{
    static void Main(string[] args)
    {
        GetNextBytes(startIndex: 0, "lore");
        string input = string.Empty;

        while (!input.Equals("quit", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("> ");
            Console.WriteLine("Folding: {0}", FoldingHash(input));
        }
    }

    public static int AdditiveHash(string input)
    {
        int currentHash = 0;
        foreach (char c in input)
        {
            unchecked
            {
                currentHash += (int)c;
            }
        }
        return currentHash;
    }

    public static int FoldingHash(string input)
    {
        int hashValue = 0;

        int startIndex = 0;
        int currentFourBytes;

        do
        {
            currentFourBytes = GetNextBytes(startIndex, input);
            unchecked
            {
                hashValue += currentFourBytes;
            }
            startIndex += 4;
        } while (currentFourBytes != 0);

        return hashValue;
    }

    public static int GetNextBytes(int startIndex, string str)
    {
        int currentFourBytes = 0;

        currentFourBytes += GetByte(str, startIndex);
        currentFourBytes += GetByte(str, index: startIndex + 1) << 8;
        currentFourBytes += GetByte(str, index: startIndex + 2) << 16;
        currentFourBytes += GetByte(str, index: startIndex + 3) << 24;

        return currentFourBytes;
    }

    public static int GetByte(string str, int index)
    {
        if (index < str.Length)
        {
            return (int)str[index];
        }
        return 0;
    }
}