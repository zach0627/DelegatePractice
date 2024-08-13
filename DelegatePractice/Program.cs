
using System.Text;

class Program
{
    public delegate void MyDelegate(string message);
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        MyDelegate myDelegate = new MyDelegate(PrintMessage);
        myDelegate += WriteMessage;
        Action<string> actionString = message => Console.WriteLine($"Hello from Action {message}");
        //Action<string> 轉換成 MyDelegate
        myDelegate += new MyDelegate(actionString);
        Func<string, string> functionString = delegate (string message) { return $"Hello from Func {message}"; };
        //Lambda 包裝一下
        myDelegate += (message) => Console.WriteLine(functionString(message));
        myDelegate += message => Console.WriteLine($"Hello from Lambda {message}");

        Console.WriteLine("請先輸入文字");
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

