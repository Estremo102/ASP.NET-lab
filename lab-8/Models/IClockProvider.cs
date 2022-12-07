namespace lab_8.Models;

public interface IClockProvider
{
    DateTime Now();

    DateTime Epoch();
}