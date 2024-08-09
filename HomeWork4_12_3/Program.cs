using System.Text;

class Program {
    static readonly string mutexName = "pop";

    static void Main() {
        Console.OutputEncoding = Encoding.Unicode;
        using (Mutex mutex = new Mutex(false, mutexName, out bool createdNew)) {
            if (!createdNew) {
                Console.WriteLine("Програма вже запущена.");
                return;
            }

            Console.WriteLine("Програма запущена вперше.");
            Console.WriteLine("Натисніть будь-яку клавішу, щоб вийти...");
            Console.ReadKey();
        }
    }
}