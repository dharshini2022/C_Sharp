using System;
using System.IO;

class Program
{
    static void Main()
    {
        string folderPath = "./Folder";
        string path1 = folderPath + "/readFile.txt";
        string path2 = folderPath + "/resultFile.txt";

        try
        {
 
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Console.WriteLine("Folder Created");
            }

            int option = 0;

            while (option != 5)
            {
                Console.WriteLine("\n --------Enter--------");
                Console.WriteLine("1 - Overwrite Text");
                Console.WriteLine("2 - Append Text");
                Console.WriteLine("3 - Read Text");
                Console.WriteLine("4 - Process & Write Result");
                Console.WriteLine("5 - Quit");

                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        using (StreamWriter writer = new StreamWriter(path1))
                        {
                            writer.WriteLine("This is line 1");
                            writer.WriteLine("This is line 2");
                        }
                        Console.WriteLine("Text overwritten");
                        break;

                    case 2:
                        File.AppendAllText(path1, "This is appended line");
                        Console.WriteLine("Text appended");
                        break;

                    case 3:
                        if (File.Exists(path1))
                        {
                            string content = File.ReadAllText(path1);
                            Console.WriteLine("\nFile Content:");
                            Console.WriteLine(content);
                        }
                        else
                        {
                            Console.WriteLine("File not found!");
                        }
                        break;

                    case 4:
                        if (File.Exists(path1))
                        {
                            string content = File.ReadAllText(path1);

                            int lineCount = content.Split('\n').Length;
                            int wordCount = content.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                            int charCount = content.Length;

                            using (StreamWriter writer = new StreamWriter(path2))
                            {
                                writer.WriteLine($"Lines: {lineCount}");
                                writer.WriteLine($"Words: {wordCount}");
                                writer.WriteLine($"Characters: {charCount}");
                            }

                            Console.WriteLine("Processed data written to new file");
                            String newContent = File.ReadAllText(path2);
                            Console.WriteLine(newContent);
                        }
                        else
                        {
                            Console.WriteLine("Source file not found!");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Quitting...");
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: File not found.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("IO Error: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }
}