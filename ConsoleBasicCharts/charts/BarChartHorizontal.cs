public class BarChartHorizontal
{
    private const float FloatingCharValue = 0.5f;
    private ulong sizeX;
    private ulong sizeY;
    private int VerMaxLen;

    private double _heightScale;
    private double _widthScale;

    public uint BarSpacing { get; set; }
    public char DefaultEmptyChar { get; set; }
    public char DefaultFilledChar { get; set; }
    public char DefaultFloatingChar { get; set; }
    public char DataAxisLabelDefChar { get; set; }
    public char SerieAxisLabelDefChar { get; set; }

    public int HorFrameTickFreq { get; set; }
    public int VerFrameTickFreq { get; set; }
    public bool FrameTickOrientation { get; set; }

    public System.ConsoleColor BackgroundColor { get; set; }//del?
    public System.ConsoleColor ForeroundColor { get; set; }//del?
    public System.Collections.Generic.List<Serie> Series { get; set; }

    public bool DataAxisLabelVisible {get; set;}
    public bool SerieAxisLabelVisible {get; set;}
    public bool DataAxisCaretVisible {get; set;}
    public bool SerieAxisCaretVisible {get; set;}

    public bool TitleVisible { get; set; }
    public string TitleLabel { get; set; }
    public char TitleDefChar { get; set; }
    public System.ConsoleColor TitleBackgroundColor { get; set; }
    public System.ConsoleColor TitleForeroundColor { get; set; }

    public uint Height
    {
        get
        {
            return (uint)(_heightScale * sizeY);
        }
        set
        {
            if( value > 0 ) _heightScale = (double)value / (double)sizeY;
        }
    }
    public uint Width
    {
        get
        {
            return (uint)(_widthScale * sizeX);
        }
        set
        {
            if( value > 0 ) _widthScale = (double)value / (double)sizeX;
        }
    }

    public BarChartHorizontal() 
    {
        BarSpacing = 1;
        DefaultEmptyChar = ' ';
        DefaultFilledChar = '█';
        DefaultFloatingChar = '▄';
        DataAxisLabelDefChar = ' ';
        SerieAxisLabelDefChar = ' ';
        sizeX = 1;
        sizeY = 1;
        VerMaxLen = 0;
        Width = (uint)System.Console.WindowWidth;
        Height = (uint)System.Console.WindowHeight;
        BackgroundColor = System.Console.BackgroundColor;
        ForeroundColor = System.Console.ForegroundColor;
        TitleBackgroundColor = System.Console.BackgroundColor;
        TitleForeroundColor = System.Console.ForegroundColor;
        TitleDefChar = ' ';
        Series = new System.Collections.Generic.List<Serie>();
    }

    public void CalculateSizes()
    {
        ulong rows = 0;
        uint auxW = Width;
        uint auxH = Height;
        foreach(Serie s in Series)
        {
            foreach(DataPoint dp in s.DataPoints)
            {
                if(dp.Data > sizeX) 
                {
                    sizeX = (ulong)dp.Data;
                    //nota: añadir soporte a barspacing
                }
                if(dp.AxisLabel.Length > VerMaxLen)
                {
                    VerMaxLen = dp.AxisLabel.Length;
                }
                rows++;
            }
        }
        sizeY = rows;
        Width = auxW;
        Height = auxH;
    }

    private string FormatString(int size, string stringToFormat, char defaultChar)
    {
        string result;
        if(stringToFormat == null) 
        return new string(defaultChar, size);
        //if string to format length equals size then return the same string
        if(stringToFormat.Length == size) return stringToFormat;
        //if string to format length < size then add blank spaces
        if(stringToFormat.Length < size)
        {
            int leftSideLength;//+1
            int rightSideLength;
            float operation = (float)(size - stringToFormat.Length) / 2;

            leftSideLength = (int)operation;
            rightSideLength = (int)operation;
            if(operation % 1 != 0) rightSideLength++;
            result = new string(defaultChar, leftSideLength) + stringToFormat
            + new string(defaultChar, rightSideLength);
        }
        //if not trim string to format
        else
        {
            int rightSideLength = stringToFormat.Length - size;
            result = stringToFormat.Remove(
                stringToFormat.Length - rightSideLength, rightSideLength);
        }
        return result;
    }

    private string MakeCaret(int size)
    {
        //─
        if(size < 1) return null;
        if(size == 1) return ">";
        if(size == 2) return "┌└";
        return '┌' + new string('│', size-2) + '└';

    }

    private string GetVerticalSection(int position)
    {
        string result;
        
        if (VerFrameTickFreq < 1)
            result = "│";
        else
        {
            double step = (double)sizeY / Height;
            int row = (int)Height - position;
            
            double val = (int)(step * row);

            if (VerFrameTickFreq == 1 && FrameTickOrientation)
            {
                result = "├";
            }
            else if (VerFrameTickFreq == 1 && !FrameTickOrientation)
            {
                result = "┤";
            }
            else
            {
                if(position % VerFrameTickFreq == 0) 
                {
                    if(FrameTickOrientation) 
                        result = "├";
                    else result = "┤";
                }
                else 
                {
                    result = "│";
                }
            }
        }
        return result;
    }

    public System.Collections.Generic.List<string> Draw()
    {
        System.Collections.Generic.List<string> result = 
        new System.Collections.Generic.List<string>();

        for(int row = (int)Height; row >= 0; row--)
        {
            foreach(Serie s in Series)
            {
                string line = string.Empty;
                foreach(DataPoint dp in s.DataPoints)
                {
                    line += new string(DefaultEmptyChar,(int)BarSpacing);
                    if(dp.Data * _heightScale > row) 
                        line += new string(DefaultFilledChar,(int)_widthScale);
                    else line += new string(DefaultEmptyChar,(int)_widthScale);
                }
                result.Add(line);
            }
        }
        return result;
    }

    private void PrintHorizontalValues()
    {
        System.Console.Write(' ');
        for(int i = HorFrameTickFreq / 2; 
            i < Width; 
            i+= HorFrameTickFreq)
        {
            double value = (sizeX / Width) * (double)i;
            System.Console.Write(FormatString(HorFrameTickFreq,
                value.ToString(), ' '));
        }
        System.Console.WriteLine();
    }

    private void PrintMainArea()
    {
        int row = 0;
        foreach(Serie s in Series)
        {
            foreach(DataPoint dp in s.DataPoints)
            {
                //axislabel
                if (DataAxisLabelVisible)
                {
                    if(dp.AxisLabelVisible)
                    {
                        System.Console.ForegroundColor
                        = dp.UseAxisCustomColors ? 
                        dp.AxisForegroundColor : s.AxisForegroundColor;
                        System.Console.BackgroundColor
                        = dp.UseAxisCustomColors ? 
                        dp.AxisBackgroundColor : s.AxisBackgroundColor;
                        System.Console.Write(FormatString
                        (VerMaxLen,dp.AxisLabel,SerieAxisLabelDefChar));
                    }
                    else
                    {
                        System.Console.Write(FormatString
                        (VerMaxLen,null,' '));
                    }
                }
                //axiscaret
                System.Console.ResetColor();
                if(DataAxisCaretVisible) 
                {
                    System.Console.Write(MakeCaret(1));
                    /*
                    debemos añadir soporte a la anchura(altura) de las 
                    columnas
                    podemos guardar temporalmente el caret de cada serie
                    y de los puntos y mediante la variable 'row' controlar
                    cual caracter imprimir
                    */

                }
                //vertical char
                System.Console.Write(GetVerticalSection(row));

                //data
                double colWidth = dp.Data * _widthScale;
                System.Console.BackgroundColor = 
                    dp.UseDataCustomColors 
                    ? dp.DataBackgroundColor : s.DataBackgroundColor;
                System.Console.ForegroundColor =
                    dp.UseDataCustomColors 
                    ? dp.DataPrimaryColor : s.DataPrimaryColor;
                System.Console.Write(new string(DefaultFilledChar,(int)colWidth));
                System.Console.ResetColor();
                System.Console.WriteLine();
                row++;
            }
        }
    }

    private void PrintHorizontalLine()
    {
        System.Console.Write('└');
        if (HorFrameTickFreq < 1)
            System.Console.WriteLine(new string('─',(int)Width));
        else
        {
            if (HorFrameTickFreq == 1 && FrameTickOrientation)
                System.Console.WriteLine(new string('┴',(int)Width));
            else if (HorFrameTickFreq == 1 && !FrameTickOrientation)
                System.Console.WriteLine(new string('┬',(int)Width));
            else
            {
                for(int i = HorFrameTickFreq / 2; 
                i < Width + (HorFrameTickFreq / 2); 
                i++)
                {
                    if(i % HorFrameTickFreq == 0) 
                    {
                        if(FrameTickOrientation) System.Console.Write('┴');
                        else System.Console.Write('┬');
                    }
                    else System.Console.Write('─');
                }
                System.Console.WriteLine();
            }
        }
    }

    private void PrintTitle(int bonus)
    {
        System.Console.BackgroundColor = TitleBackgroundColor;
        System.Console.ForegroundColor = TitleForeroundColor;
        System.Console.Write(
            FormatString((int)Width + bonus + 1, TitleLabel, TitleDefChar)
            );
        System.Console.ResetColor();
        System.Console.WriteLine();
    }

    public void Print()
    {
        System.Console.WriteLine(Height.ToString() + " " + _heightScale.ToString() + " " + sizeY.ToString());
        int bonus = 0;

        if (DataAxisCaretVisible) bonus++;
        if (DataAxisLabelVisible) bonus+=VerMaxLen;
        /*if (SerieAxisCaretVisible) bonus++;
        if (SerieAxisLabelVisible) bonus++;*/

        string spaceForLine = new string(' ', bonus);

        if(TitleVisible) PrintTitle(bonus);
        
        PrintMainArea();

        System.Console.Write(spaceForLine);
        PrintHorizontalLine();
        if(HorFrameTickFreq > 1 && HorFrameTickFreq <= Width){
            System.Console.Write(spaceForLine);
            PrintHorizontalValues();
            }
    }
}