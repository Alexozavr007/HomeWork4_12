namespace HomeWork4_12_5;

public class Logger : IDisposable{

    private Semaphore _locker = new Semaphore(1, 1, "FileLocker");
    private string _name;
    private FileStream _fl;
    private StreamWriter _writer;

    public Logger(string fileName) {
        _name = fileName;
        _fl = new FileStream (_name, FileMode.OpenOrCreate, FileAccess.Write);
        _writer = new StreamWriter(_fl);
        _fl.Position = _fl.Length;
    }

    public void Write(string caller, string message) {
        _locker.WaitOne();
        _writer.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")} {caller} >> {message}");
        _locker.Release();
    }

    public void Dispose() {
        _writer.Close();
        _fl.Close();


        _writer.Dispose();
        _fl.Dispose();

        _locker.Dispose();
    }
}
