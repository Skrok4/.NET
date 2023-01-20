class Program
{
    // Field to store the initial text from the file
    private static string _loremIpsumText;

    static void Main(string[] args)
    {
        Console.WriteLine("..: LAB #1 :..");
        bool exit = false;
        while (!exit)
        {
            // Display the selection menu
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Display number of words from 'Lorem Ipsum' text");
            Console.WriteLine("2. Perform mathematical operation");
            Console.WriteLine("3. Exit");

            // Handle user input
            int selection = int.Parse(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    DisplayNumberOfWords();
                    break;
                case 2:
                    PerformMathematicalOperation();
                    break;
                case 3:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    Main(args);
                    break;
            }
        }
    }

    // Method to display the number of words specified by the user in the "Lorem ipsum" text
    private static void DisplayNumberOfWords()
    {
        Console.WriteLine("Enter the number of words you want to display:");
        int numberOfWords = int.Parse(Console.ReadLine());

        string path = @"E:\loremIpsum.txt";
        _loremIpsumText = File.ReadAllText(path);

        string[] words = _loremIpsumText.Split(' ');
        for (int i = 0; i < numberOfWords; i++)
        {
            Console.Write(words[i] + " ");
        }
        Console.WriteLine('\n');
    }

    private static void PerformMathematicalOperation()
    {
        Console.WriteLine("Select an operation:");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("4. Division");

        int operation = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter first number:");
        double firstNum = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        double secondNum = double.Parse(Console.ReadLine());
        double result = 0;
        switch (operation)
        {
            case 1:
                result = firstNum + secondNum;
                break;
            case 2:
                result = firstNum - secondNum;
                break;
            case 3:
                result = firstNum * secondNum;
                break;
            case 4:
                result = firstNum / secondNum;
                break;
            default:
                Console.WriteLine("Invalid operation. Please try again.");
                PerformMathematicalOperation();
                break;
        }
        Console.WriteLine("Result: " + result);
    }
}