using Learning_Track_Tasks;

class Triangle : Shapes
{
    private double base_;
    private double height;

    public Triangle(double base_, double height)
    {
        this.Name = "Triangle";
        this.base_ = base_;
        this.height = height;
    }

    public double Base
    {
        get { return base_; }
        set { base_ = value; }
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public override double CalculateArea()
    {
        return (base_ * height) / 2;
    }
}