using System;
using System.Text;

class Progress
{
    public static StringBuilder OriginalBlanks(int x, StringBuilder remaining)
    {
        int i;

        for (i = 1; i < x; i++)
        {
            remaining.Append(new char[] {'_', ' '});
        }
        return remaining;
    }
    public static bool EvaluateGuess(string guess, string answer, int guesslength)
    {
	bool rightans;

	if (guesslength == 1)
	{
		char guesschar = Convert.ToChar(guess);
		rightans = answer.Contains(guesschar);
	}
	else
	{
		rightans = guess.Equals(answer);
	}
	
	return rightans;
    }
    public static StringBuilder UpdateRemaining (StringBuilder remaining, string guess, string answer, int attemptsleft)
    {
        int i;
        for (i = 0; i < answer.Length; i++)
        {
            if (answer[i] == Convert.ToChar(guess))
            {
                remaining[i * 2] = Convert.ToChar(guess.ToUpper());
                Console.Clear();
                Grafiks.Draw(attemptsleft, remaining.ToString(), false);
                Console.WriteLine("CORRECT! ");
            }
        }
        
        string spacelessrem = EraseSpaces(remaining).ToLower();

        if (spacelessrem.Equals(answer) || guess.Equals(answer))
        {WinOrLose.YouWon(attemptsleft, answer, remaining);}
        
        else
        {
            int blankscount = BlankCounter(spacelessrem);
            if (blankscount > 0)
            {
                string letterz = (blankscount == 1) ? "letter" : "letters";
                Console.Write("{0} {1} remaining oh shieet...", blankscount, letterz);
                Console.WriteLine("\nEnter another guess...");
            }
        }
        return remaining;
    }
    public static string EraseSpaces(StringBuilder remaining)
    {
        string s = remaining.ToString();
        return new string(s.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
    }
    public static int BlankCounter(string spacelessrem)
    {
        int blanks = 0;
        for (int j = 0; j < spacelessrem.Length; j++)
        {
            if (spacelessrem[j] == '_') {blanks++;}
        }
        return blanks;
    }
     public static int WrongAnswer(int attemptsleft, StringBuilder remaining)
    {
        attemptsleft--;
        if (attemptsleft == 0)
        {
            return attemptsleft;
        }
        else
        {
            Console.Clear();
            Grafiks.Draw(attemptsleft, remaining.ToString(), false);
            Console.WriteLine("A WRONG ANSWER! THE PLOT THICKENS...");

            string beginning = "FROM HERE ON, WE SHALL HAVE MERCY ON YOU NO MORE";

            if (attemptsleft == 5) {Console.WriteLine("{0} THAN FOUR TIMES.", beginning);}
            if (attemptsleft == 4) {Console.WriteLine("{0} THAN THREE TIMES.", beginning);}
            if (attemptsleft == 3) {Console.WriteLine("{0} THAN TWO TIMES.", beginning);}
            if (attemptsleft == 2) {Console.WriteLine("{0} THAN ONE TIME.", beginning);}       
            if (attemptsleft == 1) {Console.WriteLine("{0}.", beginning);}     
            
            Console.WriteLine();
            Console.WriteLine("Enter another guess...\n");
            return attemptsleft;
        }
    }
}
