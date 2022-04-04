using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanGame_Lexicon_upp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to hangman Game  you have 10 chances to guess !good luck!");
            Console.WriteLine("--------------------------------------------------------------------");

            Random random = new Random();
            //word list from which a player is to guess a word from 
            string[] SecretWord ={ "Fredrik", "Lars", "Stefan", "Anders",  "Tim",
                "Marcus", "Johan", "Jan", "Gert", "Magnus", "Tomas", "Christer",
                "Mikael", "Linus", "Torsten", "Wiktor", "Alf" };
          
        // random  secret word selected from the  array of strings
            int index = random.Next(SecretWord.Length);
            string randomnlySelectedWord = SecretWord[index];
            string result = "";
            foreach (char unreavealedletters in randomnlySelectedWord)
            {
                Console.Write("_ ");
            }
            //randomly selected word length in integer
            int lengthOfrandomnlySelectedWord = randomnlySelectedWord.Length;
            //initialize allowed number of attepts . 10 attempts allowed
            int CountofallowedAttempts = 0;



            //right guessed letters array 
            char[] RightgussedLetters = new char[11];
            //storing
            char[] RightgussedLettersstore = new char[11];
            //wrong guessed letters string builder
            StringBuilder wrongGussedLetters = new StringBuilder(11);
            // total gussed letters wrong and right so far list 
            List<char> guessedLetterssofar = new List<char>();
            //right guessed letters list 
            List<char> RightgussedLetterssofar = new List<char>();


            int currentLettersRight = 0;


            //while attempts are less than 10 and the correct word is not guessed 
            while (CountofallowedAttempts !=10 && currentLettersRight != lengthOfrandomnlySelectedWord)
            {
                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in guessedLetterssofar)
                {
                    Console.Write(letter + " ");
                }
                
                Console.Write("\n plese Guess a letter and press enter: ");
                char letterGuessedbyPlayer = Console.ReadLine()[0];
                // Check if that letter has already been guessed
                if (guessedLetterssofar.Contains(letterGuessedbyPlayer))
                {
                    Console.Write("\r\n You have already guessed this letter");

                    currentLettersRight = printLetters(guessedLetterssofar, randomnlySelectedWord);
                    printLines(randomnlySelectedWord);
                }
                //a brand new guess by player but must be check if it is in secret word
                else
                {
                    // Check if letter is in randomWord
                    bool rightguessletter  = false;
                    for (int i = 0; i < randomnlySelectedWord.Length; i++) { if (letterGuessedbyPlayer == randomnlySelectedWord[i]) { rightguessletter = true; } }

                    // the player made a correct guess 
                    if (rightguessletter)
                    {
                        //string result="";
                        // total guessed letters inserted to list 
                        guessedLetterssofar.Add(letterGuessedbyPlayer);
                       
                        currentLettersRight = printLetters(guessedLetterssofar, randomnlySelectedWord);
                        Console.Write("\r\n");
                        printLines(randomnlySelectedWord);
                        //append  right  guess character   in char array 
                        for (int i = 0; i < RightgussedLetters.Length; i++)
                        {
                            if (RightgussedLetters[i].ToString() != null)
                            {
                                i++;
                            }
                            else
                                RightgussedLetters[i] = letterGuessedbyPlayer;

                            result = result + RightgussedLetters.ToString();
                            result = new string(RightgussedLetters);
                            //Console.WriteLine("right guesses so far are :");
                            //Console.Write(result);
                        }


                    }
                    //the played made wrong guess 
                    else
                    {
                        CountofallowedAttempts += 1;
                        guessedLetterssofar.Add(letterGuessedbyPlayer);
                       

                        // Print letters
                        currentLettersRight = printLetters(guessedLetterssofar, randomnlySelectedWord);
                        Console.Write("\r\n");
                        printLines(randomnlySelectedWord);
                        //append  wrong guess character  in string builder 
                        Console.Write("\r\n");
                        Console.WriteLine( "wrong guesses so far are :" + wrongGussedLetters.Append(letterGuessedbyPlayer));

                    }
                }
                //if (CountofallowedAttempts > 10) break;
            }
           
            Console.WriteLine("\r\nGame is over! Thank you for playing :Good luck next time)");
        }
        private static void printLines(String randomWord)
        {
            Console.Write("\r");
            foreach (char c in randomWord)
            {
                Console.OutputEncoding = Encoding.Unicode;
                //putting underscore under randomly selected secret word 
                Console.Write("\u0305 ");
            }
        }

        private static int printLetters(List<char> guessedLetterssofar, string randomnlySelectedWord)
        {
            int randomlySelectedWordIterator = 0;
            int correctlyGuessedLettersByPlayer = 0;
            Console.Write("\r\n");
            //iterate through each character of randomly generated secret word
            foreach (char c in randomnlySelectedWord)
            {



              //a correct letter is guessed 
                if (guessedLetterssofar.Contains(c))
                {
                    Console.Write(c + " ");
                    correctlyGuessedLettersByPlayer += 1;
                }
                else//the letter is wrong guess
                {
                    Console.Write("  ");
                }
                randomlySelectedWordIterator += 1;
            }
       //return the right letter the player guessed 
            return correctlyGuessedLettersByPlayer;
        }

       
        
    }
}
