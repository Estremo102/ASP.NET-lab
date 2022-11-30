namespace lab_6.Models
{
    public interface IClockProvider
    {
        DateTime Now();
        DateTime Epoch();
    }
}
