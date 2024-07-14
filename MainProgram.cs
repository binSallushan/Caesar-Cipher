using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher_2._2._3
{
    class MainProgram
    {
        static void Main(string[] args)
        {            
            string userInput;
            
            do
            {
                Console.Clear();
                Console.Write("1. Help\n2. Encode\n3. Decode\nType 'exit' to exit the program.\nType in the number of the module you want to go in: ");
                userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "1":
                        Help.Help.HelpMenu();
                        break;
                    case "2":
                        Encoding.EncodeModule();
                        break;
                    case "3":
                        Decoding.DecodeModule();
                        break;
                    case "exit":
                        break;
                    default:
                        Console.Write("Error, press any key");
                        Console.ReadKey();
                        break;
                }
            } while (userInput != "exit");
        }
    }
}
