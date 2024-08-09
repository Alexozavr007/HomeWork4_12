using System.Text;

class Program {
    //static ManualResetEvent manual = new ManualResetEvent(false);
    static AutoResetEvent auto = new AutoResetEvent(false);

    static void Main() {
        Console.OutputEncoding = Encoding.Unicode;
        new Thread(Function1).Start();
        new Thread(Function2).Start();

        Thread.Sleep(500);  // Дамо час запуститися вторинним потокам.

        Console.WriteLine("Натисніть будь-яку клавішу для переведення ResetEvent у сигнальний стан.\n");
        Console.ReadKey();
        auto.Set();
        auto.Set();

        // Delay
        Console.ReadKey();
    }

    static void Function1() {
        Console.WriteLine("Потік 1 запущений та очікує сигналу.");
        //manual.WaitOne();
        auto.WaitOne();
        Console.WriteLine("Потік 1 завершується.");
    }

    static void Function2() {
        Console.WriteLine("Потік 2 запущений та очікує сигналу.");
        //manual.WaitOne();
        auto.WaitOne();
        Console.WriteLine("Потік 2 завершується.");
    }
}