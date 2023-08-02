namespace Learning_Track_Tasks;

class Task1_Student_Registration
{
    static void Main(string[] args)
    {
        Console.Write("What Is Your Name: ");
        string studentName = Console.ReadLine();

        int subjectCount;
        while (true)
        {
            Console.Write("How Many Courses Did You Take: ");
            string subjectCountStr = Console.ReadLine();

            if (int.TryParse(subjectCountStr, out subjectCount))
                break;

            Console.WriteLine("Invalid input. Please enter a valid positive integer.");
        }

        Dictionary<string, double> gradeContainer = new Dictionary<string, double>();
        GetGrades(gradeContainer, subjectCount);

        Console.WriteLine("Student Name: " + studentName);
        foreach (var elmt in gradeContainer)
            Console.WriteLine(elmt.Key + " " + elmt.Value);

        double averageGrade = CalculateAverageGrade(gradeContainer);
        Console.WriteLine("Average Grade: " + averageGrade);

        Console.ReadLine();

    }

    static void GetGrades(Dictionary<string, double> gradeContainer, int subjectCount)
    {
        for (int i = 0; i < subjectCount; i++)
        {
            string subjectName;
            while (true)
            {
                Console.Write("Enter " + (i + 1) + "th Subject Name: ");
                subjectName = Console.ReadLine();

                if (gradeContainer.ContainsKey(subjectName))
                {
                    Console.WriteLine("Subject Already Exists! Try Again");
                }
                else
                {
                    break;
                }
            }

            double grade;
            while (true)
            {
                Console.Write("Enter " + (i + 1) + "th Subject Grade: ");
                string gradeStr = Console.ReadLine();

                if (double.TryParse(gradeStr, out grade) && grade >= 0 && grade <= 100)
                    break;

                Console.WriteLine("Invalid Grade. Please enter a valid grade between 0 and 100.");
            }

            gradeContainer[subjectName] = grade;
        }
    }

    static double CalculateAverageGrade(Dictionary<string, double> gradeContainer)
    {
        if (gradeContainer.Count == 0)
            return 0;

        double totalGrade = 0;
        foreach (double grade in gradeContainer.Values)
            totalGrade += grade;

        return totalGrade / gradeContainer.Count;
    }

}

