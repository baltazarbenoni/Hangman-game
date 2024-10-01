using System;
using System.Text;


class Words
{
    public static string RandomWord()
    {
        string[] animals = { "ant", "baboon", "badger", "bat", "bear", "beaver", "bee", "camel", "cat", "clam", "cobra", "cougar", "coyote", "crow", "deer", "dog", "dolphin", "donkey", "duck", "eagle", "ferret", "fox", "frog", "goat", "goose", "hawk", "horse", "leopard", "lion", "lizard", "llama", "mole", "monkey", "moose", "mouse", "mule", "otter", "owl", "panda", "parrot", "pigeon", "python", "raccoon", "rabbit", "ram", "rat", "raven", "rhino", "salmon", "seal", "shark", "sheep", "skunk", "sloth", "snake", "spider", "stork", "swan", "tiger", "turkey", "turtle", "weasel", "whale", "wolf", "wombat", "zebra" };
        int listlength = animals.Length;
        Random num = new Random();
        int randomIndex = num.Next(0, listlength - 1);
        return animals[randomIndex];
    }
}
class Guesses
{
    public static void FirstGuess(int x)
    {
        Console.WriteLine("The word has {0} letters in it. ", x);
        Console.WriteLine("Guess a character or a word!\n");
    }
    public static string GetGuess(int length)
    {
        string guess;
        bool baduk = false;
        int checkcount = 0;
        do
        {
            if (checkcount > 0) {Console.Write("Enter another guess!\n");}
            guess = Console.ReadLine() ?? "Answer not valid.";
            int guesslength = guess.Length;
            bool cond1 = String.IsNullOrWhiteSpace(guess);
            bool cond2 = guesslength != 1 & guesslength != length;
            bool cond3 = guess.Any(x => !char.IsLetter(x));
            string message1 = "Please enter the answer in the requested form.";
            string message3 = "Guess can contain only letters. Please enter the answer in the requested form.";

            if (!cond1)
            {
                if (!cond2)
                {
                    if (!cond3)
                    {baduk = true;}
                    else
                    {Console.WriteLine(message3);}
                }
                else
                {Console.WriteLine("Please enter a single character or a word that has {0} letters in it.", length);}
            }
            else
            {Console.WriteLine(message1);}

            checkcount++;
        } while (!baduk);        
        return guess;
    }
}
