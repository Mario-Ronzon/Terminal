public class DataPoint
{
    public System.ConsoleColor AxisBackgroundColor { get; set; }
    public System.ConsoleColor AxisForegroundColor { get; set; }
    public System.ConsoleColor DataBackgroundColor { get; set; }
    public System.ConsoleColor DataPrimaryColor { get; set; }
    public System.ConsoleColor DataSecondaryColor { get; set; }
    public System.ConsoleColor LabelBackgroundColor { get; set; }
    public System.ConsoleColor LabelForegroundColor { get; set; }
    public double Data { get; set; }
    public string DataLabel { get; set; }
    public string AxisLabel { get; set; }
    public bool DataLabelVisible { get; set; }
    public bool AxisLabelVisible { get; set; }
    public bool UseDataCustomColors { get; set; }
    public bool UseAxisCustomColors { get; set; }

    public DataPoint() 
    {
        AxisBackgroundColor = System.Console.BackgroundColor;
        AxisForegroundColor = System.Console.ForegroundColor;
        DataBackgroundColor = System.Console.BackgroundColor;
        DataPrimaryColor = System.Console.ForegroundColor;
        DataSecondaryColor = System.Console.ForegroundColor;
        LabelBackgroundColor = System.Console.BackgroundColor;
        LabelForegroundColor = System.Console.ForegroundColor;
    }

    public DataPoint(double data) 
    {
        AxisBackgroundColor = System.Console.BackgroundColor;
        AxisForegroundColor = System.Console.ForegroundColor;
        DataBackgroundColor = System.Console.BackgroundColor;
        DataPrimaryColor = System.Console.ForegroundColor;
        DataSecondaryColor = System.Console.ForegroundColor;
        LabelBackgroundColor = System.Console.BackgroundColor;
        LabelForegroundColor = System.Console.ForegroundColor;

        Data = data;
    }
}