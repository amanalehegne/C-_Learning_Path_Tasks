namespace Learning_Track_Tasks;

class Task2_Word_Counter
{
    static void Main(string[] args)
    {
        Dictionary<string, int> wordCounter = new Dictionary<string, int>();

        Console.Write("Enter The Input: ");
        string input = Console.ReadLine();

        input = RemovePunctuation(input);

        string[] words = input.Split(' ');

        int size = words.Length;
        for (int i = 0; i < size; i++)
        {

            if (wordCounter.ContainsKey(words[i]))
                wordCounter[words[i]] += 1;
            else
                wordCounter[words[i]] = 1;
        }

        Console.WriteLine("The Frequence Of The Words In [" + input + "]");
        foreach (var elmt in wordCounter)
            Console.WriteLine(elmt.Key + " " + elmt.Value);

        Console.ReadLine();
    }

    static string RemovePunctuation(string word)
    {
        int size = word.Length;
        List<Char> res = new List<char>();
        for (int i = 0; i < size; i++)
        {
            if (Char.IsPunctuation(word[i]))
                continue;
            res.Add(char.ToLower(word[i]));


        }
        return string.Join("", res);
    }

}

