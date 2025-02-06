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
            Console.WriteLine("Error: program needs a filepath to run");
            loop = false;
        }

        // checker object
        Checker checker = new(args);
       
        // option menu loop, ask user for an option.
        while (loop)
        {
            Console.WriteLine("=======================");
            Console.WriteLine("Please input an option:");
            Console.WriteLine("[1] run");
            Console.WriteLine("[2] Toggle Case Sensitivity (Default on)");
            Console.WriteLine("[3] Exit Program");
            Console.WriteLine("=======================");

            Console.Write("option: ");
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
                        Console.WriteLine("toggled case sensitivity to: off");
                    }
                    else
                    {
                        caseSensitive = true;
                        Console.WriteLine("toggled case sensitivity to: on");
                    }

                    break;
                // exit program
                case "3":
                    loop = false;
                    break;

                default:
                    Console.WriteLine("invalid option");
                    break;
            }
        }
    }
}

