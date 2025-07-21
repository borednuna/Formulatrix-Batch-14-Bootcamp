namespace EventHandlers;

public class StandardPosterEventArgs : EventArgs
{
    public readonly string LastPost;

    public StandardPosterEventArgs(string lastPost)
    {
        Console.WriteLine($"Firing event args {lastPost}");
        LastPost = lastPost;
    }
}

public class Post
{
    string lastPost;
    public Post(string lastPost)
    {
        Console.WriteLine($"First post: {lastPost}");
        this.lastPost = lastPost;
    }
    public event EventHandler<StandardPosterEventArgs> PostUpdated;

    protected virtual void OnPostUpdated(StandardPosterEventArgs e)
    {
        PostUpdated?.Invoke(this, e);
    }

    public string LastPost
    {
        get => lastPost;
        set
        {
            if (lastPost == value) return;
            lastPost = value;
            OnPostUpdated(new StandardPosterEventArgs(value));
        }
    }
}
