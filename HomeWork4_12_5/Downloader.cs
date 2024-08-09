namespace HomeWork4_12_5;

public class Downloader : IDisposable{

    private int _threadsCount;
    private Logger _log;
    private List<ManualResetEvent> _signals = new List<ManualResetEvent>();

    public Downloader(int threadsCount) {
        _threadsCount = threadsCount;
        _log = new Logger($"download {DateTime.Today.ToString("d-MMM-yy")}.log");
    }

    public void Dispose() {
        _log.Write("Downloader", "Finished");
        _log.Dispose();
        _signals.ForEach(signal => signal.Dispose());
    }

    public void Start() {
        _log.Write("Downloader", "Started");

        for (int i = 0; i < _threadsCount; i++) {
            _signals.Add(new ManualResetEvent(false));
            new Thread(new ParameterizedThreadStart(DownloadThread)).Start(i);
        }

        WaitHandle.WaitAll(_signals.ToArray());
    }

    private void DownloadThread(object arg) {
        
        var threadIndex = (int)arg;
        var threadName = $"Dwn.Thread #{(int)threadIndex + 1}";
        _log.Write(threadName, "Started");
        
        // Імітація корисного навантаження 
        var random = new Random();
        Thread.Sleep(random.Next(50, 70));
        
        _log.Write(threadName, "Finished");

        _signals[threadIndex].Set();
    }

}
