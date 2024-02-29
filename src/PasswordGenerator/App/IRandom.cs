namespace PasswordGenerator.App;
public interface IRandom
{
    int Next(int maxValue);
    int Next(int minValue, int maxValue);
}
