namespace PublicSpace;

public interface IPublicSpace
{
    public void Close();
    public void Open();
    public bool IsOpen();
}

public class PublicSpace : IPublicSpace
{
    bool _isClosed;
    public uint Capacity { get; set; }
    public void Close() => _isClosed = true;
    public void Open() => _isClosed = false;
    public bool IsOpen() => !_isClosed;
}
