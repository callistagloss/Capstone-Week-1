using System;
using System.Collections.Generic;

namespace Capstone_1
{
    public class Program

    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grand Circus Pig Latin Translator!\n");
            PromptUser();
        }

        public static Boolean Continue()
        {
            Console.WriteLine("Continue? y/n");
            string input = Console.ReadLine();
            Boolean run = false;
            input.ToLower();

            if (input == "n")
            {
                Console.WriteLine("Goodbye.");
                run = false;
            }
            else if (input == "y")
            {
                run = true;
                PromptUser();
            }
            else
            {
                Console.WriteLine("I'm sorry. I didn't understand your input. Let's try that again.");
                run = Continue();
               
            }
            return run;
        }


        public static void PromptUser()
        {
            Console.WriteLine("Please enter a word you would like to translate:");
            string input = Console.ReadLine().ToLower();

            char firstLetter = input[0];

            if (firstLetter == 'a' || firstLetter == 'e' || firstLetter == 'i' || firstLetter == 'o' || firstLetter == 'u')
            {
                VowelBuilder(input);
            }
            else if (!input.Contains("a") && !input.Contains("e") && !input.Contains("i") && !input.Contains("o") && !input.Contains("u"))
            {
                VowelBuilder(input);
            }
            else
            {
                ConsonantBuilder(input);
            }

        }

        public static void VowelBuilder(string input)
        {
            Console.WriteLine(input + "way");
            Continue();
        }

        public static void ConsonantBuilder(string input)
        {
            string word = input;
            string[] vowels = { "a", "e", "i", "o", "u" };
            List<int> foundVowels = new List<int>();

            foreach (string letter in vowels)
            {
                int index = word.IndexOf(letter);

                if (index > 0)
                {
                    foundVowels.Add(index);
                }
            }

            int firstVowel = 1000;

            foreach (int vowelPositions in foundVowels)
            {
                if (vowelPositions < firstVowel)
                {
                    firstVowel = vowelPositions;
                }
            }

            string secondHalf = word.Substring(firstVowel);
            string firstHalf = word.Substring(0, firstVowel);
            string pigString = secondHalf + firstHalf + "ay";
            Console.WriteLine(pigString);
            Continue();
        }
    }
}
