using System.Text.RegularExpressions;

namespace CharacterChecker;

public class Checker
{
    // Filepath to be read.
    string filepath;

    // Charcters to be read
    Dictionary<char, int> characters = new();

    // Constructer
    public Checker(string path)
    {
        filepath = path;
    }

    // Stores all text from a given file into a string and returns it.
    public string ReadFile()
    {
        string file = "";
        try
        {
            // reads given file
            StreamReader sr = new(filepath);

            // Gets first line of string in text file.
            string line = sr.ReadLine();

            // Loops until the entire file is read.
            while (line != null)
            {
                // Appends the file to a string.
                file += line;
                line = sr.ReadLine();
            }
        }

        catch (Exception e)
        {
            Console.WriteLine("error occured: " + e.Message);
        }

        // Filters out whitespace from the string.
        file = Regex.Replace(file, @"\s+", "");
        return file;
    }

    // Tallies up the characters by storing them in a dictionary.
    public void CountCharacters(bool caseSensitive)
    {
        characters.Clear();
        
        string file = ReadFile();

        // checks if case sensitive is turned off.
        if(caseSensitive == false)
        {
            // converts all characters to uppercase.
            file = file.ToUpper();
        }

        // Iterates through the Stirng and adds the charcters to the dict.
        foreach (char c in file)
        {
            
            // Checks if the charcter already exists in the dict.
            // If so increment
            if (characters.ContainsKey(c))
            {
                characters[c]++;
            }

            // If not assign value of 1
            else
            {
                characters[c] = 1;
            }
        }
    }

    private int GetTotalChars()
    {
        int TotalChars = 0;

        // Iterates through the dictionary and adds the values together
        foreach (KeyValuePair<char, int> kvp in characters)
        {
            TotalChars += kvp.Value;
        }

        return TotalChars;
    }



    // Writes each charcter to the console.
    public void DisplayCharCounts()
    {
        Console.WriteLine("Total Chars in file: " + GetTotalChars());
        // Sorts the dictionary by the value.
        var sortedCharacters = characters.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        // Used to ensure that no more than 10 entries get written to console.
        int i = 10;
        foreach (KeyValuePair<char, int> kvp in sortedCharacters.Reverse())
        {
            i--;
            if (i > 0)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value);
            }
        }
    }



}
