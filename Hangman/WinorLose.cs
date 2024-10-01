using System;
using System.Formats.Asn1;
using System.Text;

class WinOrLose
{
    public static bool YouWon(int attemptsleft, string answer, StringBuilder remaining)
    {
        Console.Clear();
        bool solved = true;
        Grafiks.Draw(attemptsleft, remaining.ToString(), solved);
        Console.WriteLine("\tTHE CORRECT ANSWER WAS:");
        Console.Write("\t");
        for (int i = 0; i < answer.Length; i++)
        {   
            Console.Write("{0} ", Char.ToUpper(answer[i]));
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("\tYOU WON!!!! AMAZING!!!");

        
        return solved;
    }

    public static bool YouLose(int attemptsleft, string answer, StringBuilder remaining)
    {
        Console.Clear();
        bool solved = false;
        Grafiks.Draw(attemptsleft,remaining.ToString(), solved);
        Console.WriteLine("A WRONG ANSWER! YOU LOST!! THE PICTURE ABOVE REPRESENTS YOUR DEAD BODY HANGING FROM THE GALLOWS.");
        Console.WriteLine("NOT THAT IT SHOULD MATTER TO YOU (SEEING THAT YOU ARE DEAD), BUT THE CORRECT ANSWER WAS:");
        Console.WriteLine();

        for (int i = 0; i < answer.Length; i++)
        {
            char ans = answer[i];
            Console.Write("{0} ", Char.ToUpper(ans));
        }

        Console.WriteLine();

        solved = true;
        return solved;
    }
}


/*1) väärin
-> ei päivityksiä
-> vähennä jäljellä olevia yrityksiä ja printtaa
-> alkuun

--> oikea vastaus
	tarkista onko ratkaistu
		jos joo
			kerro käyttäjälle
			solved == true
	
	muuten (eli vain oikea kirjain)
		päivitä jäljellä olevat
		printtaa jäljellä olevat ja kerro että meni oikein ja näytä jäljellä
		olevat yritykset*/