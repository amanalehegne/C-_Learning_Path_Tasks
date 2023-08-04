namespace StudentManagement;

class Program
{
    static void Main(string[] args)
    {
        StudentList<Student> studentList = new StudentList<Student>();

        studentList.ListStudents();

        string fileName = "/Users/amanuelwubete/Desktop/file.json";
        UserInterface(studentList);


    }

    static void UserInterface(StudentList<Student> studentList)
    {
        while (true)
        {
            Console.WriteLine("What Do You Want To Do?: ");
            Console.WriteLine("1) Add Student");
            Console.WriteLine("2) Display All The Students");
            Console.WriteLine("3) Search For Student (By Name Or ID)");
            Console.WriteLine("4) Import Class From Json File");
            Console.WriteLine("5) Export Class To Json File");
            Console.WriteLine("6) Exit");

            try
            {
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        AddStudent(studentList);
                        break;
                    case 2:
                        studentList.ListStudents();
                        break;
                    case 3:
                        studentList.SearchStudent();
                        break;
                    case 4:
                        Console.Write("Enter File Path: ");
                        string ImportFileName = Console.ReadLine();
                        studentList.DeSerialize(ImportFileName);
                        break;
                    case 5:
                        Console.Write("Enter File Path: ");
                        string ExportFileName = Console.ReadLine();
                        studentList.Serialize(ExportFileName);
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Option Must Be In Range Of 1-6");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Format for Option :(");
            }
        }
    }

    static void AddStudent(StudentList<Student> studentList)
    {
        try
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Grade: ");
            double grade = double.Parse(Console.ReadLine());

            studentList.AddStudent(new Student(name, age, grade));

            Console.WriteLine("Student Enter Successfully :)");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid Format for age or grade :(");
        }
    }

}

