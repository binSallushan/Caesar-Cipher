using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher_2._2._3.Help
{
    class Help
    {
        public static void HelpMenu()
        {
            string userInputHelp;
            do
            {               
                Console.Clear();
                Console.Write("Help Menu:\n1. About\n2. Encode\n3. Decode\n4. Shifts\nType 'back' to exit help.\nType in the number of the help section you want to go in: ");
                           
                userInputHelp = Console.ReadLine().ToLower();
                switch (userInputHelp)
                {
                    case "1":
                        HelpAbout();
                        break;
                    case "2":
                        HelpEncode();
                        break;
                    case "3":
                        HelpDecode();
                        break;
                    case "4":
                        HelpShifts();
                        break;
                    case "back":
                        break;
                    default:
                        Console.Write("Error, press any key");
                        Console.ReadKey();
                        break;
                }
            } while (userInputHelp != "back");
        }
        static void HelpAbout()
        {            
            Console.Clear();
            Console.WriteLine("About: \nThis is Caesar Cipher 2.2.2 . With this program, you can encode or decode any given input. Go here for detailed information: https://en.wikipedia.org/wiki/Caesar_cipher");
            Console.WriteLine("In this version you can also save that input on your computer with another layer of encoding to the output. This will provide an extra security.");
            Console.WriteLine("\n\nPros and Cons.");
            Console.WriteLine("\nPros: \nSend anyone your encoded version of input without the worry of it being read by anyone else.");
            Console.WriteLine("Save the output on your computer with another layer of encoding, making it even more secure.");
            Console.WriteLine("Your choice of shifting letters");
            Console.WriteLine("\nCons: \nDoes not come with GUI so it's a bit ugly.");            

            Console.WriteLine("\nPress any key to go back to Help Menu.....");
            Console.ReadKey();            
        }
        static void HelpEncode()
        {            
            Console.Clear();
            Console.WriteLine("Encoding:\nEncode your word or sentence or even paragraph by using this module.");
            Console.WriteLine("\n\nHow:\nFirstly select the number of times you want to shift your letters.\nThen put in your word or sentence and voila! you got your encoded stuff.");
            Console.WriteLine("\nSaving the output as a file:\nCaesar Cipher will ask you if you wish to save the output as a file. In order to save it as a file, press 'y' when prompted and then just give the full path to where you want to save it,");
            Console.WriteLine("Or just simply put whatever you wish to name the file and it will save it where you have saved your program.");
            Console.WriteLine("\n------------------\nExamples:\n Shifts: 1\n Input: Abc\n Output: Zab\n\n Shifts: 5\n Input: Asia\n Output: Vndv");
            Console.WriteLine("\n(Note: You can only shift your letters upto 25)");

            Console.WriteLine("\nPress any key to go back to Help Menu.....");
            Console.ReadKey();            
        }
        static void HelpDecode()
        {            
            Console.Clear();
            Console.WriteLine("Decoding:\nDecode your word or sentence or even paragraph by using this module.");
            Console.WriteLine("\n\nHow:\nFirstly select the number of times you want to shift your letters. (Please make sure you put this same as it was encoded)");
            Console.WriteLine("Then Put in your word or sentecnce and you have just decoded the secret message.");
            Console.WriteLine("\nDecode using a file:\nIn order to decode from a file, enter the full path to the encoded file.");
            Console.WriteLine("If the encoded file is in the same folder, just enter the name of the file and it will decode for you");
            Console.WriteLine("\n(Note: If you do not put in the same shifts as there were when it was encoded, you will not get the correct decoded version.");

            Console.WriteLine("\nPress any key to go back to Help Menu.....");
            Console.ReadKey();            
        }
        static void HelpShifts()
        {
            Console.Clear();
            Console.WriteLine("Shifts:\nDuring Encryption or Decryption, shifts determine how many times.");
            Console.WriteLine("you want to shift your letters in a sentence or a word.");
            Console.WriteLine("\nIn encryption, letters shift backwards.");
            Console.WriteLine("Example: \nShifts: 1\nA -> Z");
            Console.WriteLine("Example: \nShifts: 3\nB -> Y");
            Console.WriteLine("\nIn decryption, letters shift forwards.");
            Console.WriteLine("Example: \nShifts: 1\nA -> B");
            Console.WriteLine("Example: \nShifts: 3\nB -> E");
            Console.WriteLine("\n(Note: You can only shift your letters upto 25)");

            Console.WriteLine("\nPress any key to go back to Help Menu.....");
            Console.ReadKey();            
        }
    }
}