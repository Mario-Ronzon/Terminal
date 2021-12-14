public class BarChartVertical
{
    private const float FloatingCharValue = 0.5f;
    private ulong sizeX;
    private ulong sizeY;

    private double _heightScale;
    private double _widthScale;

    public uint BarSpacing { get; set; }
    public char DefaultEmptyChar { get; set; }
    public char DefaultFilledChar { get; set; }
    public char DefaultFloatingChar { get; set; }
    public char DataAxisLabelDefChar { get; set; }
    public char SerieAxisLabelDefChar { get; set; }

    public int FrameTickFreq { get; set; }
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
            return (uint)((_widthScale + BarSpacing) * sizeX);
        }
        set
        {
            if (value > (sizeX*(BarSpacing+1))) 
            {
                _widthScale = ((double)value / (double)sizeX) - BarSpacing;
                if (_widthScale < 1) _widthScale = 1;
            }
            else _widthScale = 1;
        }
    }

    public BarChartVertical() 
    {
        BarSpacing = 1;
        DefaultEmptyChar = ' ';
        DefaultFilledChar = '█';
        DefaultFloatingChar = '▄';
        DataAxisLabelDefChar = ' ';
        SerieAxisLabelDefChar = ' ';
        sizeX = 1;
        sizeY = 1;
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
        ulong columns = 0;
        uint auxW = Width;
        uint auxH = Height;
        foreach(Serie s in Series)
        {
            foreach(DataPoint dp in s.DataPoints)
            {
                if(dp.Data > sizeY) sizeY = (ulong)dp.Data;
                columns++;
            }
        }
        sizeX = columns;
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
        if(size == 1) return "^";
        if(size == 2) return "└┘";
        return '└' + new string('─', size-2) + '┘';

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

    private void PrintMainArea()
    {
        for(int row = 0; row < (int)Height; row++)
        {
            foreach(Serie s in Series)
            {
                foreach(DataPoint dp in s.DataPoints)
                {
                    double colHeight = (_heightScale * sizeY)
                     - (dp.Data * _heightScale);

                    System.Console.BackgroundColor = 
                        dp.UseDataCustomColors 
                        ? dp.DataBackgroundColor : s.DataBackgroundColor;
                    System.Console.ForegroundColor =
                        dp.UseDataCustomColors 
                        ? dp.DataPrimaryColor : s.DataPrimaryColor;

                    System.Console.Write(new string(DefaultEmptyChar,(int)BarSpacing));

                    if(colHeight <= row) 
                    {
                        if ((double)row - colHeight <= FloatingCharValue)
                        {
                            System.Console.ForegroundColor =
                            dp.UseDataCustomColors 
                            ? dp.DataSecondaryColor : s.DataSecondaryColor;

                            System.Console.Write(
                                new string(DefaultFloatingChar,(int)_widthScale));
                        }
                        else if ((double)row - colHeight >= FloatingCharValue
                        && (double)row - colHeight < 1)
                        {
                            System.Console.ForegroundColor =
                            dp.UseDataCustomColors 
                            ? dp.DataSecondaryColor : s.DataSecondaryColor;
                            System.Console.Write(
                                new string(DefaultFilledChar,(int)_widthScale));
                        }
                        else
                        {
                            System.Console.ForegroundColor =
                            dp.UseDataCustomColors 
                            ? dp.DataPrimaryColor : s.DataPrimaryColor;
                            System.Console.Write(
                                new string(DefaultFilledChar,(int)_widthScale));
                        }
                            
                    }
                    else
                    {
                        System.Console.Write(
                            new string(DefaultEmptyChar,(int)_widthScale));
                    }
                        
                }
            }
            System.Console.ResetColor();
            System.Console.WriteLine();
        }
    }
    private void PrintDataAxisLabels(char defaultChar)
    {
        foreach(Serie s in Series)
        {
            foreach(DataPoint dp in s.DataPoints)
            {
                System.Console.ResetColor();
                System.Console.Write(new string(' ', (int)BarSpacing));
                if(dp.AxisLabelVisible)
                {
                    System.Console.ForegroundColor
                    = dp.UseAxisCustomColors ? 
                    dp.AxisForegroundColor : s.AxisForegroundColor;
                    System.Console.BackgroundColor
                    = dp.UseAxisCustomColors ? 
                    dp.AxisBackgroundColor : s.AxisBackgroundColor;
                    System.Console.Write(FormatString
                    ((int)_widthScale,dp.AxisLabel,defaultChar));
                }
                else
                {
                    System.Console.Write(FormatString
                    ((int)_widthScale,null,' '));
                }
            }
        }
        System.Console.ResetColor();
        System.Console.WriteLine();
    }

    private void PrintDataAxisCaret()
    {
        foreach(Serie s in Series)
        {
            foreach(DataPoint dp in s.DataPoints)
            {
                if(dp.AxisLabelVisible)
                    System.Console.Write(new string(' ', (int)BarSpacing) +
                    MakeCaret((int)_widthScale));
                else System.Console.Write(new string(' ',(int)_widthScale+(int)BarSpacing));
            }
        }
        System.Console.WriteLine();
    }

    private void PrintSeriesAxisLabels(char defaultChar)
    {
        foreach(Serie s in Series)
        {
            if(s.AxisLabelVisible)
            {
                System.Console.Write(new string(' ', (int)BarSpacing));
                System.Console.ForegroundColor
                    = s.AxisForegroundColor;
                    System.Console.BackgroundColor
                    = s.AxisBackgroundColor;
                    System.Console.Write(
                        FormatString(
                            (int)(_widthScale + (int)BarSpacing) * s.DataPoints.Count -
                            (int)BarSpacing,s.AxisLabel,
                            defaultChar
                            )
                        );
            }
            else
            {
                System.Console.Write(FormatString
                    ((int)(_widthScale + (int)BarSpacing) * s.DataPoints.Count,null,' '));
            }
            System.Console.ResetColor();
        }
        System.Console.ResetColor();
        System.Console.WriteLine();
    }

    private void PrintSeriesAxisCaret()
    {
        foreach(Serie s in Series)
        {
            if(s.AxisLabelVisible)
                System.Console.Write(new string(' ', (int)BarSpacing) +
                    MakeCaret((int)(_widthScale + (int)BarSpacing) *
                    s.DataPoints.Count-(int)BarSpacing));
            else System.Console.Write(
                new string(' ',(int)(_widthScale + (int)BarSpacing) *
                 s.DataPoints.Count));
        }
        System.Console.WriteLine();
    }

    private void PrintHorizontalLine()
    {
        if (FrameTickFreq < 1)
            System.Console.WriteLine(new string('─',(int)Width));
        else
        {
            if (FrameTickFreq == 1 && FrameTickOrientation)
                System.Console.WriteLine(new string('┴',(int)Width));
            else if (FrameTickFreq == 1 && !FrameTickOrientation)
                System.Console.WriteLine(new string('┬',(int)Width));
            else
            {
                for(int i = FrameTickFreq / 2; i < Width + (FrameTickFreq / 2); i++)
                {
                    if(i % FrameTickFreq == 0) 
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

    private void PrintTitle()
    {
        System.Console.BackgroundColor = TitleBackgroundColor;
        System.Console.ForegroundColor = TitleForeroundColor;
        System.Console.Write(
            FormatString((int)Width, TitleLabel, TitleDefChar)
            );
        System.Console.ResetColor();
        System.Console.WriteLine();
    }

    public void Print()
    {
        //print title label
        if(TitleVisible) PrintTitle();
        //print columns and y axis
        PrintMainArea();
        //print x axis line
        PrintHorizontalLine();
        //print datapoint axis caret
        if(DataAxisCaretVisible) PrintDataAxisCaret();
        //print datapoint axis label
        if(DataAxisLabelVisible) PrintDataAxisLabels(DataAxisLabelDefChar);
        //print series axis caret
        if(SerieAxisCaretVisible) PrintSeriesAxisCaret();
        //print series axis label
        if(SerieAxisLabelVisible) PrintSeriesAxisLabels(SerieAxisLabelDefChar);
    }
}