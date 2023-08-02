namespace Learning_Track_Tasks;

class Programs
{
    static void Main(string[] args)
    {
        Shapes shape = GetShape();

        PrintShapeArea(shape);

        Console.ReadLine();
    }

    public static void PrintShapeArea(Shapes shape)
    {
        string name = shape.Name;
        double area = shape.CalculateArea();

        Console.WriteLine($"The Area Of The {name} is {area}");
    }

    public static double FilterNumber(string type)
    {
        while (true)
        {
            Console.Write($"Enter {type}: ");
            try
            {
                double res = double.Parse(Console.ReadLine());

                if (res > 0)
                    return res;
                else
                    Console.WriteLine("Invalid input. Please enter a positive number.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }


    public static Shapes GetShape()
    {
        Shapes shape;
        while (true)
        {
            Console.Write($"Enter Shape: ");
            string input = Console.ReadLine().ToLower();

            if (input == "circle")
            {
                double radius = FilterNumber("Radius");
                shape = new Circle(radius);
                break;
            }
            else if (input == "rectangle")
            {
                double height = FilterNumber("Height");
                double width = FilterNumber("Width");
                shape = new Rectangle(height, width);
                break;
            }
            else if (input == "triangle")
            {
                double height = FilterNumber("Height");
                double base_ = FilterNumber("Base");
                shape = new Triangle(height, base_);
                break;
            }
            Console.WriteLine("Available only for Circle, Rectangle, and Triangle! Try Again.");

        }
        return shape;
    }
}