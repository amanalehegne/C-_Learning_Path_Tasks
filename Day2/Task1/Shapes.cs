namespace Learning_Track_Tasks;

abstract class Shapes
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            name = value;
        }
    }

    public abstract double CalculateArea();
}