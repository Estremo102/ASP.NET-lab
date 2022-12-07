namespace lab_8.Models;

public class DefaultClock: IClockProvider
{
    public DateTime Now()
    {
        return DateTime.Now;
    }

    public DateTime Epoch()
    {
        return DateTime.UnixEpoch;
    }
}