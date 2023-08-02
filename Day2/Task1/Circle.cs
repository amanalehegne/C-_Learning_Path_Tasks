using Learning_Track_Tasks;

class Circle : Shapes
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double Radius
    {
        get { return radius; }
        set
        {
            radius = value;
        }
    }

    public override double CalculateArea()
    {
        return (radius * radius) * Math.PI;
    }
}