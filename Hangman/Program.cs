using System;
using System.Text;

class Class1
{
    static void Main()
    {
       RunGame();
       int attemptsleft = 6;
       List<string> tried = new List<string>();
       string answer = Words.RandomWord();
       int anslength = answer.Length;
       StringBuilder remaining = new StringBuilder("_ ", anslength);
       remaining = Progress.OriginalBlanks(anslength, remaining);
       bool notsolved = false;

       Console.Clear();
       Grafiks.Draw(attemptsleft, remaining.ToString(), notsolved);
       Guesses.FirstGuess(anslength);

       GamePlay(anslength, remaining, answer, attemptsleft, tried);

       PlayAgain();
    }

    static void RunGame()
    {
        Console.WriteLine("Welcome to play the HANGMAN-game.");
        Console.WriteLine("In this game the keywords are animal names.");
        Console.WriteLine("You can guess wrong five times before we'll lynch you! :-)");
        Console.WriteLine("Press any key to start the game!");
        Console.ReadKey(true);
    }
    static void PlayAgain()
    {
        Console.WriteLine("\nIf you wish to play again, press ENTER.");
        if (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            Console.Clear();
            Main();
        }
    }
    public static string EraseSpaces(StringBuilder remaining)
    {
        string s = remaining.ToString();
        return new string(s.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
    }
    static void GamePlay(int anslength, StringBuilder remaining, string answer, int attemptsleft, List<string> tried)
    {
        try
       {
        bool solved;
        do
        {
            solved = false;
            string guess = Guesses.GetGuess(anslength).ToLower();
            
            if (tried.Contains(guess))
                {Console.WriteLine("\nYou have already guessed this letter!");
                continue;}
            else
                {tried.Add(new string(guess));}

            Console.Clear();
            Grafiks.Draw(attemptsleft, remaining.ToString(), solved);
            Grafiks.OnAttend(guess);
            int guesslength = guess.Length;
            bool rightans = Progress.EvaluateGuess(guess, answer, guesslength);
            
            string spacelessrem = EraseSpaces(remaining).ToLower();
            
            if (rightans)
	        {
		        if (guess.Length == 1)
                {Progress.UpdateRemaining(remaining, guess, answer,attemptsleft);
                
                    if (spacelessrem.Equals(answer) || guess.Equals(answer))
                    {WinOrLose.YouWon(attemptsleft, answer, remaining);
                    solved = true;}}

                
                else {solved = WinOrLose.YouWon(attemptsleft, answer, remaining);}
	        }
	        else
            {
                Console.WriteLine(remaining);
                attemptsleft = Progress.WrongAnswer(attemptsleft, remaining);
                if (attemptsleft == 0) {solved = WinOrLose.YouLose(attemptsleft, answer, remaining);}
            }

        } while (!solved);
       } 
       catch (Exception e)
       {
        Console.WriteLine("Error: " + e.Message);
       }
    }
}