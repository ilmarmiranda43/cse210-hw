public class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor() => _color;
    public void SetColor(string color) => _color = color;

    // Virtual: classes filhas vão sobrescrever
    public virtual double GetArea()
    {
        return 0; // forma genérica não tem área definida
    }

    public string GetSummary()
    {
        return $"{GetType().Name} | Color: {GetColor()} | Area: {GetArea():0.###}";
    }
}
