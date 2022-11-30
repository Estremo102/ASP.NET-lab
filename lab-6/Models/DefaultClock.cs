namespace lab_6.Models
{
    public class DefaultClock : IClockProvider
    {
        public DateTime Now() => DateTime.Now;
        public DateTime Epoch() => DateTime.UnixEpoch;
    }
}
