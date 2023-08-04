namespace StudentManagement;

class Student
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public readonly int RollNumber;
    public double Grade { get; set; }

    public static int PrevRollNumber = 0;

    public Student (string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;

        PrevRollNumber += 1;
        RollNumber = PrevRollNumber;
    }
}

