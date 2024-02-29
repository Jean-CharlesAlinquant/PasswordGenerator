namespace PasswordGenerator.App;
public class PasswordMaker
{
    private const string SpecialCharacters = "!@#$%^&*()_-+=";
    private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private readonly IRandom _randomiser;

    public PasswordMaker(IRandom random)
    {
        _randomiser = random;
    }

    public string Generate(int minLength, int maxLength, bool shallUseSpecialCharacters)
    {
        ValidateLengths(minLength, maxLength);
        var passwordLength = PickRandomLength(minLength, maxLength);
        return GenerateRandomString(shallUseSpecialCharacters, passwordLength);
    }

    private int PickRandomLength(int minLength, int maxLength)
    {
        return _randomiser.Next(minLength, maxLength + 1);
    }
    private void ValidateLengths(int minLength, int maxLength)
    {
        if (minLength < 1)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(minLength)} must be greater than 0");
        }
        if (maxLength < minLength)
        {
            throw new ArgumentOutOfRangeException(
                $"{nameof(minLength)} must be smaller than {nameof(maxLength)}");
        }
    }

    private string GenerateRandomString(bool shallUseSpecialCharacters, int length)
    {
        var characters = shallUseSpecialCharacters ?
            Characters + SpecialCharacters :
            Characters;

        return new string(Enumerable.Repeat(characters, length)
                                    .Select(characters => characters[_randomiser.Next(characters.Length)])
                                    .ToArray());
    }
}
