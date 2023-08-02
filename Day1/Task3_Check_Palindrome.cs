namespace Learning_Track_Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter The Input: ");
        string input = FilterWord(Console.ReadLine());

        Console.WriteLine("Filtered Input " + input);

        bool result = CheckPalindrome(input);
        Console.WriteLine("Result: " + result);

        Console.ReadLine();
    }

    static string FilterWord(string input)
    {
        input.ToLower();
        List<char> result = new List<char>();
        int size = input.Length;

        for (int i = 0; i < size; i++)
        {
            if (Char.IsPunctuation(input[i]) || input[i] == ' ')
                continue;
            result.Add(input[i]);
        }

        return String.Join("", result);
    }

    static bool CheckPalindrome(string input)
    {
        int left, right;
        left = 0;
        right = input.Length - 1;

        while (left < right)
        {
            if (input[left] != input[right])
                return false;

            left += 1;
            right -= 1;
        }

        return true;
    }

}

