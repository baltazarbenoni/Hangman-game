using System;
using System.Text;

class Grafiks
{
    public static void Draw(int attemptsleft, string remaining, bool solved)
    {
        string one = "_________,";
        string two = "|        |)";
        string three = "|        ||";
        string three1 = "|        ||";
        string four = "||";
        string four1 = "||";
        string five = "____||_______";
        string six = "/    ||      /|";
        string seven = "_/     ==     / |";
        string eight = "_/_/____________/  /";
        string nine = "/__| ||  ||  ||  || /";
        string ten = "|____||__||__||__||/";

        if (attemptsleft <= 5)
        {three1 = "O        ||";}

        if (attemptsleft == 4)
        {four = "|        ||";}

        if (attemptsleft == 3)
        {four = "/|        ||";}

        if (attemptsleft <= 2)
        {four = @"/|\       ||";}

        if (attemptsleft <= 1)
        {four1 = "/         ||";}

        if (attemptsleft == 0)
        {four1 = @"/ \       ||";}

        Console.WriteLine("{0, 29}", one);
        Console.WriteLine("{0,30}", two);
        Console.WriteLine("{0,30}", three);
        Console.WriteLine("{0,30}", three1);
        Console.WriteLine("{0,30}", four);
        Console.WriteLine("{0,30}", four1);
        Console.WriteLine("{0,37}", five);
        Console.WriteLine("{0,38}", six);
        Console.WriteLine("{0,38}", seven);
        Console.WriteLine("{0,38}", eight);
        Console.WriteLine("{0,37}", nine);
        Console.WriteLine("{0,36}", ten);
        Console.WriteLine();
        if (solved == false) {Console.WriteLine("{0,20}", remaining);}
        Console.WriteLine();

    }
	
    public static void OnAttend(string guess)
    {
        Console.Write("{0, 10} is . ", guess.ToUpper());
        for (int i = 0; i < 3; i++)
        {Thread.Sleep(1300);
        Console.Write(". ");}
    }

}