namespace EventHandlers;

public delegate void SubscriberChangedHandler(uint subscribers);

public class Channel
{
    public uint Subscribers { get; set; }

    // Backing field
    private SubscriberChangedHandler? _subscriberChanged;

    public event SubscriberChangedHandler SubscriberChanged
    {
        add
        {
            Console.WriteLine($"Adding Channel Subscriber {value}");
            _subscriberChanged += value;
        }
        remove
        {
            Console.WriteLine($"Removing Channel Subscriber {value}");
            _subscriberChanged -= value;
        }
    }

    public Channel()
    {
        Subscribers = 0;
    }

    public void AddSubscriber()
    {
        Subscribers += 1;
        Console.WriteLine("Adding subscriber");
        _subscriberChanged?.Invoke(Subscribers);
    }
}
