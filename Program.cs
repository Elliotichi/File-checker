namespace CharacterChecker;

public class Program
{
    static void Main(string[] args)
    {
        Checker checker = new("C:/Users/Elliot/Documents/C# Projects/SWORD_Character_Checker/CharacterChecker/Test.txt");
        bool loop = true;
        bool caseSensitive = true;
        while (loop)
        {
            Console.WriteLine("=======================");
            Console.WriteLine("Please input an option:");
            Console.WriteLine("[1] run");
            Console.WriteLine("[2] Toggle Case Sensitivity (Defualt on)");
            Console.WriteLine("[3] Exit Program");
            Console.WriteLine("=======================");
            Console.Write("option: ");
            string option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    checker.CountCharacters(caseSensitive);
                    checker.DisplayCharCounts();
                    break;

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

                case "3":
                    loop = false;
                    break;

                default :
                    Console.WriteLine("invalid option");
                    break;
            }

        }
    }
}

