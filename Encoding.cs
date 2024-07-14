using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher_2._2._3
{
    class Encoding
    {
        public static int InputShifts()
        {
            int shifts = 0;
            bool error;
            do
            {
                error = false;
                try
                {
                    Console.Write("\nEnter shifts: ");
                    var num = Console.ReadLine();

                    shifts = Convert.ToInt32(num);
                    if (shifts > 25)
                        throw new Exception("Number must be less than or equal to 25");
                }
                catch(Exception e)
                {
                    error = true;
                    Console.WriteLine($"Error: {e.Message}");
                }
            } while (error);
            return (shifts);
        }
        public static string EncodeSentence(int numOfShifts, string input)
        {
            
            string encodedOutput = string.Empty;

            foreach (char ch in input)
            {
                string str = char.ToString(ch);
                var ascii = char.ConvertToUtf32(str, 0);
                var encodedAscii = ModifyingOutOfRangeAndNonLettersOrNot(ascii, numOfShifts);
                encodedOutput = encodedOutput + char.ConvertFromUtf32(encodedAscii);
            }

            return (encodedOutput);
        }
        public static void EncodeModule()
        {
            Console.Clear();
            Console.Write("Do you want to encode a file? y/n ");
            if (Console.ReadLine().ToLower() == "y")
            {
                WritingReadingFiles.YesOrNoEncryptingASavedFile();
            }
            else
            {
                Console.Clear();
                var shifts = InputShifts();

                Console.Write("Enter: ");
                var input = Console.ReadLine();
                var sentence = EncodeSentence(shifts, input);

                Console.WriteLine($"Encoded: {sentence}");

                WritingReadingFiles.YesOrNoSavingEncryptedOutput(shifts, sentence);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static int ModifyingOutOfRangeAndNonLettersOrNot(int realAscii, int shifts)
        {
            int encoded;            
            var checkNonLetter = NonLetter(realAscii);
            
            if (checkNonLetter)
            {
                encoded = realAscii;
            }
            else 
            {
                encoded = realAscii - shifts;
                var checkOutOfRange = OutOfRange(realAscii, encoded);
                if (checkOutOfRange)
                {
                    encoded = 64 - encoded;
                    encoded = 90 - encoded;
                }
                
            }
                        
            bool OutOfRange(int originalAscii, int encodedAscii)
            {
                bool specialCase = false;
                if (encodedAscii < 65 && (originalAscii <= 90 && originalAscii >= 65) || encodedAscii < 97 && (originalAscii <= 122 && originalAscii >= 97))
                    specialCase = true;
                return (specialCase);
            }

            bool NonLetter(int originalAscii)
            {
                bool specialCase = false;
                if (!((originalAscii <= 90 && originalAscii >= 65) || (originalAscii <= 122 && originalAscii >= 97)))
                    specialCase = true;
                return (specialCase);
            }

            return (encoded);
        }               
    }
}
