/*
-------------------
control
    events
        enter
        leave
        action(by key)
    properties
        size
            width
            height
        position
            x
            y
        enabled
        visible
-------------------
controls
    label
    radio
    check
    button
    input
    track/progress
-------------------
field
    content:string
    backcolor:byte
    forecolor:byte
-------------------
label:control
    text:field
-------------------
radio:control
    radiochar:field
    text:field
    checked:bool
-------------------
check:control
    checkchar:field
    text:field
    checked:bool
-------------------
input:control
    text:field
    placeholder:field
    leftchar:field
    rightchar:field
-------------------
button:control
    text:field
    leftchar:field
    rightchar:field

-------------------
progress:control
    fillchar:field
    emptychar:field
    caretchar:field
    value:double
    min:double
    max:double
    step:double
*/
//Aa - ﱣ雷 ﱤ⭘ 﫜 
//text text text text text
//
//
//

//---     ⏽⏽⏽ 勞勞
//
// 卑喝
//.........................................................
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("This is a label");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Red;
Console.Write("");
Console.ResetColor();
Console.Write(" radio    ");
Console.ForegroundColor = ConsoleColor.Red;
Console.Write("");
Console.ResetColor();
Console.WriteLine(" radio");

Console.ForegroundColor = ConsoleColor.Blue;
Console.Write("");
Console.ResetColor();
Console.Write(" check    ");
Console.ForegroundColor = ConsoleColor.Blue;
Console.Write("");
Console.ResetColor();
Console.WriteLine(" check");
//.........................................................
Console.Write("⏽");
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.Write("placeholder ");
Console.ResetColor();
Console.Write("⏽    ");
Console.Write("⏽");
Console.ForegroundColor = ConsoleColor.White;
Console.Write("text        ");
Console.ResetColor();
Console.WriteLine("⏽");
//.........................................................
Console.ForegroundColor = ConsoleColor.Blue;
Console.Write("");
Console.BackgroundColor = ConsoleColor.Blue;
Console.ForegroundColor = ConsoleColor.White;
Console.Write(" button ");
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("");
//.........................................................
Console.ForegroundColor = ConsoleColor.Blue;
Console.Write("");
Console.ForegroundColor = ConsoleColor.White;
Console.Write("");
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.Write("");
Console.ResetColor();
Console.Write("    ");

Console.ForegroundColor = ConsoleColor.Blue;
Console.Write("");
Console.ForegroundColor = ConsoleColor.White;
Console.Write("");
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.Write("");
Console.ResetColor();
Console.WriteLine("");
//.........................................................