using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PassStrength
{
    class Program
    {
        private static Double StrongEntropy = 36.86;
        private static string GOOD = "GOOD";
        private static string STRONG = "STRONG";
        private static string WEAK = "WEAK";
        private static char[] Others = {'!', '@', '#', '$', '%', '^', '&', '*', '(', ')'};

        static void Main(string[] args)
        {
            Double Entropy = 0.0;
            int counterOfSmallLetters = 0;
            int counterOfCapitalLetters = 0;
            int counterOfSpecialChars = 0;
            int counterOfNumbers = 0;
            int counterOthers = 0;
            char userInputSingleChar=' ';

            string output = "";

            Console.WriteLine("Please enter a string to check Entropy..");
            string input = Console.ReadLine();           

            char[] userInputCharArray = input.ToCharArray();

            for (int i=0;i<input.Length;i++)
            { 
                userInputSingleChar = userInputCharArray[i];

                switch (userInputSingleChar)
                {
                    case var CharType when Char.IsUpper(userInputSingleChar):
                        counterOfCapitalLetters++;
                        break;
                    case var CharType when Char.IsLower(userInputSingleChar):
                        counterOfSmallLetters++;
                        break;
                    case var CharType when Char.IsNumber(userInputSingleChar):
                        counterOfNumbers++;
                        break;
                    case var CharType when Char.IsSymbol(userInputSingleChar):
                        counterOfSpecialChars++;
                        break;
                    case var indexOfAnyInString when input.IndexOfAny(Others)>0:
                        counterOthers++;
                        break;
                }
            }

            output = "The password you entered is " + input + "\n";
            output += "The number of chars is " + input.Length.ToString() + "\n";
            output += "There are " + counterOfSmallLetters + " small letters \n";
            output += "There are " + counterOfCapitalLetters + " capital letters \n";
            output += "There are " + counterOfNumbers + " numbers \n";
            output += "There are " + counterOfSpecialChars + " Special Chars \n";
            output += "There are " + counterOthers + " other Chars \n";
            
            Console.WriteLine(output);

            try
            {
                Entropy = Math.Log((counterOfSmallLetters>0?26:0) + (counterOfSmallLetters>0?26:0) + (counterOfSpecialChars>0?10:0) + (counterOthers > 0 ? 10 : 0) + (counterOfNumbers>0?10:0), 2) * input.Length;

                Console.WriteLine("Entropy is " + Entropy.ToString());
                switch (Entropy)
                {
                    case var decision when Entropy < StrongEntropy:
                        Console.WriteLine("string is " + WEAK);
                        break;
                    case var decision when Entropy > StrongEntropy:
                        Console.WriteLine("string is " + STRONG);
                        break;
                    case var decision when Entropy == StrongEntropy:
                        Console.WriteLine("string is " + GOOD);
                        break;
                    default:
                        Console.WriteLine("Unknown");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured " + ex.Message);
            }
        }
    }
}
