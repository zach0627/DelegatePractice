
class Program
{
    public delegate void MyDelegate(string message);
    static void Main(string[] args)
    {
        MyDelegate myDelegate = new MyDelegate(PrintMessage);
        myDelegate += WriteMessage;
        Action<string> actionString = message => Console.WriteLine($"Hello from Action {message}");
        myDelegate += new MyDelegate(actionString);
        myDelegate += message => Console.WriteLine($"Hello from Lambda {message}");

        while (true)
        {
            string msg = Console.ReadLine();
            myDelegate.Invoke(msg);
        }
    }

    static void WriteMessage(string message)
    {
        Console.WriteLine($"Hello~{message}");
    }

    static void PrintMessage(string message)
    {
        Console.WriteLine($"Print~~{message}");
    }

}

