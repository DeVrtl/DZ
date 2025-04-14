using System;
using System.IO;

public class FileLogger : IDisposable
{
    private StreamWriter _streamWriter;
    private bool _disposed = false;

    public FileLogger(string filePath)
    {
        _streamWriter = new StreamWriter(filePath, true);
    }

    public void Log(string message)
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(FileLogger));
        
        _streamWriter.WriteLine(message);
    }

    public void Dispose()
    {
        Dispose(true); 
        GC.SuppressFinalize(this);
    }
    
    ~FileLogger()
    {
        Dispose(false);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _streamWriter?.Dispose();
            }
            _disposed = true;
        }
    }
}
