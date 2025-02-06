namespace CharacterChecker;

public class Program
{
    static bool loop = true;
    static bool caseSensitive = true;

    static void Main(string[] args)
    {
        // Checks if there is a commandline argument.
        if (args.Length == 0)
        {
            Console.WriteLine("Error: Program Needs a Filepath To Run");
            loop = false;
        }

        // checker object
        Checker checker = new(args);
       
        // option menu loop, ask user for an option.
        while (loop)
        {
            Console.WriteLine("=======================");
            Console.WriteLine("Please input an option:");
            Console.WriteLine("[1] Run");
            Console.WriteLine("[2] Toggle Case Sensitivity (Default on)");
            Console.WriteLine("[3] Exit Program");
            Console.WriteLine("=======================");

            Console.Write("Option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                // runs the character checker
                case "1":
                    checker.CountCharacters(caseSensitive);
                    checker.DisplayCharCounts();
                    break;

                // toggles case sensitivity 
                case "2":
                    if (caseSensitive == true)
                    {
                        caseSensitive = false;
                        Console.WriteLine("Toggled Case Densitivity Do: Off");
                    }
                    else
                    {
                        caseSensitive = true;
                        Console.WriteLine("Toggled Case Sensitivity To: On");
                    }

                    break;
                // exit program
                case "3":
                    loop = false;
                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }
    }
}

