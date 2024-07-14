using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Caesar_Cipher_2._2._3
{
    class WritingReadingFiles
    {
        public static void YesOrNoEncryptingASavedFile()
        {
            bool error;
            do
            {
                try
                {
                    error = false;
                    Console.Write("Please enter the name or full path of the file: ");
                    var filePath = Console.ReadLine();
                    var toRead = File.ReadAllText(filePath);
                    Console.Clear();

                    Console.WriteLine($"Text in file: \n{toRead}");
                    var shifts = Encoding.InputShifts();

                    var encryptedSentence = Encoding.EncodeSentence(shifts, toRead);
                    Console.WriteLine($"\nEncrypted:\n{encryptedSentence}\nPress any key to continue...");
                    Console.ReadKey();
                    
                    YesOrNoSavingEncryptedOutput(shifts, encryptedSentence);
                }
                catch (Exception ex)
                {
                    error = true;
                    Console.Write($"Error: {ex.Message}\nPress any key to continue...");
                    Console.ReadKey();
                }
            } while (error);
        }
        public static void YesOrNoSavingEncryptedOutput(int shifts, string sentence)
        {            
            bool error = false;
            do
            {
                try
                {
                    Console.Write("\nDo you want to save this encoded string? y/n: ");
                    var userInputFile = Console.ReadLine().ToLower();
                    if (userInputFile == "y")
                    {
                        string shiftsAsString = Convert.ToString(shifts);
                        SaveEncryptedOutput(sentence, shiftsAsString, shifts);
                    }
                     else if (userInputFile == "n")
                    {                        
                        break;
                    }                        
                    else if (userInputFile != "y" || userInputFile != "n")
                        throw new Exception("Please input y or n.");
                    else if (userInputFile == null)
                        throw new Exception("Please input y or n.");
                }
                catch (Exception e)
                {
                    error = true;
                    Console.WriteLine($"Error: {e.Message}");
                }
            } while (error);
        }
        static void SaveEncryptedOutput(string output, string shiftsAsString, int shifts)
        {
            string fileName;            
            string shiftsToWrite = string.Empty;
            string dataToWrite = string.Empty;
            var wordShiftEncoded = Encoding.EncodeSentence(shifts,"shifts: ");
                        
            /*foreach*/
            { 
                foreach (char ch in wordShiftEncoded)
                {
                    string str = char.ToString(ch);
                    var ascii = char.ConvertToUtf32(str, 0);
                    var weirdAscii = (int)Math.Pow(ascii, 2);

                    shiftsToWrite = shiftsToWrite + char.ConvertFromUtf32(weirdAscii);
                }
                
                foreach (char ch in shiftsAsString)
                {
                    string str = char.ToString(ch);
                    var ascii = char.ConvertToUtf32(str, 0);
                    var weirdAscii = (int)Math.Pow(ascii, 2);

                    shiftsToWrite = shiftsToWrite + char.ConvertFromUtf32(weirdAscii);
                }
                Console.WriteLine(shiftsToWrite);
                foreach (char ch in output)
                {
                    string str = char.ToString(ch);
                    var ascii = char.ConvertToUtf32(str, 0);
                    var weirdAscii = (int)Math.Pow(ascii, 2);

                    dataToWrite = dataToWrite + char.ConvertFromUtf32(weirdAscii);
                }
            }
            Console.Clear();
            Console.WriteLine($"Encoded: \n{output}");

            bool error = true;
            do
            {
                Console.Write("\nType in the name of the file, or type in the full path to the file: ");
                fileName = Console.ReadLine();

                try
                {
                    error = false;
                    File.WriteAllText(fileName, $"{shiftsToWrite}\n{dataToWrite}");
                    Console.WriteLine($"File saved as '{fileName}'");                    
                }
                catch (Exception e)
                {
                    error = true;
                    Console.WriteLine($"Error: {e.Message}");                    
                }
            } while (error);
        }
        public static bool UserInputDecryptingFile()
        {
            bool error = false;
            bool decryptFromFile = false;
            do
            {
                Console.Clear();
                error = false;
                decryptFromFile = false;
                Console.Write("Do you want to decode from a file? y/n ");

                var userInput = Console.ReadLine().ToLower();                

                switch (userInput)
                {
                    case "y":
                        DecodeFromFile();
                        decryptFromFile = true;
                        break;
                    case "n":
                        break;
                    default:
                        error = true;
                        Console.Write("Error, Press any key to continue....");
                        Console.ReadKey();
                        break;
                }                
            }while (error);
            return decryptFromFile;
        }
        static void DecodeFromFile()
        {
            StreamReader dataToReadInFile = StreamReader.Null;            
            bool error = false;
            string finalDecrypted;
            string fileName;
            string encryptedSenteceInFile;
            string normalShiftNumberAsString = string.Empty;
            int normalShiftNumberAsInt = default;
            string normalToBeDecryptData = string.Empty;
            int lineNumber = 0;

            do
            {                
                try
                {
                    Console.Write("Type in the name of the file or full path to file: ");
                    fileName = Console.ReadLine();
                    error = false;
                    using (dataToReadInFile = new StreamReader(fileName))
                    {
                        while ((encryptedSenteceInFile = dataToReadInFile.ReadLine()) != null)
                        {
                            var sentenceLength = encryptedSenteceInFile.Length;
                            lineNumber++;

                            if (lineNumber == 1)
                            {
                                for (var i = 8; i < sentenceLength; i++)
                                {
                                    var encryptedNumberAscii = char.ConvertToUtf32(encryptedSenteceInFile, i);
                                    var decryptingAscii = (int)Math.Sqrt(encryptedNumberAscii);

                                    normalShiftNumberAsString = normalShiftNumberAsString + char.ConvertFromUtf32(decryptingAscii);
                                }
                                normalShiftNumberAsInt = Convert.ToInt32(normalShiftNumberAsString);
                            }
                            else
                            {
                                foreach (char ch in encryptedSenteceInFile)
                                {
                                    string str = char.ToString(ch);
                                    var encryptedLetterAscii = char.ConvertToUtf32(str, 0);
                                    var decryptingAscii = (int)Math.Sqrt(encryptedLetterAscii);

                                    normalToBeDecryptData = normalToBeDecryptData + char.ConvertFromUtf32(decryptingAscii);
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    error = true;
                    Console.WriteLine($"Error: {e.Message}");                    
                }
            } while (error);

            finalDecrypted = Decoding.DecryptSentence(normalToBeDecryptData, normalShiftNumberAsInt);
            Console.Clear();            
            Console.WriteLine($"Shifts: {normalShiftNumberAsInt}");
            Console.WriteLine($"\nEncrypted: \n{normalToBeDecryptData}");
            Console.WriteLine($"\nDecrypted: \n{finalDecrypted}");
            SaveDecryptedOutput(finalDecrypted);
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
        static void SaveDecryptedOutput(string output)
        {
            bool error = false;
            do
            {
                
                Console.Write("\nDo you want to save this decrypted output in a file?(y/n) ");
                var userInput = Console.ReadLine().ToLower();
                string filePath;

                switch (userInput)
                {
                    case "y":
                        error = false;
                        Console.Write("Please enter the name of the file you want to save it as: ");
                        filePath = Console.ReadLine();
                        File.WriteAllText(filePath, output);
                        break;
                    case "n":
                        error = false;
                        break;
                    default:
                        error = true;
                        Console.Write("Error, try again");
                        Console.ReadKey();                        
                        break;
                }
            }while (error);
        }
    }
}
