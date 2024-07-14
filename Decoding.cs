using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher_2._2._3
{
    class Decoding
    {
        static int InputShifts()
        {
            int shifts = 0;
            bool error;
            do
            {
                error = false;
                try
                {
                    Console.Write("Shifts: ");
                    var num = Console.ReadLine();

                    shifts = Convert.ToInt32(num);
                    if (shifts > 25)
                        throw new Exception("Number must be less than or equal to 25");
                }
                catch (Exception e)
                {
                    error = true;
                    Console.WriteLine($"Error: {e.Message}");
                }
            } while (error);
            return (shifts);
        }
        public static string DecryptSentence(string forDecryption, int shifts)
        {
            string decodedOutput = string.Empty;

            foreach(char ch in forDecryption)
            {
                string str = char.ToString(ch);
                var ascii = char.ConvertToUtf32(str, 0);
                var decodedAscii = ModifyingOutOfRangeAndNonLettersOrNot(ascii, shifts);

                decodedOutput = decodedOutput + char.ConvertFromUtf32(decodedAscii);
            }

            return decodedOutput;
        }
        public static void DecodeModule()
        {
            Console.Clear();
            if (!WritingReadingFiles.UserInputDecryptingFile())
            {
                Console.Clear();
                var userInputShifts = InputShifts();
                Console.Write("Enter: ");
                var toDecrypt = Console.ReadLine();
                var decrypted = DecryptSentence(toDecrypt, userInputShifts);
                Console.WriteLine($"\nDecoded: {decrypted}");
                Console.Write("Press any key to continue...");
                Console.ReadLine();
            }
        }
        static int ModifyingOutOfRangeAndNonLettersOrNot(int ascii, int numOfShift)
        {
            int decoded;
            var checkNonLetter = NonLetter(ascii);

            if (checkNonLetter)
            {
                decoded = ascii;
            }
            else
            {
                decoded = ascii + numOfShift;
                var checkOutOfRange = OutOfRange(ascii, decoded);
                if (checkOutOfRange)
                {
                    decoded = decoded - 90;
                    decoded = 64 + decoded;
                }

            }

            bool OutOfRange(int originalAscii, int decodedAscii)
            {
                bool specialCase = false;
                if (decodedAscii > 90 && (originalAscii <= 90 && originalAscii >= 65) || decodedAscii > 122 && (originalAscii <= 122 && originalAscii >= 97))
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

            return decoded;
        }
    }
}
